using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.BatchMediator.Queries;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Commands;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;
using SchoolUser.Application.Mediator.StreamMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.Mediator.ClassRankMediator.Queries;

namespace SchoolUser.Domain.Services
{
    public class ClassCategoryServices : IClassCategoryServices
    {
        private readonly string _entityName = "Class Category";
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly IClassSubjectServices _classSubjectServices;
        private readonly ISubjectServices _subjectServices;

        public ClassCategoryServices(ISender sender, IReturnValueConstants returnValueConstants, IClassSubjectServices classSubjectServices, ISubjectServices subjectServices)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
            _classSubjectServices = classSubjectServices;
            _subjectServices = subjectServices;
        }

        public async Task<IEnumerable<ClassCategory>?> GetAllService()
        {
            return await _sender.Send(new GetAllClassCategoriesQuery());
        }

        public async Task<ClassCategory?> GetByIdService(Guid id)
        {
            return await _sender.Send(new GetClassCategoryByIdQuery(id));
        }

        public async Task<bool> CreateService(ClassCategoryDto classCategoryDto)
        {
            if (classCategoryDto == null)
            {
                throw new ArgumentNullException(nameof(classCategoryDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "ClassCategoryDto"));
            }

            var batch = await _sender.Send(new GetBatchByIdQuery(classCategoryDto.BatchId));
            var classRank = await _sender.Send(new GetClassRankByIdQuery(classCategoryDto.ClassRankId));
            var classStream = await _sender.Send(new GetClassStreamByIdQuery(classCategoryDto.ClassStreamId));

            if (batch == null || classStream == null || classRank == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _entityName));
            }

            var currentYear = DateTime.Now.Year;
            var categoryCode = $"{batch!.Code}-{classRank!.Code}-{classStream!.Code}";

            var classCategory = await _sender.Send(new GetClassCategoryByCodeAndYearQuery(categoryCode, currentYear));

            if (classCategory != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            classCategory = new ClassCategory()
            {
                Id = Guid.NewGuid(),
                Code = categoryCode,
                AcademicYear = currentYear,
                BatchId = classCategoryDto.BatchId,
                ClassRankId = classCategoryDto.ClassRankId,
                ClassStreamId = classCategoryDto.ClassStreamId
            };

            var createdClassCategory = await _sender.Send(new AddClassCategoryCommand(classCategory));

            if (createdClassCategory == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _entityName));
            }

            if (classCategoryDto.SubjectIds == null && classCategoryDto.SubjectIds!.Count == 0)
            {
                return true;
            }

            return await _classSubjectServices.CreateOfferedSubjectsService(classCategory, classCategoryDto.SubjectIds);
        }

        public async Task<bool> UpdateOfferedSubjectService(Guid id, ClassCategoryDto classCategoryDto)
        {
            if (classCategoryDto == null)
            {
                throw new ArgumentNullException(nameof(classCategoryDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "ClassCategoryDto"));
            }

            ClassCategory? classCategory = await _sender.Send(new GetClassCategoryByIdQuery(id));

            if (classCategory == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            if (classCategoryDto.SubjectIds == null && classCategoryDto.SubjectIds!.Count == 0)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
            }

            #region update classSubject
            return await _classSubjectServices.UpdateOfferedSubjectsService(classCategory, classCategoryDto.SubjectIds!);
            #endregion
        }

        public async Task<bool> DeleteService(Guid id)
        {
            var existing = await _sender.Send(new GetClassCategoryByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return await _sender.Send(new DeleteClassCategoryCommand(id));
        }
    }
}