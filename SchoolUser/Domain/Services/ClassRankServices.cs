using System.Globalization;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.DTOs;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.ClassRankMediator.Commands;
using SchoolUser.Application.Mediator.ClassRankMediator.Queries;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Services
{
    public class ClassRankServices : IClassRankServices
    {
        private readonly string _entityName = "Class Rank";
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;

        public ClassRankServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<ClassRank>?> GetAllService(bool? isActive)
        {
            return await _sender.Send(new GetAllClassRanksQuery(isActive));
        }

        public async Task<ClassRank?> GetByIdService(Guid id)
        {
            return await _sender.Send(new GetClassRankByIdQuery(id));
        }

        public async Task<bool> CreateService(ClassRankDto classRankDto)
        {
            if (classRankDto == null)
            {
                throw new ArgumentNullException(nameof(classRankDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "ClassRankDto"));
            }

            ClassRank? classRank = await _sender.Send(new GetClassRankByNameQuery(classRankDto.Name));

            if (classRank != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, _entityName));
            }

            classRank = new ClassRank
            {
                Id = Guid.NewGuid(),
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(classRankDto.Name),
                Code = classRankDto.Code,
                IsActive = classRankDto.IsActive
            };

            return await _sender.Send(new AddClassRankCommand(classRank)) != null;
        }

        public async Task<bool> UpdateService(Guid id, ClassRankDto classRankDto)
        {
            if (classRankDto == null)
            {
                throw new ArgumentNullException(nameof(classRankDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "ClassRankDto"));
            }

            var classRank = await _sender.Send(new GetClassRankByIdQuery(id));

            if (classRank == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            if (classRank.Name.ToLower() == classRankDto.Name.ToLower() &&
                classRank.Code == classRankDto.Code &&
                classRank.IsActive == classRankDto.IsActive)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
            }

            classRank.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(classRankDto.Name);
            classRank.Code = classRankDto.Code;
            classRank.IsActive = classRankDto.IsActive;

            return await _sender.Send(new UpdateClassRankCommand(classRank)) != null;
        }

        public async Task<bool> DeleteService(Guid id)
        {
            var existing = await _sender.Send(new GetClassRankByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return await _sender.Send(new DeleteClassRankCommand(id));
        }
    }
}