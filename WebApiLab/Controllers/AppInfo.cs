using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiLab.Store;

namespace WebApiLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppInfoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AppInfoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public AppInfo GetAppInfo()
        {
            var appInfo = new AppInfo(_configuration);
            return appInfo;
        }
    }
}
