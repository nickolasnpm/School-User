using FluentValidation;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Application.Validations
{
    public class UpdateStudentsDtoValidator : AbstractValidator<StudentsBulkUpdateDto>
    {
        private readonly IValidationServices _validationServices;
        public UpdateStudentsDtoValidator(IValidationServices validationServices)
        {
            _validationServices = validationServices;

            RuleFor(x => x.StudentIds).NotEmpty().WithMessage("StudentIds is required");
            RuleFor(x => x.EntranceYear).NotEmpty().WithMessage("EntranceYear is required");
            RuleFor(x => x.EstimatedExitYear).NotEmpty().WithMessage("EstimatedExitYear is required");

            RuleFor(x => x.ExitReason)
                    .Must(x => _validationServices.IsStudentExitReasonValid(x!))
                    .When(x => x.ExitReason != null)
                    .WithMessage("Invalid Exit Reason");

            RuleFor(x => x.ClassCategoryId).NotNull().WithMessage("ClassCategoryId is required");
        }
    }
}