using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithAngular.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public List<Customer> Get()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, FirsName = "Ünsal", LastName = "Şentürk" },
                new Customer { Id = 2, FirsName = "Ali", LastName = "Bak" },
                new Customer { Id = 3, FirsName = "Ayşe", LastName = "Oku" }
            };
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
    }
}

