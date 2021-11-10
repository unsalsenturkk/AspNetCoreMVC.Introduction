using AspNetCoreMVC.Introduction.Entities;
using System.Collections.Generic;

namespace AspNetCoreMVC.Introduction
{
    public class EmployeeListViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<string> cities { get; set; }
    }
}