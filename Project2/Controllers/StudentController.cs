using Microsoft.AspNetCore.Mvc;
using Project2.Data;
using Project2.Models;

namespace Project2.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var studentList = _context.Students.ToList();
            return View(studentList);
        }
        public IActionResult Upsert(int? id)
        {
            Student student = new Student();
            if (id == null) return View(student);

            student = _context.Students.Find(id.GetValueOrDefault());
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
