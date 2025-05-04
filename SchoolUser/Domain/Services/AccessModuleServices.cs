using System.Globalization;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.DTOs;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.AccessModuleMediator.Commands;
using SchoolUser.Application.Mediator.AccessModuleMediator.Queries;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Services
{
    public class AccessModuleServices : IAccessModuleServices
    {
        private const string _entityName = "Access Module";
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly IRoleServices _roleServices;
        private readonly IRoleAccessModuleServices _roleAccessModuleServices;

        public AccessModuleServices(ISender sender, IReturnValueConstants returnValueConstants, IRoleServices roleServices, IRoleAccessModuleServices roleAccessModuleServices)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
            _roleServices = roleServices;
            _roleAccessModuleServices = roleAccessModuleServices;
        }

        public async Task<IEnumerable<AccessModule>?> GetAllService()
        {
            return await _sender.Send(new GetAllAccessModulesQuery());
        }

        public async Task<AccessModule?> GetByIdService(Guid id)
        {
            return await _sender.Send(new GetAccessModuleByIdQuery(id));
        }

        public async Task<bool> CreateService(AccessModuleDto accessModuleDto)
        {
            if (accessModuleDto == null)
            {
                throw new ArgumentNullException(nameof(accessModuleDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "AccessModuleDto"));
            }

            AccessModule? existing = await _sender.Send(new GetAccessModuleByNameQuery(accessModuleDto.Name));

            if (existing != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, _entityName));
            }

            AccessModule accessModule = new AccessModule
            {
                Id = Guid.NewGuid(),
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(accessModuleDto.Name),
            };

            var createdAccessModule = await _sender.Send(new AddAccessModuleCommand(accessModule));

            if (createdAccessModule == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _entityName));
            }

            if (accessModuleDto.RoleIds == null && accessModuleDto.RoleIds!.Count == 0)
            {
                return true;
            }

            List<Guid>? validRoleIds = await _roleServices.GetValidRoleIdsListService(accessModuleDto.RoleIds);
            return await _roleAccessModuleServices.CreateRoleAccessModuleService(createdAccessModule, validRoleIds!);
        }

        public async Task<bool> UpdateService(Guid id, AccessModuleDto accessModuleDto)
        {
            if (accessModuleDto == null)
            {
                throw new ArgumentNullException(nameof(accessModuleDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "AccessModuleDto"));
            }

            var accessModule = await _sender.Send(new GetAccessModuleByIdQuery(id));
            var isObjectUpdated = false;

            if (accessModule == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            if (accessModule.Name.ToLower() != accessModuleDto.Name.ToLower())
            {
                accessModule.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(accessModuleDto.Name);

                isObjectUpdated = await _sender.Send(new UpdateAccessModuleCommand(accessModule)) != null;
            }

            if (!isObjectUpdated && accessModuleDto.RoleIds == null && accessModuleDto.RoleIds!.Count == 0)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
            }

            #region  update RoleAccessModule

            List<Guid> existingRoleIds = accessModule.Roles!.Select(role => role.Id).ToList();
            List<Guid>? validRoleIds = await _roleServices.GetValidRoleIdsListService(accessModuleDto.RoleIds);

            List<Guid>? toBeRemoved = existingRoleIds.Except(validRoleIds!).ToList();
            List<Guid>? toBeCreated = validRoleIds!.Except(existingRoleIds).ToList();

            bool removed = true;
            bool created = true;

            if (!isObjectUpdated && toBeRemoved == null && toBeRemoved!.Count == 0 &&
                toBeCreated == null && toBeCreated!.Count == 0)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
            }

            if (toBeRemoved != null && toBeRemoved.Count > 0)
            {
                removed = await _roleAccessModuleServices.DeleteRoleAccessModuleService(accessModule!, toBeRemoved);
            }

            if (toBeCreated != null && toBeCreated.Count > 0)
            {
                created = await _roleAccessModuleServices.CreateRoleAccessModuleService(accessModule!, toBeCreated);
            }

            if (!removed || !created)
            {
                return false;
            }

            #endregion

            return true;
        }

        public async Task<bool> DeleteService(Guid id)
        {
            var existing = await _sender.Send(new GetAccessModuleByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return await _sender.Send(new DeleteAccessModuleCommand(id));
        }
    }
}