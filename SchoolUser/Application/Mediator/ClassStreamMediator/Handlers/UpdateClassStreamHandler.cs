using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.StreamMediator.Commands;
using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.StreamMediator.Handlers
{
    public class UpdateClassStreamHandler : IRequestHandler<UpdateClassStreamCommand, ClassStream?>
    {
        private readonly IClassStreamRepository _streamRepository;

        public UpdateClassStreamHandler(IClassStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }
        public async Task<ClassStream?> Handle(UpdateClassStreamCommand request, CancellationToken cancellationToken)
        {
            return await _streamRepository.UpdateAsync(request.ClassStream);
        }
    }
}