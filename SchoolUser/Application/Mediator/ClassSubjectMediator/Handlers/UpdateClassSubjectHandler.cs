using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Commands;
using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Handlers
{
    public class UpdateClassSubjectHandler : IRequestHandler<UpdateClassSubjectCommand, ClassSubject?>
    {
        private readonly IClassSubjectRepository _classSubjectRepository;

        public UpdateClassSubjectHandler(IClassSubjectRepository classSubjectRepository)
        {
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<ClassSubject?> Handle(UpdateClassSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _classSubjectRepository.UpdateAsync(request.ClassSubject);
        }
    }
}