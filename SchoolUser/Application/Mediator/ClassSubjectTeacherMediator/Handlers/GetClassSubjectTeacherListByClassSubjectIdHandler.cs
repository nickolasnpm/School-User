using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class GetClassSubjectTeacherListByClassSubjectIdHandler : IRequestHandler<GetClassSubjectTeacherListByClassSubjectIdQuery, IEnumerable<ClassSubjectTeacher>?>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public GetClassSubjectTeacherListByClassSubjectIdHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }

        public async Task<IEnumerable<ClassSubjectTeacher>?> Handle(GetClassSubjectTeacherListByClassSubjectIdQuery request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.GetListByClasssSubjectIdAsync(request.classSubjectId);
        }

    }
}