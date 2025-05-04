using MediatR;
using SchoolUser.Application.Mediator.AccessModuleMediator.Queries;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Handlers
{
    public class GetAllAccessModulesHandler : IRequestHandler<GetAllAccessModulesQuery, IEnumerable<AccessModule>?>
    {
        private readonly IAccessModuleRepository _accessModuleRepository;

        public GetAllAccessModulesHandler(IAccessModuleRepository accessModuleRepository)
        {
            _accessModuleRepository = accessModuleRepository;
        }

        public async Task<IEnumerable<AccessModule>?> Handle(GetAllAccessModulesQuery request, CancellationToken cancellationToken)
        {
            return await _accessModuleRepository.GetAllAsync();
        }
    }
}