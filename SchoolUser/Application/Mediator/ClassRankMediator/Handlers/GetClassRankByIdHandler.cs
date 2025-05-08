using MediatR;
using SchoolUser.Application.Mediator.ClassRankMediator.Queries;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Handlers
{
    public class GetClassRankByIdHandler : IRequestHandler<GetClassRankByIdQuery, ClassRank?>
    {
        private readonly IClassRankRepository _ClassRankRepository;

        public GetClassRankByIdHandler(IClassRankRepository ClassRankRepository)
        {
            _ClassRankRepository = ClassRankRepository;
        }

        public async Task<ClassRank?> Handle(GetClassRankByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ClassRankRepository.GetByIdAsync(request.id);
        }
    }
}