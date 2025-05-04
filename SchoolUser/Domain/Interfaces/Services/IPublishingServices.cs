using SchoolUser.Application.DTOs;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IPublishingServices
    {
        Task<bool> PublishDailyAttendanceCheckListService();
        Task<bool> PublishMonthlyAttendanceReportService();
        Task<bool> PublishAnnualAttendanceRecordsService(StudentToBePublishedDto? dto);
    }
}