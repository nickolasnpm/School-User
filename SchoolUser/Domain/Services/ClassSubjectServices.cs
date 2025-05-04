using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Commands;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.Mediator.SubjectMediator.Queries;

namespace SchoolUser.Domain.Services
{
    public class ClassSubjectServices : IClassSubjectServices
    {
        private readonly string _entityName = "Class Subject";
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;

        public ClassSubjectServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<ClassSubject>?> GetAllService()
        {
            return await _sender.Send(new GetAllClassSubjectsQuery());
        }

        public async Task<ClassSubject?> GetByIdService(Guid id)
        {
            return await _sender.Send(new GetClassSubjectByIdQuery(id));
        }

        public async Task<bool> CreateOfferedSubjectsService(ClassCategory classCategory, List<Guid> subjectIds)
        {
            List<Subject>? subjects = (List<Subject>?)await _sender.Send(new GetAllSubjectsQuery());
            List<Subject>? validSubjects = subjects!.Where(s => subjectIds.Contains(s.Id)).ToList();

            List<ClassSubject> toBeCreatedList = [];

            for (int i = 0; i < validSubjects.Count; i++)
            {
                var classSubject = new ClassSubject
                {
                    Id = Guid.NewGuid(),
                    Code = $"{classCategory!.Code}-{validSubjects[i]!.Code}",
                    AcademicYear = classCategory.AcademicYear,
                    SubjectId = validSubjects[i].Id,
                    ClassCategoryId = classCategory.Id,
                };

                toBeCreatedList.Add(classSubject);
            }

            return await _sender.Send(new AddBulkClassSubjectCommand(toBeCreatedList));
        }

        public async Task<bool> UpdateOfferedSubjectsService(ClassCategory classCategory, List<Guid> subjectIds)
        {
            List<ClassSubject>? classSubjects = classCategory.ClassSubjects;
            List<Guid> existingSubjectIdsPairedWithClassCategoryId = [];

            if (classSubjects != null & classSubjects!.Count > 0)
            {
                existingSubjectIdsPairedWithClassCategoryId = classSubjects.Select(cs => cs.SubjectId).ToList();
            }

            List<Subject>? subjects = (List<Subject>?)await _sender.Send(new GetAllSubjectsQuery());
            List<Guid> validSubjectIds = subjects!.Where(s => subjectIds.Contains(s.Id)).Select(s => s.Id).ToList();

            List<Guid>? toBeRemoved = [];
            List<Guid>? toBeCreated = [];

            bool removed = true;
            bool created = true;

            if (existingSubjectIdsPairedWithClassCategoryId != null && existingSubjectIdsPairedWithClassCategoryId.Count > 0 &&
                validSubjectIds != null && validSubjectIds.Count > 0)
            {
                toBeRemoved = existingSubjectIdsPairedWithClassCategoryId.Except(validSubjectIds).ToList();
                toBeCreated = validSubjectIds.Except(existingSubjectIdsPairedWithClassCategoryId).ToList();
            }
            else if (existingSubjectIdsPairedWithClassCategoryId == null && existingSubjectIdsPairedWithClassCategoryId!.Count < 1 &&
                validSubjectIds != null && validSubjectIds.Count > 0)
            {
                toBeCreated = validSubjectIds;
            }
            else if (existingSubjectIdsPairedWithClassCategoryId != null && existingSubjectIdsPairedWithClassCategoryId.Count > 0 &&
                validSubjectIds == null && validSubjectIds!.Count < 1)
            {
                toBeRemoved = existingSubjectIdsPairedWithClassCategoryId;
            }

            if (toBeRemoved != null && toBeRemoved.Count > 0)
            {
                removed = await _sender.Send(new DeleteBulkClassSubjectCommand(toBeRemoved));
            }

            if (toBeCreated != null && toBeCreated.Count > 0)
            {
                List<ClassSubject> toBeCreatedList = [];
                List<Guid> subjectNamesToBeCreated = subjects!.Where(s => toBeCreated.Contains(s.Id)).Select(s => s.Id).ToList();
                created = await CreateOfferedSubjectsService(classCategory, subjectNamesToBeCreated);
            }

            if (!removed || !created)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
            }

            return true;
        }

        public async Task<bool> DeleteService(Guid id)
        {
            var existing = await _sender.Send(new GetClassSubjectByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return await _sender.Send(new DeleteClassSubjectCommand(id));
        }
    }
}