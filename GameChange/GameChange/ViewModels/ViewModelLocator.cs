using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GameChange.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameChange.ViewModels
{    public enum NavigatePage
    {
        CreateView = 1,
        ListView = 2,
        HomeView = 3,
    }
    public class ViewModelLocator
    {        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<EmployeesViewModel>();

            if (!SimpleIoc.Default.IsRegistered<IEmployeeService>())
                SimpleIoc.Default.Register<IEmployeeService>(() => new EmployeeService());
        }
        public EmployeesViewModel EmployeesVM
        {
            get { return ServiceLocator.Current.GetInstance<EmployeesViewModel>(); }
        }

    }
}
