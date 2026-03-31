using System;
using System.IO;
using System.Web;
using log4net;
using log4net.Config;

namespace AutoAdornos.Core.Services
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var logFolder = Server.MapPath("~/Logs");
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            XmlConfigurator.Configure();
        }
    }
}