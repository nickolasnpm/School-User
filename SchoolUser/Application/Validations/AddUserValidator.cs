using FluentValidation;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Application.Validations;

public class AddUserValidator : AbstractValidator<UserAddRequestDto>
{
    private readonly IValidationServices _validationServices;
    public AddUserValidator(IValidationServices validationServices)
    {

        _validationServices = validationServices;

        RuleFor(x => x.RegisterForRole)
            .NotEmpty().WithMessage("Position required")
            .Must(x => _validationServices.IsPositionValid(x)).WithMessage("Position invalid");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full Name is required.");

        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.MobileNumber)
            .NotEmpty().WithMessage("Mobile Number is required.")
            .Matches(@"^01[0-9]{8,9}$").WithMessage("Invalid mobile number.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required.")
            .Must(x => _validationServices.BeAValidDate(x)).WithMessage("Invalid date of birth");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required.")
            .Must(x => _validationServices.IsGenderValid(x)).WithMessage("Invalid gender");

        #region Student
        When(x => x.RegisterForRole == "student", () =>
        {
            RuleFor(x => x.EntranceYear)
                .NotEmpty().WithMessage("EntranceYear is required for students.");

            RuleFor(x => x.EstimatedExitYear)
                .NotEmpty().WithMessage("GraduatedYear is required for students.");

            RuleFor(x => x.ClassCategoryId)
                .NotEmpty().WithMessage("ClassId is required for students");
        });
        #endregion

        #region Teacher
        When(x => x.RegisterForRole == "teacher", () =>
        {
            RuleFor(x => x.ServiceStatus)
                .NotEmpty().WithMessage("ServiceStatus cannot be empty for teachers.")
                .Must(x => _validationServices.IsServiceStatusValid(x!)).WithMessage("Invalid Service Status");

            RuleFor(x => x.IsAvailable)
                .NotEmpty().WithMessage("Availability cannot be empty for teachers.");

        });
        #endregion

    }

}
