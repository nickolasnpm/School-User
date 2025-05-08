using MediatR;
using SchoolUser.Application.Mediator.ClassRankMediator.Queries;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Handlers
{
    public class GetClassRankByNameHandler : IRequestHandler<GetClassRankByNameQuery, ClassRank?>
    {
        private readonly IClassRankRepository _ClassRankRepository;

        public GetClassRankByNameHandler(IClassRankRepository ClassRankRepository)
        {
            _ClassRankRepository = ClassRankRepository;
        }

        public async Task<ClassRank?> Handle(GetClassRankByNameQuery request, CancellationToken cancellationToken)
        {
            return await _ClassRankRepository.GetByNameAsync(request.Name);
        }
    }
}