using MediatR;
using SchoolUser.Application.Mediator.ClassRankMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Handlers
{
    public class AddClassRankHandler : IRequestHandler<AddClassRankCommand, ClassRank?>
    {
        private readonly IClassRankRepository _ClassRankRepository;

        public AddClassRankHandler(IClassRankRepository ClassRankRepository)
        {
            _ClassRankRepository = ClassRankRepository;
        }

        public async Task<ClassRank?> Handle(AddClassRankCommand request, CancellationToken cancellationToken)
        {
            return await _ClassRankRepository.CreateAsync(request.ClassRank);
        }
    }
}