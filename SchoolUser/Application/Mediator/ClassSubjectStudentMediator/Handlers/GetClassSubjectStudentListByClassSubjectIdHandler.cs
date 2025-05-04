using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class GetClassSubjectStudentListByClassSubjectIdHandler : IRequestHandler<GetClassSubjectStudentListByClassSubjectIdQuery, IEnumerable<ClassSubjectStudent>?>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public GetClassSubjectStudentListByClassSubjectIdHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<IEnumerable<ClassSubjectStudent>?> Handle(GetClassSubjectStudentListByClassSubjectIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.GetListByClassSubjectIdAsync(request.ClassSubjectId);
        }

    }
}