using SchoolUser.Application.Constants.Interfaces;
using static SchoolUser.Application.Constants.Enums.FunctionalEnum;

namespace SchoolUser.Contract.Constants.Main
{
    public class ValidationConstants : IValidationConstants
    {
        public HashSet<string> ValidPositions { get; } = new HashSet<string>
        {
            Positions.Admin.ToString(),
            Positions.Teacher.ToString(),
            Positions.Student.ToString()
        };

        public HashSet<string> ValidGenders { get; } = new HashSet<string>
        {
            Genders.Male.ToString(),
            Genders.Female.ToString()
        };

        public HashSet<string> ValidServiceStatuses { get; } = new HashSet<string>
        {
            ServiceStatus.Permanent.ToString(),
            ServiceStatus.Contract.ToString(),
            ServiceStatus.Internship.ToString()
        };

        public HashSet<string> ValidResponsibilityTypes { get; } = new HashSet<string>
        {
            ResponsibilityType.Batch.ToString(),
            ResponsibilityType.Subject.ToString(),
            ResponsibilityType.School.ToString()
        };

        public HashSet<string> ValidExitReasons { get; } = new HashSet<string>
        {
            ExitReason.Graduated.ToString(),
            ExitReason.Moved.ToString(),
            ExitReason.Removed.ToString()
        };

    }
}