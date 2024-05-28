using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // 2 phương thức
        // Lấy ra danh sách các student
        [HttpGet("get-fake-list")]
        public ActionResult GetFakeStudents()
        {
            // Tạo ra 1 List Fake   
            List<Student> list = new List<Student>()
            {
                    new Student(){MaSV = "PH123", Name="KhanhPG", Khoa = 17},
                    new Student(){MaSV = "PH124", Name="DungNA", Khoa = 12},
                    new Student(){MaSV = "PH111", Name="TienNH", Khoa = 15}
            };
            // Vì Phương thức này trả về 1 ActionResult => Nên để truyền được list này vào response thì ta
            // Phải sử dụng nó như argument
            return Ok(list);
        }
        // Thử lấy ra 1 đối tượng
        [HttpPost("get-fake-item")] // Cái này viết ra cho vui thôi chứ đừng làm =)))
        public ActionResult GetStudent(string MaSV, List<Student> students)
        {
            var student = students.FirstOrDefault(p => p.MaSV == MaSV);
            return Ok(student);
        }
    }
    public class Student
    {
        public string MaSV { get; set; }
        public string Name { get; set; }
        public int Khoa { get; set; }
    }
}
