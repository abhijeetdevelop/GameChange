using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GameChange.Models;
using Newtonsoft.Json;

namespace GameChange.Services
{
    class EmployeeService : IEmployeeService
    {
        private const string apiUrl = "http://dummy.restapiexample.com/api/v1/";
        public async Task<bool> CreateEmployee(Employee employee)
        {   
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            try
            {
                response = await client.PostAsync(apiUrl + "create", content);
                return true;
            }
            catch (Exception ex)
            {                
                var a = ex.StackTrace;
                return false;
            }
        }

        public async Task<ObservableCollection<Employee>> GetAllEmployeeData()
        {
            ObservableCollection<Employee> employeesCollection = new ObservableCollection<Employee>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            try
            {
                response = await client.GetAsync(apiUrl + "employees");
                string result = response.Content.ReadAsStringAsync().Result;
                employeesCollection = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(result);
            }
            catch (Exception ex)
            {
                var a = ex.StackTrace;
            }
            return employeesCollection;
        }

        public Task<Employee> GetEmployeeDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}
