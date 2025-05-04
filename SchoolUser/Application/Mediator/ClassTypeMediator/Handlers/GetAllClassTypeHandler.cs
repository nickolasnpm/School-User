using MediatR;
using SchoolUser.Application.Mediator.ClassRankMediator.Queries;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Handlers
{
    public class GetAllClassRankHandler : IRequestHandler<GetAllClassRanksQuery, IEnumerable<ClassRank>?>
    {
        private readonly IClassRankRepository _ClassRankRepository;

        public GetAllClassRankHandler(IClassRankRepository ClassRankRepository)
        {
            _ClassRankRepository = ClassRankRepository;
        }

        public async Task<IEnumerable<ClassRank>?> Handle(GetAllClassRanksQuery request, CancellationToken cancellationToken)
        {
            return await _ClassRankRepository.GetAllAsync(request.isActive);
        }
    }
}