using TaskManager.Entities;
using TaskManager.Databases;

var database = new Database();

Run();






void Run()
{
    while (true)
    {
        Console.WriteLine("Enter Your Choice : ");
        Console.WriteLine("1. Add New Project");
        Console.WriteLine("2. Show All Projects");
        Console.WriteLine("3. Change Task Staus");
        string choice = Console.ReadLine()!;

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter Count Of Projects :");
                int projectCount = int.Parse(Console.ReadLine()!);
                for (int i = 0; i < projectCount; i++)
                {
                    var newProject = new Project();
                    Console.WriteLine($"Enter Project #{i + 1} Title :");
                    newProject.Title = Console.ReadLine()!;
                    Console.WriteLine($"Enter Count Of Project #{i + 1} Tasks");
                    int tasksCount = int.Parse(Console.ReadLine()!);
                    for (int j = 0; j < tasksCount; j++)
                    {
                        newProject.GetNewTaskFromUser(database);
                    }
                    database.AddProject(newProject);
                }
                break;

            case "2":
                foreach (var prj in database.Projects)
                {
                    Project.PrintProject(prj, database);
                }
                break;

            case "3":
                Console.WriteLine("Enter Project Id :");
                int projectId = int.Parse(Console.ReadLine()!);
                var project = database.GetProjectById(projectId);
                if (project == null)
                {
                    Console.WriteLine("Project Not Found");
                    break;
                }
                Project.PrintProject(project, database);
                Console.WriteLine("Enter Task Id :");
                int taskId = int.Parse(Console.ReadLine()!);
                var task = database.GetTaskById(taskId);
                if (task == null)
                {
                    Console.WriteLine("Task Not Found");
                    break;
                }
                Console.WriteLine("Enter Task Status :");
                Console.WriteLine("1. Move Forward");
                Console.WriteLine("2. Move Backward");
                string status = Console.ReadLine()!;
                switch (status)
                {
                    case "1":
                        task.MoveForwardStatus();
                        break;
                    case "2":
                        task.MoveBackwardStatus();
                        break;
                    default:
                        break;
                }


                break;




            default:
                break;
        }



    }
}