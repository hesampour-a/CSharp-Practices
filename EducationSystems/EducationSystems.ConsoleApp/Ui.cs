using EducationSystems.Models.Models.Exams;
using EducationSystems.Models.Models.Students;

namespace EducationSystems.ConsoleApp;

internal static class Ui
{
    public static int GetIntegerFromUser(string message)
    {
        Console.WriteLine(message);
        bool isNumberValid = false;
        int number = 0;
        while (!isNumberValid)
        {
            isNumberValid = int.TryParse(Console.ReadLine(), out int result);
            if (!isNumberValid)
                Console.WriteLine("Please Enter a correct number");

            if (isNumberValid)
                number = result;
        }
        return number;
    }
    public static double GetDoubleFromUser(string message)
    {
        Console.WriteLine(message);
        bool isNumberValid = false;
        double number = 0;
        while (!isNumberValid)
        {
            isNumberValid = double.TryParse(Console.ReadLine(), out double result);
            if (!isNumberValid)
                Console.WriteLine("Please Enter a correct number");

            if (isNumberValid)
                number = result;
        }
        return number;
    }


    public static DateTime GetDateFromUser(string message)
    {
        Console.WriteLine(message);
        bool isNumberValid = false;
        DateTime dateTime = new();
        while (!isNumberValid)
        {
            isNumberValid = DateTime.TryParse(Console.ReadLine(), out DateTime result);
            if (!isNumberValid)
                Console.WriteLine("Please Enter a correct Date");

            if (isNumberValid)
                dateTime = result;
        }
        return dateTime;
    }

    public static string GetStringFromUser(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine()!;
    }
    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static void ShowStudent(this StudentDto student)
    {
        Console.WriteLine(student.Name);
        Console.WriteLine(student.Average);
        Console.WriteLine("***");
    }
    public static void ShowExamDto(this ExamDto exam)
    {
        Console.WriteLine(exam.CourseId);
        Console.WriteLine(exam.CourseTitle);
        Console.WriteLine(exam.StudentsAverage);
        Console.WriteLine(exam.StudentsCount);
        Console.WriteLine("***");

    }




}
