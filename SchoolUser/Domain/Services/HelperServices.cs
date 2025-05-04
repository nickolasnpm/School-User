using MediatR;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Services
{
    public class HelperServices : IHelperServices
    {
        private readonly ISender _sender;

        public HelperServices(ISender sender)
        {
            _sender = sender;
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - dateOfBirth.Year;
            return age;
        }

        public async Task<string> CreateUserSerialTag(string UserType)
        {
            List<User>? listOfUsers = (List<User>?)await _sender.Send(new GetAllUsersQuery());
            int serialNumber = listOfUsers!.Count + 1;
            string serialTag = serialNumber.ToString("D6");

            switch (UserType)
            {
                case "student":
                    return $"S{serialTag}";
                case "teacher":
                    return $"T{serialTag}";
                case "admin":
                    return $"A{serialTag}";
                default:
                    break;
            }

            return "";
        }
    }
}