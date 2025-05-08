using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassRankMediator.Commands
{
    public record AddClassRankCommand(ClassRank ClassRank) : IRequest<ClassRank?>;
}