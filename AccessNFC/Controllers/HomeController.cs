using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace AccessNFC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var procStartInfo = new ProcessStartInfo
            {
                // set FileName = "ls" and Arguments = "~/*" will made available run on Raspberry Pi with XSP4 asp.net web server command, may be.
                FileName = "cmd",
                Arguments = "/c dir %windir%",

                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            var process = new Process { StartInfo = procStartInfo };
            process.Start();
            var outputStr = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return View((object)outputStr);
        }
    }
}
