using MediatR;
using SchoolUser.Application.Mediator.AccessModuleMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Handlers
{
    public class UpdateAccessModuleHandler : IRequestHandler<UpdateAccessModuleCommand, AccessModule?>
    {
        private readonly IAccessModuleRepository _accessModuleRepository;

        public UpdateAccessModuleHandler(IAccessModuleRepository accessModuleRepository)
        {
            _accessModuleRepository = accessModuleRepository;
        }

        public async Task<AccessModule?> Handle(UpdateAccessModuleCommand request, CancellationToken cancellationToken)
        {
            return await _accessModuleRepository.UpdateAsync(request.accessModule);
        }
    }
}