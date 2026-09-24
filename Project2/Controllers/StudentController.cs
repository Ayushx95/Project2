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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Student student)
        {
            bool emailExists = _context.Students
                .Any(s => s.Email == student.Email && s.Id != student.Id);

            if (emailExists)
            {
                ModelState.AddModelError(
                    "Email",
                    "This Email is already Registered"
                );
            }
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            if (student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                _context.Students.Update(student);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id, bool confirm = false)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            if (confirm)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(student);
        }
        public IActionResult Details(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }
    }
}

