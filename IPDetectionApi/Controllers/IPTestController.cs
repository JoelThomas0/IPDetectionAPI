using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IPDetectionApi.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class IPTestController : ControllerBase
    {
        [HttpGet("verify")]
        public IActionResult VerifyIPDetection()
        {
            var allHeaders = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());

            var xForwardedFor = Request.Headers["X-Forwarded-For"].FirstOrDefault();
            var clientIp = xForwardedFor?.Split(',')[0]?.Trim()
                           ?? HttpContext.Connection.RemoteIpAddress?.ToString();

            return Ok(new
            {
                success = true,
                clientIP = clientIp,
                xForwardedForFull = xForwardedFor,
                xForwardedProto = Request.Headers["X-Forwarded-Proto"].FirstOrDefault(),
                xForwardedPort = Request.Headers["X-Forwarded-Port"].FirstOrDefault(),
                userAgent = Request.Headers["User-Agent"].FirstOrDefault(),
                remoteAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                allHeaders = allHeaders,
                timestamp = DateTime.UtcNow
            });
        }
    }
}
