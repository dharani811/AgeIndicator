using DK.AgeIndicator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace AgeIndicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new AgeController();
            this.Left = DK.AgeIndicator.Properties.Settings.Default.Left;
            this.Top = DK.AgeIndicator.Properties.Settings.Default.Top;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuItem closeForm = new MenuItem();
            closeForm.Header = "Close";
            closeForm.Click += CloseForm_Click;
            ContextMenu cm = new ContextMenu();
            cm.Items.Add(closeForm);
            this.ContextMenu = cm;
        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            DK.AgeIndicator.Properties.Settings.Default.Top = this.Top;
            DK.AgeIndicator.Properties.Settings.Default.Left = this.Left;
            DK.AgeIndicator.Properties.Settings.Default.Save();
        }
    }
}
