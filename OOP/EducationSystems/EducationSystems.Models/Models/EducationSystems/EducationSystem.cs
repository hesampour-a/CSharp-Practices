using EducationSystems.Models.Databases;
using EducationSystems.Models.Mapper;
using EducationSystems.Models.Models.ExamResults;
using EducationSystems.Models.Models.Exams;
using EducationSystems.Models.Models.Students;
using EducationSystems.Models.Models.Teachers;

namespace EducationSystems.Models.Models.EducationSystems;

public class EducationSystem
{
    public Database Database { get; set; } = new();

    public void RegisterExamResult(int studentId, int examId, double grade)
    {
        var student = Database.Students.FirstOrDefault(_ => _.Id == studentId)
            ?? throw new Exception($"student with id {studentId} not found");
        if (student.ExamResults.Any(_ => _.ExamId == examId))
            throw new Exception("the result for this exam is alredy recorded for this student");

        student.ExamResults.Add(new ExamResult(examId, grade));
    }

    public StudentDto ShowStudent(Student student) => student.CreateStudentDto();

    public List<StudentDto> ShowStudents(bool sorted = true)
    {
        var students = Database.Students.Select(_ => _.CreateStudentDto()).ToList();
        return sorted ? students.OrderByDescending(_ => _.Average).ToList() : students;
    }

    public List<ExamDto> TeacherFunctionality(Teacher teacher)
    {
        return Database.Exams.Where(_ => _.TeacherId == teacher.Id)
            .Select(_ => _.GetExamDto(Database.Courses, Database.Students)).ToList();
    }
}
