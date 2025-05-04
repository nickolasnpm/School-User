using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class DeleteBulkClassSubjectStudentHandler : IRequestHandler<DeleteBulkClassSubjectStudentCommand, bool>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public DeleteBulkClassSubjectStudentHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<bool> Handle(DeleteBulkClassSubjectStudentCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.DeleteBulkAsync(request.classSubjectIds);
        }
    }
}