using TaskManager.Databases;

namespace TaskManager.Entities;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    //public List<Task> Tasks { get; set; } = [];

    public void GetNewTaskFromUser(Database database)
    {
        string title;
        int estimatedTime;

        Console.WriteLine("Enter New Task Name :");
        title = Console.ReadLine()!;
        do
        {
            Console.WriteLine("Enter New Task Estimated Time :");
            estimatedTime = int.Parse(Console.ReadLine()!);
        } while (!Task.ValidateEstimatedTime(estimatedTime));



        AddTask(new Task
        {
            Title = title,
            EstimatedTime = estimatedTime,
            ProjectId = Id,
            Status = Statuses.waiting

        }, database);


    }
    void AddTask(Task task, Database database)
    {
        database.AddTask(task);
    }

    public static void PrintProject(Project project, Database database)
    {
        var tasks = database.GetTaskForProject(project.Id);
        int doneTasksCount = 0;
        int waitingTasksCount = 0;
        int prosprocessingTasksCount = 0;
        int doneTasksTime = 0;
        int waitingTasksTime = 0;
        int prosprocessingTasksTime = 0;
        foreach (var task in tasks)
        {
            if (task.Status == Statuses.done)
            {
                doneTasksCount++;
                doneTasksTime += task.EstimatedTime;
            }
            else if (task.Status == Statuses.waiting)
            {
                waitingTasksCount++;
                waitingTasksTime += task.EstimatedTime;
            }
            else if (task.Status == Statuses.prosprocessing)
            {
                prosprocessingTasksCount++;
                prosprocessingTasksTime += task.EstimatedTime;
            }
        }

        // int totalTime = doneTasksTime + waitingTasksTime + prosprocessingTasksTime;

        //decimal doneTasksTimePercentage =  /totalTime;
        // decimal remainingTasksTimePercentage = (totalTime - doneTasksTime) / totalTime;


        Console.WriteLine($"Id : {project.Id} * Title : {project.Title} * Done Tasks : {doneTasksCount} * Waiting Tasks : {waitingTasksCount} * Prosprocessing Tasks : {prosprocessingTasksCount} * Total Tasks : {tasks.Count} * Remaining Tasks Time Percentage ");
        foreach (var task in tasks)
            Task.PrintTask(task);

    }

}

