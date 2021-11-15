using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMVC.Introduction.Entities;
using AspNetCoreMVC.Introduction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMVC.Introduction.Pages.Studentp
{
    public class IndexModel : PageModel
    {
        public List<Student> Students{ get; set; }

        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Students = _context.Students.ToList();
        }

        [BindProperty]
        public Student Student{ get; set; }

        public IActionResult OnPost()
        {
            _context.Students.Add(Student);


            _context.SaveChanges();
            return RedirectToPage("/Studentp/Index");
        }
    }
}
