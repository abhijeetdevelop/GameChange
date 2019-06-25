using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GameChange.Models;
using GameChange.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameChange.ViewModels
{
    public class EmployeesViewModel : ViewModelBase
    {
        private readonly IEmployeeService employeeService = null;

        private Employee selectedEmployee = new Employee();
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees { get => employees; set { employees = value; RaisePropertyChanged("Employees"); } }
        public Employee SelectedEmployee { get => selectedEmployee; set { selectedEmployee = value; RaisePropertyChanged("SelectedEmployee"); } }
        public ICommand ViewcellTappedCommand { get; set; }
        public ICommand SaveRecordCommand { get; set; }
        
        public EmployeesViewModel(IEmployeeService service)
        {
            employeeService = service;
            GetEmployeesDetails();
            ViewcellTappedCommand = new RelayCommand<object>(ViewCellTapped);
            SaveRecordCommand = new RelayCommand(SaveRecord);
        }

        private async void SaveRecord()
        {
            if (SelectedEmployee.Name == string.Empty || SelectedEmployee.Name == null)
                return;
            if (await employeeService.CreateEmployee(SelectedEmployee))
            {
                if (SelectedEmployee.Id == 0)                
                    await App.Current.MainPage.DisplayAlert("Success", "Employee has been created successfully.", "OK");                   
                else
                    await App.Current.MainPage.DisplayAlert("Success", "Employee has been modified successfully.", "OK");
                NavigationService.GetNavigationService.NavigateTo(NavigatePage.HomeView.ToString(), null);
            }
        }

        private void ViewCellTapped(object obj)
        {
            SelectedEmployee = obj as Employee;
            NavigationService.GetNavigationService.NavigateTo(NavigatePage.CreateView.ToString(),null);
        }

        private async void GetEmployeesDetails()
        {
            Employees = await employeeService.GetAllEmployeeData();
        }
    }
}
