using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.UserRoleMediator.Commands;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;

namespace SchoolUser.Domain.Services
{
    public class UserRoleServices : IUserRoleServices
    {
        private const string _entityName = "UserRole";
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        public UserRoleServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<bool> CreateUserRoleService(Guid userId, List<Guid> roleIds)
        {
            for (int i = 0; i < roleIds.Count; i++)
            {
                var userRole = new UserRole()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    RoleId = roleIds[i]
                };

                var result = await _sender.Send(new AddUserRoleCommand(userRole));

                if (result == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _entityName));
                }
            }

            return true;
        }
    }
}