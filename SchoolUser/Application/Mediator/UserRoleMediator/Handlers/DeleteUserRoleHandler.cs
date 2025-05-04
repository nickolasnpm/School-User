using MediatR;
using SchoolUser.Application.Mediator.UserRoleMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;

namespace SchoolUser.Application.Mediator.UserRoleMediator.Handlers
{
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, bool>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public DeleteUserRoleHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<bool> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _userRoleRepository.DeleteAsync(request.id);
        }
    }
}