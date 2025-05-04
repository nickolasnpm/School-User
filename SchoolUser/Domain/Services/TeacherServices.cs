using AutoMapper;
using MediatR;
using SchoolUser.Application.DTOs;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries;
using SchoolUser.Application.Mediator.TeacherMediator.Commands;
using SchoolUser.Application.Mediator.TeacherMediator.Queries;
using static SchoolUser.Application.Constants.Enums.FunctionalEnum;
using System.Globalization;
using SchoolUser.Application.Mediator.BatchMediator.Queries;
using SchoolUser.Application.Mediator.BatchMediator.Commands;
using SchoolUser.Application.Mediator.SubjectMediator.Queries;
using SchoolUser.Application.Mediator.SubjectMediator.Commands;

namespace SchoolUser.Domain.Services
{
    public class TeacherServices : ITeacherServices
    {
        private readonly string _entityName = "Teacher";
        private readonly string _subEntityName = "Class Subject Teacher";
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly ISubjectServices _subjectServices;

        public TeacherServices(ISender sender, IMapper mapper, IReturnValueConstants returnValueConstants, ISubjectServices subjectServices)
        {
            _sender = sender;
            _mapper = mapper;
            _returnValueConstants = returnValueConstants;
            _subjectServices = subjectServices;
        }

        public async Task<(bool, Teacher)> CreateTeacherService(Teacher teacher, List<Guid>? classSubjectIds)
        {
            var existing = await _sender.Send(new GetTeacherByUserIdQuery(teacher.UserId));

            if (existing != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, _entityName));
            }

            var createdTeacher = await _sender.Send(new AddTeacherCommand(teacher));

            if (createdTeacher == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _entityName));
            }

            if (classSubjectIds != null && classSubjectIds.Count > 0)
            {
                var createdClassSubjectTeacher = await CreateBulkClassSubjectTeacher(createdTeacher!.Id, classSubjectIds!);

                if (!createdClassSubjectTeacher)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _subEntityName));
                }
            }

            return (true, createdTeacher);
        }

        private async Task<bool> CreateBulkClassSubjectTeacher(Guid teacherId, List<Guid> classSubjectIds)
        {
            List<ClassSubjectTeacher>? existedObjectsByTeacherId = (List<ClassSubjectTeacher>?)await _sender.Send(new GetClassSubjectTeacherListByTeacherIdQuery(teacherId));
            List<Guid>? existedIdsByTeacherId = [];
            List<Guid> toBeCreatedClassSubjectIds = [];
            List<ClassSubjectTeacher> toBeCreatedObjects = [];

            if (existedObjectsByTeacherId != null && existedObjectsByTeacherId.Any())
            {
                existedIdsByTeacherId = existedObjectsByTeacherId!.Select(css => css.ClassSubjectId).ToList();
            }

            if (existedIdsByTeacherId != null && existedIdsByTeacherId.Any())
            {
                toBeCreatedClassSubjectIds = (List<Guid>)classSubjectIds.Except(existedIdsByTeacherId);
            }
            else
            {
                toBeCreatedClassSubjectIds = classSubjectIds;
            }

            foreach (var id in toBeCreatedClassSubjectIds!)
            {
                ClassSubjectTeacher classSubjectTeacher = new ClassSubjectTeacher()
                {
                    Id = Guid.NewGuid(),
                    ClassSubjectId = id,
                    TeacherId = teacherId
                };

                toBeCreatedObjects.Add(classSubjectTeacher);
            }

            return await _sender.Send(new AddBulkClassSubjectTeacherCommand(toBeCreatedObjects));
        }

        public async Task<Teacher?> UpdateTeacherService(UserUpdateRequestDto requestDto, Teacher? teacher)
        {
            if (teacher == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            if (!string.IsNullOrWhiteSpace(requestDto.ResponsibilityType) && !string.IsNullOrWhiteSpace(requestDto.ResponsibilityFocus))
            {
                await CheckResponsibilityFocusValidity(requestDto.ResponsibilityType, requestDto.ResponsibilityType);
                requestDto.ResponsibilityType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(requestDto.ResponsibilityType);
                requestDto.ResponsibilityFocus = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(requestDto.ResponsibilityFocus);
            }

            if (teacher.ServiceStatus?.ToLower() == requestDto.ServiceStatus?.ToLower() &&
                teacher.IsAvailable == requestDto.IsAvailable &&
                teacher.ResponsibilityType?.ToLower() == requestDto.ResponsibilityType?.ToLower() &&
                teacher.ResponsibilityFocus?.ToLower() == requestDto.ResponsibilityFocus?.ToLower() &&
                teacher.ClassCategoryId == requestDto.ClassCategoryId)
            {
                return null;
            }

            teacher.ServiceStatus = requestDto.ServiceStatus!;
            teacher.IsAvailable = (bool)requestDto.IsAvailable!;
            teacher.ResponsibilityType = requestDto.ResponsibilityType != null ? requestDto.ResponsibilityType : null;
            teacher.ResponsibilityFocus = requestDto.ResponsibilityFocus != null ? requestDto.ResponsibilityFocus : null;
            teacher.ClassCategoryId = requestDto.ClassCategoryId != null ? requestDto.ClassCategoryId : null ;

            return await _sender.Send(new UpdateTeacherCommand(teacher));
        }

        private async Task CheckResponsibilityFocusValidity(string resType, string resFocus)
        {
            if (Enum.TryParse(typeof(ResponsibilityType), resType, true, out var responsibilityType))
            {
                string resFocusError = "Responsibility Focus";

                switch ((ResponsibilityType)responsibilityType)
                {
                    case ResponsibilityType.Batch:
                        List<Batch>? allBatches = (List<Batch>?)await _sender.Send(new GetAllBatchesQuery(true));
                        List<string>? batchNames = allBatches?.Cast<Batch>().Select(batch => batch.Name).ToList();
                        if (!batchNames!.Contains(resFocus))
                        {
                            throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, resFocusError));
                        }
                        break;
                    case ResponsibilityType.Subject:
                        List<string>? subjectNames = (await _subjectServices.GetAllService())?.Cast<Subject>().Select(subject => subject.Name).ToList();
                        if (!subjectNames!.Contains(resFocus))
                        {
                            throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, resFocusError));
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}