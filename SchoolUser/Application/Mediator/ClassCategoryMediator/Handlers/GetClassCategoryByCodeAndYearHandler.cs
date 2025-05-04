using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Handlers
{
    public class GetClassCategoryByCodeAndYearHandler : IRequestHandler<GetClassCategoryByCodeAndYearQuery, ClassCategory?>
    {
        private readonly IClassCategoryRepository _classRepository;

        public GetClassCategoryByCodeAndYearHandler(IClassCategoryRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ClassCategory?> Handle(GetClassCategoryByCodeAndYearQuery request, CancellationToken cancellationToken)
        {
            return await _classRepository.GetByCodeAndYearAsync(request.code, request.year);
        }
    }
}