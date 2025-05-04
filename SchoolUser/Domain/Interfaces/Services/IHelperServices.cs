namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IHelperServices
    {
        int CalculateAge(DateTime dateOfBirth);
        Task<string> CreateUserSerialTag(string UserType);
    }
}