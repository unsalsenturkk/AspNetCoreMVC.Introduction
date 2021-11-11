using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC.Introduction.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        [Route("")]
        [Route("save")]
        [Route("~/save")] //önündeki herşeyi iptal et
        public string Save()
        {
            return "Saved";
        }
        [Route("delete/{id?}")]
        public string Deleted(int id=0)
        {
            return String.Format("Deleted {0}", id);
        }
        [Route("update")]
        public string Update()
        {
            return "Updated";
        }
    }
}
