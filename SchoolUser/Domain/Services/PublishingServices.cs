using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.DTOs;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;
using SchoolUser.Application.Mediator.StudentMediator.Queries;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Services
{
    public class PublishingServices : IPublishingServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _subcriptionConnectionString;
        private readonly string _queueName_annual_record;
        private readonly string _queueName_monthly_report;
        private readonly string _queueName_daily_checklist;
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly ILogger<IPublishingServices> _logger;

        public PublishingServices(IConfiguration configuration, ISender sender, IReturnValueConstants returnValueConstants, ILogger<IPublishingServices> logger)
        {
            _configuration = configuration;
            _subcriptionConnectionString = _configuration.GetValue<string>("ServiceBus:SubscriptionConnectionString")!;
            _queueName_annual_record = _configuration.GetValue<string>("ServiceBus:AnnualRecordAttendanceQueueName")!;
            _queueName_monthly_report = _configuration.GetValue<string>("ServiceBus:MonthlyReportAttendanceQueueName")!;
            _queueName_daily_checklist = _configuration.GetValue<string>("ServiceBus:DailyCheckListAttendanceQueueName")!;
            _sender = sender;
            _returnValueConstants = returnValueConstants;
            _logger = logger;

        }

        public async Task<bool> PublishDailyAttendanceCheckListService()
        {
            try
            {
                DayOfWeek today = DateTime.Now.DayOfWeek;

                if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday)
                {
                    return true;
                }

                ServiceBusClient? client = new ServiceBusClient(_subcriptionConnectionString);
                ServiceBusSender? sender = client.CreateSender(_queueName_daily_checklist);

                string? serializedMessage = JsonSerializer.Serialize("PublishDailyAttendanceCheckList");
                byte[]? messageBody = Encoding.UTF8.GetBytes(serializedMessage);

                ServiceBusMessage? message = new ServiceBusMessage(messageBody);
                await sender.SendMessageAsync(message);

                await sender.CloseAsync();

                _logger.LogInformation("PublishDailyAttendanceCheckListService: Success");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("PublishdailyAttendanceCheckListService: Failed");
                throw new BusinessRuleException(string.Format(_returnValueConstants.PUBLISH_ATTENDANCE_FAILED, ex));
            }
        }

        public async Task<bool> PublishMonthlyAttendanceReportService()
        {
            try
            {
                ServiceBusClient? client = new ServiceBusClient(_subcriptionConnectionString);
                ServiceBusSender? sender = client.CreateSender(_queueName_monthly_report);

                string? serializedMessage = JsonSerializer.Serialize("PublishMonthlyAttendanceReport");
                byte[]? messageBody = Encoding.UTF8.GetBytes(serializedMessage);

                ServiceBusMessage? message = new ServiceBusMessage(messageBody);
                await sender.SendMessageAsync(message);

                await sender.CloseAsync();

                _logger.LogInformation("PublishMonthlyAttendanceReportService: Success");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("PublishMonthlyAttendanceReportService: Failed");
                throw new BusinessRuleException(string.Format(_returnValueConstants.PUBLISH_ATTENDANCE_FAILED, ex));
            }
        }

        public async Task<bool> PublishAnnualAttendanceRecordsService(StudentToBePublishedDto? dto)
        {
            try
            {
                ServiceBusClient? client = new ServiceBusClient(_subcriptionConnectionString);
                ServiceBusSender? sender = client.CreateSender(_queueName_annual_record);

                List<StudentToBePublishedDto> toBePublished = new List<StudentToBePublishedDto>();

                if (dto != null)
                {
                    toBePublished.Add(dto);
                }
                else
                {
                    IEnumerable<Student>? students = await _sender.Send(new GetAllStudentsQuery());

                    foreach (var student in students!)
                    {
                        User? user = await _sender.Send(new GetUserByIdQuery(student.UserId));
                        ClassCategory? classCategory = await _sender.Send(new GetClassCategoryByIdQuery((Guid)student.ClassCategoryId!));

                        StudentToBePublishedDto studentPublishedDto = new StudentToBePublishedDto()
                        {
                            StudentName = user.FullName,
                            StudentId = student.Id.ToString(),
                            ClassName = classCategory?.Code,
                            ClassId = student.ClassCategoryId.ToString(),
                            EmailAddress = user.EmailAddress
                        };

                        toBePublished.Add(studentPublishedDto);
                    }
                }

                string? serializedMessage = JsonSerializer.Serialize(toBePublished);
                byte[]? messageBody = Encoding.UTF8.GetBytes(serializedMessage);

                ServiceBusMessage? message = new ServiceBusMessage(messageBody);
                await sender.SendMessageAsync(message);

                await sender.CloseAsync();

                _logger.LogInformation("PublishAnnualAttendanceReportService: Success");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("PublishAnnualAttendanceReportService: Failed");
                throw new BusinessRuleException(string.Format(_returnValueConstants.PUBLISH_ATTENDANCE_FAILED, ex));
            }
        }

    }
}