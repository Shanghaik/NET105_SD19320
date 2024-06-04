using CRUDWithAPI.IServices;
using CRUDWithAPI.Models;
using Newtonsoft.Json;

namespace CRUDWithAPI.Services
{
    public class StudentServices : IStudentServices
    {
        HttpClient client;
        public StudentServices()
        {
            client = new HttpClient();
        }
        public List<Student> GetAll()
        {
            // Lấy requestURL
            string requestURL = @"https://localhost:7294/api/Student/get-all-student";
            // Lấy response
            var response = client.GetStringAsync(requestURL).Result;
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(response);
            return students;
        }
        public bool CreateStudent(Student student)
        {
            string requestURL = @"https://localhost:7294/api/Student/create-student";
            var response = client.PostAsJsonAsync(requestURL, student).Result;
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public bool DeleteStudent(string id)
        {
            string requestURL = @$"https://localhost:7294/api/Student/delete-student-by-id?id={id}";
            var response = client.DeleteAsync(requestURL).Result;
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public Student GetById(string id)
        {
            string requestURL = @$"https://localhost:7294/api/Student/get-by-id?id={id}";
            var response = client.GetStringAsync(requestURL).Result;
            Student student = JsonConvert.DeserializeObject<Student>(response);
            return student;
        }

        public bool UpdateStudent(Student student)
        {
            string requestURL = @"https://localhost:7294/api/Student/update-student";
            var response = client.PutAsJsonAsync(requestURL, student).Result;
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
