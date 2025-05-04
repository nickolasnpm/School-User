using MediatR;
using SchoolUser.Application.Mediator.AccessModuleMediator.Queries;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Handlers
{
    public class GetAccessModuleByIdHandler : IRequestHandler<GetAccessModuleByIdQuery, AccessModule?>
    {
        private readonly IAccessModuleRepository _accessModuleRepository;

        public GetAccessModuleByIdHandler(IAccessModuleRepository accessModuleRepository)
        {
            _accessModuleRepository = accessModuleRepository;
        }

        public async Task<AccessModule?> Handle(GetAccessModuleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _accessModuleRepository.GetByIdAsync(request.id);
        }
    }
}