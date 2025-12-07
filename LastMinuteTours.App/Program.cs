using System;
using System.Windows.Forms;
using LastMinuteTours.Services;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LastMinuteTours.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var serilogger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Seq("http://localhost:5341", apiKey: "KVq9gLWrMukpOXflrG4J")
                .CreateLogger();

            var loggerFactory = new LoggerFactory()
                .AddSerilog(serilogger);



            ApplicationConfiguration.Initialize();

            ITourService tourService = new InMemoryStorage(loggerFactory);
            Application.Run(new MainForm(tourService));
            
        }
    }
}
