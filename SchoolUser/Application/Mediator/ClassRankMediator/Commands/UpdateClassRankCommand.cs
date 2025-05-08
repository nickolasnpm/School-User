using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Commands
{
    public record UpdateClassRankCommand(ClassRank ClassRank) : IRequest<ClassRank?>;
}