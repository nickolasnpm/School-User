using MediatR;
using SchoolUser.Application.Mediator.AccessModuleMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Handlers
{
    public class AddAccessModuleHandler : IRequestHandler<AddAccessModuleCommand, AccessModule?>
    {
        private readonly IAccessModuleRepository _accessModuleRepository;

        public AddAccessModuleHandler(IAccessModuleRepository accessModuleRepository)
        {
            _accessModuleRepository = accessModuleRepository;
        }

        public async Task<AccessModule?> Handle(AddAccessModuleCommand request, CancellationToken cancellationToken)
        {
            return await _accessModuleRepository.CreateAsync(request.accessModule);
        }
    }
}