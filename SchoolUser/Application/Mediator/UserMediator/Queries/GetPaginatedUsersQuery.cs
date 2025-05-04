using SchoolUser.Domain.Models;
using MediatR;
using SchoolUser.Application.DTOs;

namespace SchoolUser.Application.Mediator.UserMediator.Queries
{
    public record GetPaginatedUsersQuery(UsersListRequestDto ListRequestDto) : IRequest<(IEnumerable<User>?, int)>;
}