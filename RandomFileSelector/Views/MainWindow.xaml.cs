using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomFileSelector
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Workspace.SetDefaultWorkspace(); //This gives color values to static fields that the MainWindow is bound to.
            InitializeComponent();
        }
        //Yes I know the following code dosn't belong here for pure MVVM. 
        //This is a simple solution for now.
        //I am working on a borderless window style that would migrate all of this into a seperate class by overriding the default window chrome 
        //As this is a simple project, a simple light-weight implementation to achieve desired function is just fine.
        #region Title Bar Event Handlers
        private void MinimizeButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        private void CloseButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }
        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            { }
        }
        #endregion
    }
}
