using AspNetCoreMVC.Introduction.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC.Introduction.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello from first application";
        }

        public ViewResult Index2()
        {
            return View();
        }

        public ViewResult Index3()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,FirstName="Ünsal",LastName="Şentürk",CityId=34},
                new Employee{Id=2,FirstName="Yunus",LastName="Şentürk",CityId=34},
                new Employee{Id=3,FirstName="Emre",LastName="Şentürk",CityId=34}
            };

            List<string> cities = new List<string> { "İstanbul", "Ankara" };

            var model = new EmployeeListViewModel
            {
                Employees = employees,
                cities = cities
            };
            return View(model);
        }

        public StatusCodeResult Index4()
        {
            //return StatusCode(200);
            return Ok();
        }

        public StatusCodeResult Index5()
        {
            //return StatusCode(400);
            //return BadRequest();
            
            return NotFound();
        }
    }
}
