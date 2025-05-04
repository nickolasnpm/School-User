using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Contract.Constants.Main
{
    public class ReturnValueConstants : IReturnValueConstants
    {
        public string SUCCESSFUL_GET { get; } = "{0} get successfully";
        public string SUCCESSFUL_CREATE { get; } = "{0} created successfully";
        public string SUCCESSFUL_UPDATE { get; } = "{0} updated successfully";
        public string SUCCESSFUL_DELETE { get; } = "{0} deleted successfully";
        public string SUCCESSFUL_VERIFICATION { get; } = "Email Verification Success";
        public string SUCCESSFUL_CHANGE_PASSWORD { get; } = "Password Change Success";
        public string SUCCESSFUL_RESET_PASSWORD { get; } = "Password Reset Success";


        public string FAILED_QUERY { get; } = "Failed to query {0}";
        public string FAILED_GET { get; } = "Failed to get {0}";
        public string FAILED_CREATE { get; } = "Failed to create {0}";
        public string FAILED_UPDATE { get; } = "Failed to update {0}";
        public string FAILED_DELETE { get; } = "Failed to delete {0}";
        public string FAILED_VERIFICATION { get; } = "Failed to verify {0}";
        public string FAILED_CHANGED_PASSWORD { get; } = "Failed to change {0} password";
        public string FAILED_RESET_PASSWORD { get; } = "Failed to reset {0} password";
        public string FAILED_CACHING_OBJECT { get; } = "Failed caching object {0}";


        public string ITEM_CANNOT_BE_NULL { get; } = "{0} cannot be null";
        public string ITEM_DOES_NOT_EXIST { get; } = "{0} does not exist";
        public string ITEM_ALREADY_EXIST { get; } = "{0} already exists";


        public string NO_CHANGES_MADE { get; } = "No changes has been made to {0}";
        public string CODE_INVALID { get; } = "{0} Code Invalid";
        public string CODE_EXPIRED { get; } = "{0} Code Expired";
        public string CODE_STILL_ACTIVE { get; } = "The verification window is still active. This operation is unnecessary";
        public string WRONG_VERIFICATION_NO { get; } = "Wrong Verification Number";
        public string WRONG_OLD_PASSWORD { get; } = "Old Password is Wrong!";

        public string ACCOUNT_NOT_VERIRIED { get; } = "The account is not verified. Please check your email";
        public string ACCOUNT_HAS_BEEN_VERIFIED { get; } = "The account has been verified. This operation is unnecessary";
        public string USER_NOT_ACTIVE { get; } = "User is not active. Please contact your administrator.";

        public string EMAIL_SENDING_ERROR { get; } = "Wrong in sending {0}";

        public string DATABASE_OPERATION_FAILED { get; } = "Database operation failed";

        public string PUBLISH_ATTENDANCE_SUCCESS { get; } = "Attendance sync successfully";
        public string PUBLISH_ATTENDANCE_FAILED { get; } = "Attendance sync failed: {0}";


    }
}