using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserMediator.Commands
{
    public record UpdateProfilePictureUriCommand(Guid Id, string Uri) : IRequest<User?>;
}