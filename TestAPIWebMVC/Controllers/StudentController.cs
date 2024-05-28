using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestAPIWebMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            // Call API để lấy cái List fake vừa nãy
            // Bước 1 Tạo requestURL
            string requestURL = "https://localhost:7047/api/Students/get-fake-list";
            // Bước 2 Lấy response (body) 
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(requestURL).Result;  
            // Bước 3: Ép kiểu nếu cần để thu được kết quả cần thiết
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(response);
            // Bước 4: Sử dụng dữ liệu thu được
            return View(students);
        }
    }
    public class Student
    {
        public string MaSV { get; set; }
        public string Name { get; set; }
        public int Khoa { get; set; }
    }
}
