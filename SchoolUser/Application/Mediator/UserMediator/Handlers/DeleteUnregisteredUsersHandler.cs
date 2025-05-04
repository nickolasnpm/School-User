using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class DeleteUnregisteredUsersHandler : IRequestHandler<DeleteUnregisteredUsersCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUnregisteredUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUnregisteredUsersCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteUnregisteredUsersAsync();
        }
    }
}