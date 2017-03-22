using System;
using System.ServiceProcess;

namespace PrecizeSoft.GetPdfOnline.Api.WinService
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                // If run as Console Application
                WindowsService service = new WindowsService();
                service.TestServiceInConsole();
            }
            else
            {
                // If run as Windows Service
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new WindowsService()
                };
                ServiceBase.Run(ServicesToRun);
            }

        }
    }
}