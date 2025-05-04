using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Handlers
{
    public class AddBulkClassSubjectStudentHandler : IRequestHandler<AddBulkClassSubjectStudentCommand, bool>
    {
        private readonly IClassSubjectStudentRepository _classSubjectStudentRepository;

        public AddBulkClassSubjectStudentHandler(IClassSubjectStudentRepository classSubjectStudentRepository)
        {
            _classSubjectStudentRepository = classSubjectStudentRepository;
        }

        public async Task<bool> Handle(AddBulkClassSubjectStudentCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectStudentRepository.CreateBulkAsync(request.classSubjectStudents);
        }
    }
}