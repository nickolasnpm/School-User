using MediatR;
using SchoolUser.Application.Mediator.AccessModuleMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Handlers
{
    public class DeleteAccessModuleHandler : IRequestHandler<DeleteAccessModuleCommand, bool>
    {
        private readonly IAccessModuleRepository _accessModuleRepository;

        public DeleteAccessModuleHandler(IAccessModuleRepository accessModuleRepository)
        {
            _accessModuleRepository = accessModuleRepository;
        }

        public async Task<bool> Handle(DeleteAccessModuleCommand request, CancellationToken cancellationToken)
        {
            return await _accessModuleRepository.DeleteAsync(request.id);
        }
    }
}