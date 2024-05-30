using CRUDWithAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUDWithAPI.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client = new HttpClient();
        public IActionResult GetAll()
        {
            // Lấy requestURL
            string requestURL = @"https://localhost:7294/api/Student/get-all-student";
            // Lấy response
            var response = client.GetStringAsync(requestURL).Result;
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(response);
            return View(students);
        }
        public IActionResult Details(string id)
        {
            string requestURL = $@"https://localhost:7294/api/Student/get-by-id?id={id}";
            // Lấy response
            var response = client.GetStringAsync(requestURL).Result;
            Student student = JsonConvert.DeserializeObject<Student>(response);
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
            string requestURL = "https://localhost:7294/api/Student/create-student";
            // Lấy response
            // var studentContent = JsonConvert.SerializeObject(student);  
            var response = client.PostAsJsonAsync(requestURL, student).Result;
            // Vid phương thức PostAsJsonAsync yêu cầu 2 tham số là requestURL và 1 chuỗi Json nên phải ép kiểu
            return RedirectToAction("GetAll");
        }
    }
}
