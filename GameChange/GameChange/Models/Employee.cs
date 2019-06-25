using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameChange.Models
{
   public class Employee : BindableBase
    {
        private int id;
        private string employee_name;
        private string profile_image;
        private double employee_salary;
        private int employee_age;
        [JsonProperty ("id")]
        public int Id { get => id; set { id = value; RaisePropertyChanged("Id"); } }
        [JsonProperty("employee_name")]

        public string Name { get => employee_name; set { employee_name = value; RaisePropertyChanged("Name"); } }
        [JsonProperty("employee_salary")]

        public double Salary { get => employee_salary; set { employee_salary = value; RaisePropertyChanged("Salary"); } }
        [JsonProperty("profile_image")]

        public string Image { get => profile_image; set { profile_image = value; RaisePropertyChanged("Image"); } }
        [JsonProperty("employee_age")]

        public int Age { get => employee_age; set { employee_age = value; RaisePropertyChanged("Image"); } }
    }
}
