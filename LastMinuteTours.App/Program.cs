using System;
using System.Windows.Forms;
using LastMinuteTours.Entities;
using Microsoft.Extensions.Logging;
using Serilog;
using LastMinuteTours.Services;
using LastMinuteToursManager;
using DataBaseStorage;

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

            var tourService = new DataBaseStorage.DataBaseStorage();
            var tourManager = new TourManager(tourService, loggerFactory);
            Application.Run(new MainForm(tourManager));
            
            
        }
    }
}
