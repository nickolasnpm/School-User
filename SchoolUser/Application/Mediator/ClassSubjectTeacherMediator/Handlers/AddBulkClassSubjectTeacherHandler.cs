using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class AddBulkClassSubjectTeacherHandler : IRequestHandler<AddBulkClassSubjectTeacherCommand, bool>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public AddBulkClassSubjectTeacherHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }

        public async Task<bool> Handle(AddBulkClassSubjectTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.CreateBulkAsync(request.ClassSubjectTeachers);
        }
    }
}