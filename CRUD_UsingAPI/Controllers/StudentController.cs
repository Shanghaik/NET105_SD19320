using CRUD_UsingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_UsingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        AppDBContext _context = new AppDBContext();
        // Getall -HttpGet
        [HttpGet("get-all-student")]
        public ActionResult GetAll() // Lấy ra tất cả danh sách Student
        {
            return Ok(_context.Students.ToList());
        }
        // GetbyID -HTTPGet
        [HttpGet("get-by-id")]
        public ActionResult GetById(string id) // Lấy ra tất cả danh sách Student
        {
            var student = _context.Students.Find(id);
            if(student!=null) return Ok(student);
            else return NotFound(); 
        }
        // Create (truyền vào qua bodyrequest - HttpPost
        [HttpPost("create-student")]
        public ActionResult Create(Student student)
        {
            _context.Students.Add(student); _context.SaveChanges();
            return Ok();
        }
        // Update HttpPut (Post)
        [HttpPut("update-student")]
        public ActionResult Update(Student student) // Dữ liệu vào này là được lấy ở trên form
        {
            var updateItem = _context.Students.Find(student.Id); // Lấy ra đối tượng cần được update
            updateItem.Name = student.Name; updateItem.Description = student.Description;
            updateItem.Email= student.Email; updateItem.Major= student.Major;
            _context.Students.Update(updateItem); _context.SaveChanges();
            return Ok();
        }
        // Delete HttpDelete (Get)
        [HttpDelete("delete-student-by-id")]
        public ActionResult Delete(string id) // Dữ liệu vào này là được lấy ở trên form
        {
            var deleteItem = _context.Students.Find(id); // Lấy ra đối tượng cần được update
            _context.Students.Remove(deleteItem); 
            _context.SaveChanges();
            return Ok();
        }
    }
}
