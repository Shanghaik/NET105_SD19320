using CRUDWithAPI.IServices;
using CRUDWithAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUDWithAPI.Controllers
{
    public class StudentController : Controller
    {

        IStudentServices _services;
        public StudentController(IStudentServices services)
        {
            _services = services;
        }
        public IActionResult GetAll()
        {
            var students = _services.GetAll();
            return View(students);
        }
        public IActionResult Details(string id)
        {
            var student = _services.GetById(id);
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Student student = new Student() // tạo mới để thêm sẵn data sang view thôi nhé =))
            {
                Name = "Khánh đẹp trai",
                Description = "Đã đẹp trai lại còn đấm đau",
                Email = "cudamngancan@gmail.com",
                Major = "Call Chicken"
            };
            return View(student);
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _services.CreateStudent(student);
            return RedirectToAction("GetAll");
        }
        public IActionResult Edit(string id)
        {
            var editItem = _services.GetById(id);
            return View(editItem);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var editItem = _services.UpdateStudent(student);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            _services.DeleteStudent(id);
            return RedirectToAction("GetAll");
        }
        // Lưu ý:
        // 1. Bên API sử dụng phương thức nào thì call qua phương thức đó
        // VD Bên API (PUT) => Call = PutAsJsonAsync
        // 2. Razor view chỉ support 2 phương thức HTTP là GET và Post nên bên
        // Controller (MVC) Chúng ta chỉ đánh dấu các acrion là GET và POST
    }
}
