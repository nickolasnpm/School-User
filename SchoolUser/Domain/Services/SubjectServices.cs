using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.SubjectMediator.Commands;
using SchoolUser.Application.Mediator.SubjectMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using System.Globalization;
using SchoolUser.Application.Mediator.TeacherMediator.Queries;
using SchoolUser.Application.Mediator.TeacherMediator.Commands;

namespace SchoolUser.Domain.Services
{
    public class SubjectServices : ISubjectServices
    {
        private readonly string _entityName = "Subject";
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;

        public SubjectServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<Subject>?> GetAllService()
        {
            return await _sender.Send(new GetAllSubjectsQuery());
        }

        public async Task<Subject?> GetByIdService(Guid id)
        {
            return await _sender.Send(new GetSubjectByIdQuery(id));
        }

        public async Task<bool> CreateService(SubjectDto subjectDto)
        {
            if (subjectDto == null)
            {
                throw new ArgumentNullException(nameof(subjectDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "SubjectDto"));
            }

            Subject? subject = await _sender.Send(new GetSubjectByNameQuery(subjectDto.Name));

            if (subject != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, _entityName));
            }

            // check teacher validity 
            var teacher = await _sender.Send(new GetTeacherByIdQuery(subjectDto.TeacherId));

            if (teacher == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "Teacher"));
            }

            if (teacher.ResponsibilityType != null)
            {
                await UpdateExistingTeacherResponsibility(teacher);
            }

            subject = new Subject()
            {
                Id = Guid.NewGuid(),
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subjectDto.Name),
                Code = subjectDto.Code,
                TeacherId = subjectDto.TeacherId
            };

            teacher.ResponsibilityType = "Subject";
            teacher.ResponsibilityFocus = subject.Name;

            var createdStudent = await _sender.Send(new AddSubjectCommand(subject)) != null;
            var updatedTeacher = await _sender.Send(new UpdateTeacherCommand(teacher)) != null;
            return createdStudent && updatedTeacher;
        }

        public async Task<bool> UpdateService(Guid id, SubjectDto subjectDto)
        {
            if (subjectDto == null)
            {
                throw new ArgumentNullException(nameof(subjectDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "SubjectDto"));
            }

            var subject = await _sender.Send(new GetSubjectByIdQuery(id));

            if (subject == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            // check teacher validity 
            var teacher = await _sender.Send(new GetTeacherByIdQuery(subjectDto.TeacherId));

            if (teacher == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "Teacher"));
            }

            if (teacher.ResponsibilityType != null)
            {
                await UpdateExistingTeacherResponsibility(teacher);
            }

            if (subject.Name.ToLower() == subjectDto.Name.ToLower() &&
                subject.Code == subjectDto.Code &&
                subject.TeacherId == subjectDto.TeacherId)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
            }

            subject.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subjectDto.Name);
            subject.Code = subjectDto.Code;
            subject.TeacherId = subjectDto.TeacherId;

            if (teacher.ResponsibilityType?.ToLower() != "subject" || teacher.ResponsibilityFocus?.ToLower() != subject.Name.ToLower())
            {
                teacher.ResponsibilityType = "Subject";
                teacher.ResponsibilityFocus = subject.Name;
            }

            var updatedSubject = await _sender.Send(new UpdateSubjectCommand(subject)) != null;
            var updatedTeacher = await _sender.Send(new UpdateTeacherCommand(teacher)) != null;
            return updatedSubject && updatedTeacher;
        }

        public async Task<bool> DeleteService(Guid id)
        {
            var existing = await _sender.Send(new GetSubjectByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return await _sender.Send(new DeleteSubjectCommand(id));
        }

        private async Task UpdateExistingTeacherResponsibility(Teacher teacher)
        {
            if (teacher.ResponsibilityType?.ToLower() == "subject" && teacher.ResponsibilityFocus != null)
            {
                var existingResponsibility = await _sender.Send(new GetSubjectByNameQuery(teacher.ResponsibilityFocus));

                if (existingResponsibility != null)
                {
                    var toUpdateSubject = new Subject
                    {
                        Id = existingResponsibility.Id,
                        Name = existingResponsibility.Name,
                        Code = existingResponsibility.Code,
                        TeacherId = null
                    };

                    var updatedExistingResponsibility = await _sender.Send(new UpdateSubjectCommand(toUpdateSubject));

                    if (updatedExistingResponsibility == null)
                    {
                        throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, "existing subject responsibility"));
                    }
                }
            }
        }
    }
}