namespace SchoolUser.Application.Constants.Enums
{
    public class FunctionalEnum
    {
        public enum ResponsibilityType
        {
            Batch,
            Subject,
            School
        }

        public enum Positions
        {
            Admin,
            Student,
            Teacher
        }

        public enum Genders
        {
            Male,
            Female
        }

        public enum ServiceStatus
        {
            Permanent,
            Contract,
            Internship
        }

        public enum ExitReason
        {
            Graduated,
            Moved,
            Removed
        }
    }
}