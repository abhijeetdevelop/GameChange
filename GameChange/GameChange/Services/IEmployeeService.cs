using GameChange.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace GameChange.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets all employees details
        /// </summary>     
        /// <returns></returns>
        Task<ObservableCollection<Employee>> GetAllEmployeeData();

        /// <summary>
        /// Gets single employees details
        /// </summary>     
        /// <returns></returns>
        Task<Employee> GetEmployeeDetail(int id);

        /// <summary>
        /// Create Employee
        /// </summary>     
        /// <returns></returns>
        Task<bool> CreateEmployee(Employee employee);
    }
}
