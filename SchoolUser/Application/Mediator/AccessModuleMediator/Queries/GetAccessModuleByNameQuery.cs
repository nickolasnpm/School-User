using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Queries
{
    public record GetAccessModuleByNameQuery(string name) : IRequest<AccessModule?>;
}