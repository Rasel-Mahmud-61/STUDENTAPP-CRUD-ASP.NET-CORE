using CRUDOFSTUDENT.Data;
using CRUDOFSTUDENT.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDOFSTUDENT.Controllers
{
    public class StudentController : Controller
    {

        public readonly ApplicationDbContext _Context;
        public StudentController(ApplicationDbContext context)
        {
            _Context = context;
        }

        //display form 

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {

            if (ModelState.IsValid)
            {

                _Context.HELLOAllStudents.Add(student);
                _Context.SaveChanges();

                return RedirectToAction("Index");


            }
            return View(student);

        }
        [HttpGet]
        public IActionResult Index()
        {

            var students = _Context.HELLOAllStudents.ToList();
            return View(students);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var student = _Context.HELLOAllStudents.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();

            }
            return View(student);

        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {

                _Context.HELLOAllStudents.Update(student);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _Context.HELLOAllStudents.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {

                NotFound();

            }
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _Context.HELLOAllStudents.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                _Context.HELLOAllStudents.Remove(student);
                _Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}