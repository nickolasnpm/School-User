using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class GetClassSubjectByCodeAndYearHandler : IRequestHandler<GetClassSubjectByCodeAndYearQuery, ClassSubject?>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public GetClassSubjectByCodeAndYearHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<ClassSubject?> Handle(GetClassSubjectByCodeAndYearQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.GetByCodeAndYearAsync(request.code, request.year);
        }
    }
}