using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserMediator.Commands;
public record UpdateUserCommand(User User) : IRequest<User?>;