using MediatR;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class AddBulkClassSubjectHandler : IRequestHandler<AddBulkClassSubjectCommand, bool>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public AddBulkClassSubjectHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<bool> Handle(AddBulkClassSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.CreateBulkAsync(request.classSubjects);
        }
    }
}