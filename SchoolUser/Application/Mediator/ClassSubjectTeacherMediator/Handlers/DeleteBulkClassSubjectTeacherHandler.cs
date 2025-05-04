using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Handlers
{
    public class DeleteBulkClassSubjectTeacherHandler : IRequestHandler<DeleteBulkClassSubjectTeacherCommand, bool>
    {
        private readonly IClassSubjectTeacherRepository _classSubjectTeacherRepository;

        public DeleteBulkClassSubjectTeacherHandler(IClassSubjectTeacherRepository classSubjectTeacherRepository)
        {
            _classSubjectTeacherRepository = classSubjectTeacherRepository;
        }

        public async Task<bool> Handle(DeleteBulkClassSubjectTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectTeacherRepository.DeleteBulkAsync(request.classSubjectIds);
        }
    }
}