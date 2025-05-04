using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserRoleMediator.Commands;

public record AddUserRoleCommand(UserRole UserRole) : IRequest<UserRole?>;
