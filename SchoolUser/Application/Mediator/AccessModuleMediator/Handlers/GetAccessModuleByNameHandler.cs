using MediatR;
using SchoolUser.Application.Mediator.AccessModuleMediator.Queries;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.AccessModuleMediator.Handlers
{
    public class GetAccessModuleByNameHandler : IRequestHandler<GetAccessModuleByNameQuery, AccessModule?>
    {
        private readonly IAccessModuleRepository _accessModuleRepository;

        public GetAccessModuleByNameHandler(IAccessModuleRepository accessModuleRepository)
        {
            _accessModuleRepository = accessModuleRepository;
        }

        public async Task<AccessModule?> Handle(GetAccessModuleByNameQuery request, CancellationToken cancellationToken)
        {
            return await _accessModuleRepository.GetByNameAsync(request.name);
        }
    }
}