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

namespace Windows_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Session _session = new Session();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = _session;
        }

        private void OnClick_SearchByID(object sender, RoutedEventArgs e)
        {
            
            _session.SearchByID();
        }
    }
    public enum Party
    {
        Indepentent,
        Federalist,
        DemocratRepublican,
    }

    public class Employee : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaiseProperChanged();
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaiseProperChanged();
            }
        }

        private bool wasReElected;

        public bool WasReElected
        {
            get { return wasReElected; }
            set
            {
                wasReElected = value;
                RaiseProperChanged();
            }
        }

        private Party affiliation;

        public Party Affiliation
        {
            get { return affiliation; }
            set
            {
                affiliation = value;
                RaiseProperChanged();
            }
        }

        public static ObservableCollection<Employee> GetEmployees()
        {
            var employees = new ObservableCollection<Employee>();

            employees.Add(new Employee()
            {
                Name = "Ali",
                Title = "Minister",
                WasReElected = true,
                Affiliation = Party.Indepentent
            });

            employees.Add(new Employee()
            {
                Name = "Ahmed",
                Title = "CM",
                WasReElected = false,
                Affiliation = Party.Federalist
            });

            employees.Add(new Employee()
            {
                Name = "Amjad",
                Title = "PM",
                WasReElected = true,
                Affiliation = Party.DemocratRepublican
            });

            employees.Add(new Employee()
            {
                Name = "Waqas",
                Title = "Minister",
                WasReElected = false,
                Affiliation = Party.Indepentent
            });

            employees.Add(new Employee()
            {
                Name = "Bilal",
                Title = "Minister",
                WasReElected = true,
                Affiliation = Party.Federalist
            });

            employees.Add(new Employee()
            {
                Name = "Waqar",
                Title = "Minister",
                WasReElected = false,
                Affiliation = Party.DemocratRepublican
            });

            return employees;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseProperChanged([CallerMemberName] string caller = "")
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

    }
}
