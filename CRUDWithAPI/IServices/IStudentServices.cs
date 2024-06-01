using CRUDWithAPI.Models;

namespace CRUDWithAPI.IServices
{
    public interface IStudentServices
    {
        List<Student> GetAll();
        Student GetById(string id);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(string id);

    }
}
