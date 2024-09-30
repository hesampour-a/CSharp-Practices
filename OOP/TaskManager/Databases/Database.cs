using TaskManager.Entities;

namespace TaskManager.Databases;

public class Database
{
    public List<Project> Projects { get; set; } = [];
    public List<Entities.Task> Tasks { get; set; } = [];


    public void AddProject(Project project)
    {
        int newItemId = Projects.Count() > 0 ? Projects.Last().Id + 1 : 1;

        Projects.Add(new Project
        {
            Id = newItemId,
            Title = project.Title,
            //Tasks = project.Tasks
        });
    }
    public void AddTask(Entities.Task task)
    {
        int newItemId = Tasks.Count() > 0 ? Tasks.Last().Id + 1 : 1;

        Tasks.Add(new Entities.Task
        {
            Id = newItemId,
            Title = task.Title,
            EstimatedTime = task.EstimatedTime,
            Status = task.Status

        });
    }

    public List<Entities.Task> GetTaskForProject(int projectId)
    {
        var tasksOfProject = new List<Entities.Task>();
        foreach (var task in Tasks)
        {
            if (task.ProjectId == projectId)
                tasksOfProject.Add(task);
        }
        return tasksOfProject;
    }

    public Project? GetProjectById(int projectId)
    {
        foreach (var project in Projects)
        {
            if (project.Id == projectId)
                return project;
        }

        return null;
    }

    public Entities.Task? GetTaskById(int taskId)
    {
        foreach (var task in Tasks)
        {
            if (task.Id == taskId)
                return task;
        }
        return null;
    }

}