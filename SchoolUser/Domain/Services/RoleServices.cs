using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.RoleMediator.Commands;
using SchoolUser.Application.Mediator.RoleMediator.Queries;
using SchoolUser.Domain.Models;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using System.Globalization;

namespace SchoolUser.Domain.Services
{
    public class RoleServices : IRoleServices
    {
        private const string _entityName = "Role";
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IReturnValueConstants _returnValueConstants;

        public RoleServices(ISender sender, IMapper mapper, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _mapper = mapper;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<Role>?> GetAllRolesService()
        {
            return await _sender.Send(new GetAllRolesQuery());
        }

        public async Task<List<Guid>?> GetValidRoleIdsListService(List<Guid> roleIds)
        {
            var roleList = (List<Role>?)await _sender.Send(new GetAllRolesQuery());

            var validRoleIds = roleIds
                .Where(id => roleList!.Any(role => role.Id == id))
                .ToList();

            if (validRoleIds.Count != roleIds.Count)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return validRoleIds;
        }

        public async Task<Role?> GetRoleService(Guid id)
        {
            return await _sender.Send(new GetRoleByIdQuery(id));
        }

        public async Task<bool> CreateRoleService(RoleDto roleDto)
        {
            if (roleDto == null)
            {
                throw new ArgumentNullException(nameof(roleDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "RoleDto"));
            }

            Role? role = await _sender.Send(new GetRoleByTitleQuery(roleDto.Title));

            if (role != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, _entityName));
            }

            role = new Role
            {
                Id = Guid.NewGuid(),
                Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(roleDto.Title)
            };

            return await _sender.Send(new AddRoleCommand(role)) != null;
        }

        public async Task<bool> UpdateRoleService(Guid id, RoleDto roleDto)
        {
            if (roleDto == null)
            {
                throw new ArgumentNullException(nameof(roleDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "RoleDto"));
            }

            var result = await _sender.Send(new GetRoleByIdQuery(id));

            if (result == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            if (result.Title == roleDto.Title)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
            }

            result.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(roleDto.Title);
            return await _sender.Send(new UpdateRoleCommand(result)) != null;
        }

        public async Task<bool> DeleteRoleService(Guid id)
        {
            var existing = await _sender.Send(new GetRoleByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return await _sender.Send(new DeleteRoleCommand(id));
        }
    }
}