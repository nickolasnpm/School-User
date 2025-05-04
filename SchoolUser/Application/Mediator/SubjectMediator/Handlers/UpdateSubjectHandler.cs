using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.SubjectMediator.Commands;
using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.SubjectMediator.Handlers
{
    public class UpdateSubjectHandler : IRequestHandler<UpdateSubjectCommand, Subject?>
    {
        private readonly ISubjectRepository _subjectRepository;

        public UpdateSubjectHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject?> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _subjectRepository.UpdateAsync(request.Subject);
        }
    }
}