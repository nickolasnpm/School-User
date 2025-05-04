using AutoMapper;
using MediatR;
using SchoolUser.Application.DTOs;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries;
using SchoolUser.Application.Mediator.StudentMediator.Commands;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;
using SchoolUser.Application.Mediator.StudentMediator.Queries;

namespace SchoolUser.Domain.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly string _entityName = "Student";
        private readonly string _subEntityName = "Class Subject Student";
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly IClassCategoryServices _classCategoryServices;
        private readonly IPublishingServices _publishingServices;

        public StudentServices(ISender sender, IMapper mapper, IReturnValueConstants returnValueConstants, IClassCategoryServices classCategoryServices, IPublishingServices publishingServices)
        {
            _sender = sender;
            _mapper = mapper;
            _returnValueConstants = returnValueConstants;
            _classCategoryServices = classCategoryServices;
            _publishingServices = publishingServices;
        }

        public async Task<(bool, Student)> CreateStudentService(User user, Student student, List<Guid> classSubjectIds)
        {
            var existing = await _sender.Send(new GetStudentByUserIdQuery(user.Id));

            if (existing != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, _entityName));
            }

            var createdStudent = await _sender.Send(new AddStudentCommand(student));

            if (createdStudent == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _entityName));
            }

            var createdClassSubjectStudent = await CreateBulkClassSubjectStudent(createdStudent!.Id, classSubjectIds!);

            if (!createdClassSubjectStudent)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _subEntityName));
            }

            var classCategory = await _sender.Send(new GetClassCategoryByIdQuery((Guid)createdStudent.ClassCategoryId!));

            StudentToBePublishedDto dto = new StudentToBePublishedDto()
            {
                StudentName = user.FullName,
                StudentId = createdStudent.Id.ToString(),
                ClassName = classCategory != null ? classCategory.Code : null,
                ClassId = createdStudent.ClassCategoryId.ToString(),
                EmailAddress = user.EmailAddress
            };

            return (await _publishingServices.PublishAnnualAttendanceRecordsService(dto), createdStudent);
        }

        private async Task<bool> CreateBulkClassSubjectStudent(Guid studentId, List<Guid> classSubjectIds)
        {
            List<ClassSubjectStudent>? existedObjectsByStudentId = (List<ClassSubjectStudent>?)await _sender.Send(new GetClassSubjectStudentListByStudentIdQuery(studentId));
            List<Guid>? existedIdsByStudentId = [];
            List<Guid> toBeCreatedClassSubjectIds = [];
            List<ClassSubjectStudent> toBeCreatedClassSubjectStudentObjects = [];

            if (existedObjectsByStudentId != null && existedObjectsByStudentId.Any())
            {
                existedIdsByStudentId = existedObjectsByStudentId!.Select(css => css.ClassSubjectId).ToList();
            }

            if (existedIdsByStudentId != null && existedIdsByStudentId.Any())
            {
                toBeCreatedClassSubjectIds = classSubjectIds.Except(existedIdsByStudentId).ToList();
            }
            else
            {
                toBeCreatedClassSubjectIds = classSubjectIds;
            }

            foreach (var id in toBeCreatedClassSubjectIds!)
            {
                ClassSubjectStudent classSubjectStudent = new ClassSubjectStudent()
                {
                    Id = Guid.NewGuid(),
                    ClassSubjectId = id,
                    StudentId = studentId
                };

                toBeCreatedClassSubjectStudentObjects.Add(classSubjectStudent);
            }

            return await _sender.Send(new AddBulkClassSubjectStudentCommand(toBeCreatedClassSubjectStudentObjects));
        }

        public async Task<Student?> UpdateStudentService(UserUpdateRequestDto requestDto, Student? student)
        {
            if (student == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            List<Guid>? toMaintainClassSubjectIds = [];
            List<Guid>? toDeleteClassSubjectIds = [];
            List<Guid>? toCreateClassSubjectIds = [];

            IEnumerable<ClassSubjectStudent>? existingClassSubjectStudents = await _sender.Send(new GetClassSubjectStudentListByStudentIdQuery(student.Id));
            List<Guid>? existingClassSubjectIds = existingClassSubjectStudents!.Select(c => c.ClassSubjectId).ToList();

            if (requestDto.ClassSubjectIds != null && requestDto.ClassSubjectIds.Any() 
                && existingClassSubjectIds != null && existingClassSubjectIds.Any())
            {
                toMaintainClassSubjectIds = existingClassSubjectIds.Intersect(requestDto.ClassSubjectIds).ToList();
                toDeleteClassSubjectIds = existingClassSubjectIds.Except(requestDto.ClassSubjectIds).ToList();
                toCreateClassSubjectIds = requestDto.ClassSubjectIds.Except(existingClassSubjectIds).ToList();
            }

            #region Check if all thing not updated
            bool isUpdatingStudent = false;
            bool isUpdatingClassSubjectStudent = false;

            if (student.EntranceYear != requestDto.EntranceYear ||
                student.EstimatedExitYear != requestDto.EstimatedExitYear ||
                student.RealExitYear != requestDto.RealExitYear ||
                student.ExitReason != requestDto.ExitReason ||
                student.ClassCategoryId != requestDto.ClassCategoryId)
            {
                student.EntranceYear = requestDto.EntranceYear;
                student.EstimatedExitYear = requestDto.EstimatedExitYear;
                student.RealExitYear = requestDto.RealExitYear;
                student.ExitReason = requestDto.ExitReason;
                student.ClassCategoryId = requestDto.ClassCategoryId;

                isUpdatingStudent = true;
            }

            if ((toDeleteClassSubjectIds != null && toDeleteClassSubjectIds!.Count > 0) ||
                (toCreateClassSubjectIds != null && toCreateClassSubjectIds!.Count > 0))
            {
                isUpdatingClassSubjectStudent = true;
            }

            if (!isUpdatingStudent && !isUpdatingClassSubjectStudent)
            {
                return null;
            }
            #endregion

            #region updating operation 
            bool isStudentUpdated = true;
            Student? updatedStudent = new Student();
            bool isCreatedClassSubjectStudent = true;
            bool isDeletedClassSubjectStudent = true;

            if (isUpdatingStudent)
            {
                updatedStudent = await _sender.Send(new UpdateStudentCommand(student));
                isStudentUpdated = updatedStudent != null;
            }

            if (isUpdatingClassSubjectStudent)
            {
                if (toDeleteClassSubjectIds != null && toDeleteClassSubjectIds!.Count > 0)
                {
                    isDeletedClassSubjectStudent = await _sender.Send(new DeleteBulkClassSubjectStudentCommand(toDeleteClassSubjectIds));
                }

                if (toCreateClassSubjectIds != null && toCreateClassSubjectIds!.Count > 0)
                {
                    isCreatedClassSubjectStudent = await CreateBulkClassSubjectStudent(student.Id, toCreateClassSubjectIds);
                }
            }

            if (!isStudentUpdated || !isDeletedClassSubjectStudent || !isCreatedClassSubjectStudent)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName));
            }

            #endregion

            return updatedStudent;
        }

        public async Task<bool> UpdateStudentInBulkService(StudentsBulkUpdateDto updateStudentsDto)
        {
            if (updateStudentsDto.ClassCategoryId != null)
            {
                bool isClassCategoryIdValid = await _classCategoryServices.GetByIdService((Guid)updateStudentsDto.ClassCategoryId) != null;

                // query student from user table where they has the similar categoryId
                // update the isActive value


                if (!isClassCategoryIdValid)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, $"Class Category"));
                }
            }

            return await _sender.Send(new UpdateBulkStudentsCommand(updateStudentsDto));
        }
    }
}