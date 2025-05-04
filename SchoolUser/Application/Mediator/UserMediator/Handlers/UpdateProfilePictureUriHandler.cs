using MediatR;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.UserMediator.Handlers
{
    public class UpdateProfilePictureUriHandler : IRequestHandler<UpdateProfilePictureUriCommand, User?>
    {
        private readonly IUserRepository _userRepository;

        public UpdateProfilePictureUriHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(UpdateProfilePictureUriCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateProfilePictureUriAsync(request.Id, request.Uri);
        }
    }
}