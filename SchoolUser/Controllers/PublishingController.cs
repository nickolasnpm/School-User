using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/SchoolUser/[Controller]")]
    public class PublishingController : ControllerBase
    {
        private readonly IPublishingServices _publishingServices;
        public PublishingController(IPublishingServices publishingServices)
        {
            _publishingServices = publishingServices;
        }

        [HttpPost("PublishDailyAttendanceCheckList")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PublishDailyAttendanceCheckList()
        {
            try
            {
                return Ok(await _publishingServices.PublishDailyAttendanceCheckListService());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PublishMonthlyAttendanceReport")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PublishMonthlyAttendanceReport()
        {
            try
            {
                return Ok(await _publishingServices.PublishMonthlyAttendanceReportService());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PublishAnnualAttendanceRecords")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PublishAnnualAttendanceRecords()
        {
            try
            {
                return Ok(await _publishingServices.PublishAnnualAttendanceRecordsService(null));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}