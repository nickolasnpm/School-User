using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.TeacherMediator.Commands;
using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.TeacherMediator.Handlers
{
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, Teacher?>
    {
        private readonly ITeacherRepository _teacherRepository;

        public UpdateTeacherHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher?> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.UpdateAsync(request.Teacher);
        }
    }
}