using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCB.Hermes.Contract.External;
using WebApiLab.Store;

namespace WebApiLab.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HermesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HermesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        [HttpGet("variables/test")]
        public IActionResult Test()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            userId = _httpContextAccessor.HttpContext.User.Identities.FirstOrDefault(x => x.IsAuthenticated)?.Name;
            if(userId != null)
            {
                return Ok();
            }
            return Unauthorized();
        }
        
        [HttpGet("variables")]
        public IEnumerable<Variable> GetVariables()
        {
            return Data.GetInstance.Variables;
        }

        [HttpGet("dispatches/staging")]
        public IEnumerable<string> GetRecipientIds([FromQuery] int? limit = null)
        {
            return Data.GetInstance.Recipients.Select(x => x.ScbId);
        }

        [HttpPost("dispatches")]
        public IEnumerable<Recipient> GetRecipientsWithValues(StagedRecipients stagedRecipients, [FromQuery] bool isPreview)
        {
            return Data.GetInstance.Recipients;
        }

        [HttpPost("dispatches/callback")]
        public void DispatchCallBack(HermesResponse hermesResponse)
        {
            Console.WriteLine($"DispatchId: {hermesResponse.DispatchId} => {hermesResponse.Step} - {hermesResponse.State} - {hermesResponse.Message}");
        }

        [HttpGet("dispatches/test")]
        public IActionResult GetTest()
        {
            return Ok();
        }
    }
}