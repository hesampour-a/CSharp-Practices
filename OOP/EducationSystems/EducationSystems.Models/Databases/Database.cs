using EducationSystems.Models.Interfaces;
using EducationSystems.Models.Models.Courses;
using EducationSystems.Models.Models.Exams;
using EducationSystems.Models.Models.Students;
using EducationSystems.Models.Models.Teachers;

namespace EducationSystems.Models.Databases;

public class Database
{
    public List<Teacher> Teachers { get; } = [];
    public List<Student> Students { get; } = [];
    public List<Course> Courses { get; } = [];
    public List<Exam> Exams { get; } = [];

    public static int CalculateNewItemId<T>(List<T> list) where T : HasIdClass
        => list.Count > 0 ? list.Last().Id + 1 : 1;


    public void RegisterTeacher(Teacher teacher)
    {
        if (Teachers.Any(t => t.PersonalId == teacher.PersonalId))
            throw new Exception("there is a teacher with this Presonal ID!");
        teacher.Id = CalculateNewItemId(Teachers);
        Teachers.Add(teacher);

    }
    public void RegisterStudent(Student student)
    {
        if (Students.Any(s => s.NationalCode == student.NationalCode))
            throw new Exception("a student with this national code alredy exists");

        student.Id = CalculateNewItemId(Students);
        Students.Add(student);
    }
    public void RegisterCourse(Course course)
    {
        course.Id = CalculateNewItemId(Courses);
        Courses.Add(course);
    }

    public void RegisterExam(Exam exam)
    {
        exam.Id = CalculateNewItemId(Exams);
        Exams.Add(exam);
    }

    public Student GetStudentById(int studentId)
    {
        return Students.FirstOrDefault(_ => _.Id == studentId)
            ?? throw new Exception($"student with id {studentId} not found");
    }
    public Teacher GetTeacherById(int teacherId)
    {
        return Teachers.FirstOrDefault(_ => _.Id == teacherId)
           ?? throw new Exception($"teacher with id {teacherId} not found");
    }


}
