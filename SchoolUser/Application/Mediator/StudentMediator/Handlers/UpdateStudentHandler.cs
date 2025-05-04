using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.StudentMediator.Commands;
using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.StudentMediator.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Student?>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student?> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentRepository.UpdateAsync(request.Student);
        }
    }
}