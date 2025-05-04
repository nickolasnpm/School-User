using MediatR;
using SchoolUser.Application.Mediator.ClassRankMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Handlers
{
    public class UpdateClassRankHandler : IRequestHandler<UpdateClassRankCommand, ClassRank?>
    {
        private readonly IClassRankRepository _ClassRankRepository;

        public UpdateClassRankHandler(IClassRankRepository ClassRankRepository)
        {
            _ClassRankRepository = ClassRankRepository;
        }

        public async Task<ClassRank?> Handle(UpdateClassRankCommand request, CancellationToken cancellationToken)
        {
            return await _ClassRankRepository.UpdateAsync(request.ClassRank);
        }
    }
}