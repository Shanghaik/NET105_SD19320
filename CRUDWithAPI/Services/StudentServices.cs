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
            throw new NotImplementedException();
        }

        

        public Student GetById(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
