using EducationSystems.Models.Models.Courses;
using EducationSystems.Models.Models.ExamResults;
using EducationSystems.Models.Models.Exams;
using EducationSystems.Models.Models.Students;

namespace EducationSystems.Models.Mapper;

public static class Mapper
{
    public static StudentDto CreateStudentDto(this Student student)
    {
        return new StudentDto
        {
            Name = student.Name,
            Average = CalculateAverageForStudent(student.ExamResults)
        };
    }

    public static ExamDto GetExamDto(this Exam exam, List<Course> courses, List<Student> students)
    {
        double studentsAverage = 0;
        int count =0;

        foreach (var student in students) 
        {
            studentsAverage += CalculateAverageForStudent(student.ExamResults.Where(_ => _.ExamId == exam.Id).ToList());
            count++;
        }

        studentsAverage /= count;

        int studentsCount = 0;
        foreach (var student in students) { 
            if(student.ExamResults.Any(_=>_.ExamId == exam.Id)) studentsCount++;
        }

        return new ExamDto
        {
            CourseId = exam.CourseId,
            CourseTitle = courses.Find(_ => _.Id == exam.CourseId)!.Title,
            StudentsAverage = studentsAverage,
            StudentsCount = studentsCount

        };
    }

    static double CalculateAverageForStudent(List<ExamResult> examResults)
    {
        double sum = 0;

        foreach (var examResult in examResults)
        {
            sum += examResult.Grade;
        }
        return examResults.Count == 0 ? 0 : sum / examResults.Count;
    }
}
