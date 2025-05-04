using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserMediator.Commands;

public record ChangePasswordCommand(User User) : IRequest<User?>;
