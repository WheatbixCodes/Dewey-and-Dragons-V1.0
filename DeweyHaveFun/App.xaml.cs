using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DeweyHaveFun
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int min_spl_time = 2500;

        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splash = new SplashScreen();
            splash.Show();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            base.OnStartup(e);
            MainWindow main = new MainWindow();
            timer.Stop();
            int remaining = min_spl_time - (int)timer.ElapsedMilliseconds;
            if (remaining > 0)
                Thread.Sleep(remaining);
            splash.Close();
        }


        

    }
}
