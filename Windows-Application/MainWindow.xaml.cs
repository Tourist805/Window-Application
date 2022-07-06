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
using Engine.ViewModel;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Engine.Models;

namespace Windows_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Session _session = new Session();
        private string _receivedID = "";
        public MainWindow()
        {
            InitializeComponent();

            DataContext = _session;
            
        }

        private void OnClick_SearchByID(object sender, RoutedEventArgs e)
        {
            _session.SetUserByID(userId_txt.Text);
        }
    }
  
}
