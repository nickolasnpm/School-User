namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IValidationServices
    {
        bool BeAValidDate(DateTime date);
        bool IsGenderValid(string gender);
        bool IsPositionValid(string position);
        bool IsServiceStatusValid(string status);
        bool BeValidPassword(string password);
        bool IsTeacherResponsibilityTypeValid(string resType);
        bool IsStudentExitReasonValid(string reason);
    }
}