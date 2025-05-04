using System.Globalization;
using Hangfire;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using MediatR;
using Newtonsoft.Json;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;

namespace SchoolUser.Domain.Services
{
    public class HangfireServices
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _queueName_User = "user";
        private readonly string _queueName_Attendance = "attendance";
        private const string _hangfire_service_error = "Hangfire service operation error : ";

        public HangfireServices(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ConfigureHangfire()
        {
            SetCultureInfo();

            // User
            RecurringJob.AddOrUpdate("DeleteInActiveUsers", _queueName_User, () => DeleteInactiveUsersService(), Cron.Yearly, new RecurringJobOptions());
            RecurringJob.AddOrUpdate("DeleteUnregisterUsers", _queueName_User, () => DeleteUnregisteredUsersService(), Cron.Weekly, new RecurringJobOptions());
            RecurringJob.AddOrUpdate("AutoUpdateUsersAge", _queueName_User, () => AutoUpdateUsersAgeService(), Cron.Weekly, new RecurringJobOptions());

            // Attendance 
            RecurringJob.AddOrUpdate("PublishDailyAttendanceCheckList", _queueName_Attendance, () => PublishDailyAttendanceCheckListService(), Cron.Daily, new RecurringJobOptions());
            RecurringJob.AddOrUpdate("PublishMonthlyAttendanceReport", _queueName_Attendance, () => PublishMonthlyAttendanceReportService(), Cron.Monthly, new RecurringJobOptions());
            RecurringJob.AddOrUpdate("PublishAnnualAttendanceRecordService", _queueName_Attendance, () => PublishAnnualAttendanceRecordService(), Cron.Yearly, new RecurringJobOptions());

            // RecurringJob.AddOrUpdate("PublishDailyAttendanceCheckList", _queueName_Attendance, () => PublishDailyAttendanceCheckListService(), "*/5 * * * *", new RecurringJobOptions());
            // RecurringJob.AddOrUpdate("PublishMonthlyAttendanceReport", _queueName_Attendance, () => PublishMonthlyAttendanceReportService(), "*/5 * * * *", new RecurringJobOptions());
            // RecurringJob.AddOrUpdate("PublishAnnualAttendanceRecordService", _queueName_Attendance, () => PublishAnnualAttendanceRecordService(), "*/5 * * * *", new RecurringJobOptions());
        }

        #region User

        public async Task DeleteInactiveUsersService()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                ISender sender = scope.ServiceProvider.GetRequiredService<ISender>();
                await sender.Send(new DeleteInactiveUsersCommand());
            }
        }

        public async Task DeleteUnregisteredUsersService()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                ISender sender = scope.ServiceProvider.GetRequiredService<ISender>();
                await sender.Send(new DeleteUnregisteredUsersCommand());
            }
        }

        public async Task AutoUpdateUsersAgeService()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                ISender sender = scope.ServiceProvider.GetRequiredService<ISender>();
                await sender.Send(new AutoUpdateUsersAgeCommand());
            }
        }

        #endregion

        #region Attendance

        public async Task PublishDailyAttendanceCheckListService()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                IPublishingServices _publishingService = scope.ServiceProvider.GetRequiredService<IPublishingServices>();
                await _publishingService.PublishDailyAttendanceCheckListService();
            }
        }

        public async Task PublishMonthlyAttendanceReportService()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                IPublishingServices _publishingService = scope.ServiceProvider.GetRequiredService<IPublishingServices>();
                await _publishingService.PublishMonthlyAttendanceReportService();
            }
        }

        public async Task PublishAnnualAttendanceRecordService()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                IPublishingServices _publishingService = scope.ServiceProvider.GetRequiredService<IPublishingServices>();
                await _publishingService.PublishAnnualAttendanceRecordsService(null);
            }
        }

        #endregion

        private void SetCultureInfo()
        {
            CultureInfo? cultureInfo = new CultureInfo("en-US"); // Specify the desired culture, e.g., "en-US"
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            GlobalConfiguration.Configuration
                .UseSerializerSettings(new JsonSerializerSettings { Culture = cultureInfo });
        }
    }
}