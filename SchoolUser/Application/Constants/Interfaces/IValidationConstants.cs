namespace SchoolUser.Application.Constants.Interfaces
{
    public interface IValidationConstants
    {
        HashSet<string> ValidPositions { get; }
        HashSet<string> ValidGenders { get; }
        HashSet<string> ValidServiceStatuses { get; }
        HashSet<string> ValidResponsibilityTypes { get; }
        HashSet<string> ValidExitReasons { get; }

    }
}