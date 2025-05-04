using SchoolUser.Application.Mediator.UserMediator.Commands;
using MediatR;
using SchoolUser.Domain.Models;
using SchoolUser.Domain.Interfaces.Repositories;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers;

public class AddUserHandler : IRequestHandler<AddUserCommand, User?>
{
    private readonly IUserRepository _userRepository;

    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.CreateAsync(request.User);
    }
}