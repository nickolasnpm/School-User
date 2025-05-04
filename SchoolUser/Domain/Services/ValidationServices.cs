using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Domain.Services
{
    public class ValidationServices : IValidationServices
    {
        private readonly IValidationConstants _validationConstants;

        public ValidationServices(IValidationConstants validationConstants)
        {
            _validationConstants = validationConstants;
        }

        public bool BeAValidDate(DateTime date) => date.Year < DateTime.Now.Year;

        public bool IsGenderValid(string gender) =>
            _validationConstants.ValidGenders.Contains(gender.ToLower(), StringComparer.OrdinalIgnoreCase);

        public bool IsPositionValid(string position) =>
            _validationConstants.ValidPositions.Contains(position, StringComparer.OrdinalIgnoreCase);

        public bool IsServiceStatusValid(string status) =>
            _validationConstants.ValidServiceStatuses.Contains(status.ToLower(), StringComparer.OrdinalIgnoreCase);

        public bool BeValidPassword(string password)
        {
            return password.Any(char.IsLetter) &&
                   password.Any(char.IsDigit) &&
                   password.Any("!@#$%^&*_-.".Contains) &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower);
        }

        public bool IsTeacherResponsibilityTypeValid(string resType) =>
           _validationConstants.ValidResponsibilityTypes.Contains(resType.ToLower(), StringComparer.OrdinalIgnoreCase);

        public bool IsStudentExitReasonValid(string reason) =>
            _validationConstants.ValidExitReasons.Contains(reason.ToLower(), StringComparer.OrdinalIgnoreCase);

    }
}