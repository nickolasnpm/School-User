using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User?>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateAsync(request.User);
        }
    }
}