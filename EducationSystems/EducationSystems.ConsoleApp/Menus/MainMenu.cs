using EducationSystems.ConsoleApp.Interfaces;
using EducationSystems.Models.Models.Courses;
using EducationSystems.Models.Models.EducationSystems;
using EducationSystems.Models.Models.Exams;
using EducationSystems.Models.Models.Students;
using EducationSystems.Models.Models.Teachers;

namespace EducationSystems.ConsoleApp.Menus;

internal class MainMenu(EducationSystem educationSystem) : IMenu
{
    public Dictionary<string, Action> MenuItems { get; set; } = new Dictionary<string, Action>();

    public void AddMenuItems()
    {
        MenuItems.Add("Add Student", AddStudent);
        MenuItems.Add("Add Teacher", AddTeacher);
        MenuItems.Add("Add Course", AddCourse);
        MenuItems.Add("Add Exam", RegisterExam);
        MenuItems.Add("Add Exam Result", AddExamResult);
        MenuItems.Add("Show Student Average", ShowStudentAverageById);
        MenuItems.Add("Show All Students", ShowStudentsOrderByAverage);
        MenuItems.Add("Show Teacher functionality", ShowTeacherFunctionalityById);
    }

    void AddStudent()
    {
        var newStudent = new Student(Ui.GetStringFromUser("Enter student name : "), Ui.GetStringFromUser("Enter National Code :"));
        educationSystem.Database.RegisterStudent(newStudent);
    }

    void AddTeacher()
    {
        educationSystem.Database.RegisterTeacher
            (new Teacher(
                Ui.GetStringFromUser("Enter Teacher name :"),
                Ui.GetIntegerFromUser("Enter Personal Code :")));
    }

    void AddCourse()
    {
        educationSystem.Database.RegisterCourse
            (new Course(
                Ui.GetStringFromUser("Enter Title")));
    }

    void RegisterExam()
    {
        educationSystem.Database.RegisterExam
            (new Exam(
                Ui.GetIntegerFromUser("Enter course ID :"),
                Ui.GetIntegerFromUser("Enter Teacher ID :"),
                Ui.GetDateFromUser("Enter Date :")));
    }
    void AddExamResult()
    {
        educationSystem.RegisterExamResult
            (
            Ui.GetIntegerFromUser("Enter Student ID:"),
            Ui.GetIntegerFromUser("Enter Exam ID : "),
            Ui.GetDoubleFromUser("Enter Grade"));
    }

    void ShowStudentAverageById()
    {
        var studentDto = educationSystem.ShowStudent
              (educationSystem.Database.GetStudentById
              (
                  Ui.GetIntegerFromUser("Enter Student ID:")));

        studentDto.ShowStudent();
    }

    void ShowStudentsOrderByAverage()
    {
        educationSystem.ShowStudents().ForEach(_ => _.ShowStudent());
    }

    void ShowTeacherFunctionalityById()
    {
        var examDtos = educationSystem.TeacherFunctionality
             (educationSystem.Database.GetTeacherById(
                 Ui.GetIntegerFromUser("Enter teacher ID :")));
        examDtos.ForEach(_=>_.ShowExamDto());
    }


    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems).Start();
    }
}
