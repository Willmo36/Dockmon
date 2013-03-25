using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace DeskNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.noteWindow.Source = new Uri("https://drive.google.com/keep/");
        }

        #region hide script errors http://stackoverflow.com/questions/1298255/how-do-i-suppress-script-errors-when-using-the-wpf-webbrowser-control

        public void HideScriptErrors(WebBrowser wb, bool Hide)
        {

            FieldInfo browserInfo = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            object browser = browserInfo.GetValue(wb);
            browser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, browser, new object[] { Hide });
        }

        private void noteWindow_Navigated(object sender, NavigationEventArgs e)
        {
            HideScriptErrors((WebBrowser)sender, true);
        }
        #endregion

        private void dockRight_Click(object sender, RoutedEventArgs e)
        {
            AppBarFunctions.SetAppBar(this, ABEdge.Right);
        }

        private void dockLeft_Click(object sender, RoutedEventArgs e)
        {
            AppBarFunctions.SetAppBar(this, ABEdge.Left);
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void noDock_Click(object sender, RoutedEventArgs e)
        {
            AppBarFunctions.SetAppBar(this, ABEdge.None);
        }

        private void trello_Click(object sender, RoutedEventArgs e)
        {
            this.noteWindow.Source = new Uri("http://trello.com");
        }

        private void keep_Click(object sender, RoutedEventArgs e)
        {
            this.noteWindow.Source = new Uri("https://drive.google.com/keep/");
        }
         

    }

}
