using System;
using Microsoft.Extensions.Configuration;

namespace WebApiLab.Store
{
    public class AppInfo
    {
        private IConfiguration Configuration { get; }
        public string MachineName { get; }
        public string Version { get; }

        public AppInfo(IConfiguration configuration)
        {
            Configuration = configuration;
            MachineName = Environment.MachineName;
            Version = Configuration["version"];
        }
    }
}