using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserMediator.Commands;

public record VerifyUserCommand(User User) : IRequest<User?>;