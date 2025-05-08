using MediatR;
using SchoolUser.Application.Mediator.ClassRankMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Handlers
{
    public class DeleteClassRankHandler : IRequestHandler<DeleteClassRankCommand, bool>
    {
        private readonly IClassRankRepository _ClassRankRepository;

        public DeleteClassRankHandler(IClassRankRepository ClassRankRepository)
        {
            _ClassRankRepository = ClassRankRepository;
        }

        public async Task<bool> Handle(DeleteClassRankCommand request, CancellationToken cancellationToken)
        {
            return await _ClassRankRepository.DeleteAsync(request.id);
        }
    }
}