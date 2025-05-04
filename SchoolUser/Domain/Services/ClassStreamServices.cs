using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StreamMediator.Commands;
using SchoolUser.Application.Mediator.StreamMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using System.Globalization;

namespace SchoolUser.Domain.Services
{
    public class ClassStreamServices : IClassStreamServices
    {
        private readonly string _entityName = "Class Stream";
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;

        public ClassStreamServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<ClassStream>?> GetAllService(bool? isActive)
        {
            return await _sender.Send(new GetAllClassStreamsQuery(isActive));
        }

        public async Task<ClassStream?> GetByIdService(Guid id)
        {
            return await _sender.Send(new GetClassStreamByIdQuery(id));
        }

        public async Task<bool> CreateService(ClassStreamDto classStreamDto)
        {
            if (classStreamDto == null)
            {
                throw new ArgumentNullException(nameof(classStreamDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "ClassStreamDto"));
            }

            ClassStream? classStream = await _sender.Send(new GetClassStreamByNameQuery(classStreamDto.Name));

            if (classStream != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, _entityName));
            }

            classStream = new ClassStream()
            {
                Id = Guid.NewGuid(),
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(classStreamDto.Name),
                Code = classStreamDto.Code,
                IsActive = classStreamDto.IsActive,
            };

            return await _sender.Send(new AddClassStreamCommand(classStream)) != null;
        }

        public async Task<bool> UpdateService(Guid id, ClassStreamDto classStreamDto)
        {
            if (classStreamDto == null)
            {
                throw new ArgumentNullException(nameof(classStreamDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "ClassStreamDto"));
            }

            var classStream = await _sender.Send(new GetClassStreamByIdQuery(id));

            if (classStream == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            if (classStream.Name.ToLower() == classStreamDto.Name.ToLower() &&
                classStream.Code == classStreamDto.Code &&
                classStream.IsActive == classStreamDto.IsActive)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
            }

            classStream.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(classStreamDto.Name);
            classStream.Code = classStreamDto.Code;
            classStream.IsActive = classStreamDto.IsActive;

            return await _sender.Send(new UpdateClassStreamCommand(classStream)) != null;
        }

        public async Task<bool> DeleteService(Guid id)
        {
            var existing = await _sender.Send(new GetClassStreamByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return await _sender.Send(new DeleteClassStreamCommand(id));
        }
    }
}