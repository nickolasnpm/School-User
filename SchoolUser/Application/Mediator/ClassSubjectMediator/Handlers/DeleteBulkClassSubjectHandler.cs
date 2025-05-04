using MediatR;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class DeleteBulkClassSubjectHandler : IRequestHandler<DeleteBulkClassSubjectCommand, bool>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public DeleteBulkClassSubjectHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<bool> Handle(DeleteBulkClassSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.DeleteBulkAsync(request.subjectIds);
        }
    }
}