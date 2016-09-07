using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RandomFileSelector
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //This Creates the ViewModel and exposes it to the View's (MainWindow) DataContext
            MainWindow view = new MainWindow();
            view.DataContext = new RandomFileSelectorViewModel();
            view.Show();
        }
    }
}
