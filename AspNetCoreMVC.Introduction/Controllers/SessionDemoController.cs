using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC.Introduction.Controllers
{
    public class SessionDemoController : Controller
    {
        public string Index()
        {
            HttpContext.Session.SetInt32("age", 32);
            HttpContext.Session.SetString("name", "Ünsal");
            return "Session created";
        }

        public string GetSessions()
        {
            return String.Format("Hello {0},you are {1}", HttpContext.Session.GetString("name"), HttpContext.Session.GetInt32("age"));
        }
    }
}
