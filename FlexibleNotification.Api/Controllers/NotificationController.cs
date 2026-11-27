using FlexibleNotification.Domain.Interfaces;
using FlexibleNotification.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlexibleNotification.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationMessage message)
        {
            var result = await _notificationService.SendNotificationAsync(message);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        
        //[HttpPost("send-email")]
        //public async Task<IActionResult> SendEmailNotification([FromBody] NotificationMessage message)
        //{
        //    var result = await _notificationService.SendEmailNotificationAsync(message);
        //    return result.IsSuccess ? Ok(result) : BadRequest(result);
        //}

    }
}
