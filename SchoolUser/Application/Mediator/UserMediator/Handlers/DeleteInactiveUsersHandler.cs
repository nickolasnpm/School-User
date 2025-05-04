using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class DeleteInactiveUsersHandler : IRequestHandler<DeleteInactiveUsersCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteInactiveUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteInactiveUsersCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteInactiveUsersAsync();
        }
    }
}