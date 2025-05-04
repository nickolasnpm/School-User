using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers;

public class VerifyUserHandler : IRequestHandler<VerifyUserCommand, User?>
{
    private readonly IUserRepository _userRepository;

    public VerifyUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.VerifyUserAsync(request.User);
    }
}
