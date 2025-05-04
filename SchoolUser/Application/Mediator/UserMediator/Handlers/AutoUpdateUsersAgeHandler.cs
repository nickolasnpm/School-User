using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class AutoUpdateUsersAgeHandler : IRequestHandler<AutoUpdateUsersAgeCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public AutoUpdateUsersAgeHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(AutoUpdateUsersAgeCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.AutoUpdateUsersAgeAsync();
        }
    }
}