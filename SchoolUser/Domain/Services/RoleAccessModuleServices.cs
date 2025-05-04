

using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.RoleAccessModuleMediator.Commands;
using SchoolUser.Application.Mediator.RoleAccessModuleMediator.Queries;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Services
{
    public class RoleAccessModuleServices : IRoleAccessModuleServices
    {
        private const string _entityName = "RoleAccessModule";
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;

        public RoleAccessModuleServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<bool> CreateRoleAccessModuleService(AccessModule accessModule, List<Guid> roleIds)
        {
            RoleAccessModule roleAccessModule = new RoleAccessModule();
            RoleAccessModule? result = new RoleAccessModule();

            for (int i = 0; i < roleIds.Count; i++)
            {
                roleAccessModule.Id = Guid.NewGuid();
                roleAccessModule.RoleId = roleIds[i];
                roleAccessModule.AccessModuleId = accessModule.Id;

                result = await _sender.Send(new AddRoleAccessModuleCommand(roleAccessModule));

                if (result == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _entityName));
                }
            }

            return true;
        }

        public async Task<bool> DeleteRoleAccessModuleService(AccessModule accessModule, List<Guid> roleIds)
        {
            bool isDeleted = false;

            for (int i = 0; i < roleIds!.Count; i++)
            {
                List<RoleAccessModule>? roleAccessModules = (List<RoleAccessModule>?)await _sender.Send(new GetRoleAccessModuleByRoleIdQuery(roleIds[i]));

                if (roleAccessModules == null)
                {
                    return false;
                }

                for (int j = 0; j < roleAccessModules.Count; j++)
                {
                    if (roleIds[i] == roleAccessModules[j].RoleId && accessModule.Id == roleAccessModules[j].AccessModuleId)
                    {
                        isDeleted = await _sender.Send(new DeleteRoleAccessModuleCommand(roleAccessModules[j].Id));
                    }
                }
            }

            if (!isDeleted)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, _entityName));
            }

            return true;
        }
    }
}