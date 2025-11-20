using System;
using System.Windows.Forms;
using LastMinuteTours.Services;

namespace LastMinuteTours.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ITourService tourService = new InMemoryStorage();
            Application.Run(new MainForm(tourService));
        }
    }
}
