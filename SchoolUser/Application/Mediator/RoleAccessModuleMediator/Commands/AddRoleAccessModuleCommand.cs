using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.RoleAccessModuleMediator.Commands;
public record AddRoleAccessModuleCommand(RoleAccessModule RoleAccessModule): IRequest<RoleAccessModule?>; 