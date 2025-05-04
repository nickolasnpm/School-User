using MediatR;
using SchoolUser.Application.DTOs;

namespace SchoolUser.Application.Mediator.StudentMediator.Commands
{
    public record UpdateBulkStudentsCommand (StudentsBulkUpdateDto UpdateStudentsDto) : IRequest<bool>;
}