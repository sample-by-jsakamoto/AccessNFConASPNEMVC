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
#if DEBUG
                FileName = "cmd",
                Arguments = "/c dir %windir%",
#else
                FileName = "ls",
                Arguments = "-l /home/pi",
#endif

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
