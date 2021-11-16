using AspNetCoreMVC.Introduction.Entities;
using AspNetCoreMVC.Introduction.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace AspNetCoreMVC.Introduction.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello from first application";
        }

        [HandleException(ViewName = "DividByZeroError",ExectionType = typeof(DivideByZeroException))]
        [HandleException(ViewName = "Error", ExectionType = typeof(SecurityException))]
        public ViewResult Index2()
        {
            throw new SecurityException();
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

        public RedirectResult Index6()
        {
            return Redirect("/Home/Index3");
        }
        public IActionResult Index7()
        {
            // En çok kullanılan
            return RedirectToAction("Index2");
        }
        public IActionResult Index8()
        {
            // Startup.cs dosyasındaki route ismi
            return RedirectToRoute("default");
        }

        public JsonResult Index9()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,FirstName="Ünsal",LastName="Şentürk",CityId=34},
                new Employee{Id=2,FirstName="Yunus",LastName="Şentürk",CityId=34},
                new Employee{Id=3,FirstName="Emre",LastName="Şentürk",CityId=34}
            };

            return Json(employees);
        }

        public IActionResult RazorDemo()
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

        //model binding
        public JsonResult Index10(string key)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,FirstName="Ünsal",LastName="Şentürk",CityId=34},
                new Employee{Id=2,FirstName="Yunus",LastName="Şentürk",CityId=34},
                new Employee{Id=3,FirstName="Emre",LastName="Şentürk",CityId=34}
            };

            if (String.IsNullOrEmpty(key))
            {
                return  Json(employees);
            }
            var result = employees.Where(e => e.FirstName.ToLower().Contains(key));

            return Json(result);
        }

        public ViewResult EmployeeForm()
        {

            return View();
        }

        public string RouteData(int id)
        {
            return id.ToString();
        }
    }
}
