using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, User?>
{
    private readonly IUserRepository _userRepository;
    public ChangePasswordHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.ChangePasswordAsync(request.User);
    }
}
