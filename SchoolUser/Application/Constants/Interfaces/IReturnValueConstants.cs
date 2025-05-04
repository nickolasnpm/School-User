namespace SchoolUser.Application.Constants.Interfaces
{
    public interface IReturnValueConstants
    {
        string SUCCESSFUL_GET { get; }
        string SUCCESSFUL_CREATE { get; }
        string SUCCESSFUL_UPDATE { get; }
        string SUCCESSFUL_DELETE { get; }
        string SUCCESSFUL_VERIFICATION { get; }
        string SUCCESSFUL_CHANGE_PASSWORD { get; }
        string SUCCESSFUL_RESET_PASSWORD { get; }

        string FAILED_QUERY { get; }
        string FAILED_GET { get; }
        string FAILED_CREATE { get; }
        string FAILED_UPDATE { get; }
        string FAILED_DELETE { get; }
        string FAILED_VERIFICATION { get; }
        string FAILED_CHANGED_PASSWORD { get; }
        string FAILED_RESET_PASSWORD { get; }
        string FAILED_CACHING_OBJECT { get; }


        string ITEM_CANNOT_BE_NULL { get; }
        string ITEM_DOES_NOT_EXIST { get; }
        string ITEM_ALREADY_EXIST { get; }


        string NO_CHANGES_MADE { get; }
        string CODE_INVALID { get; }
        string CODE_EXPIRED { get; }
        string CODE_STILL_ACTIVE { get; }
        string WRONG_VERIFICATION_NO { get; }
        string WRONG_OLD_PASSWORD { get; }

        string ACCOUNT_NOT_VERIRIED { get; }
        string ACCOUNT_HAS_BEEN_VERIFIED { get; }

        string USER_NOT_ACTIVE { get; }

        string EMAIL_SENDING_ERROR { get; }

        string DATABASE_OPERATION_FAILED { get; }

        public string PUBLISH_ATTENDANCE_SUCCESS { get; }
        public string PUBLISH_ATTENDANCE_FAILED { get; }
    }
}