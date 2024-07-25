namespace TaskManager.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Statuses Status { get; set; } = Statuses.waiting;
        public int EstimatedTime { get; set; }
        public int ProjectId { get; set; }

        public static bool ValidateEstimatedTime(int estimatedTime) => estimatedTime < 5;

        public void MoveForwardStatus()
        {

            switch (Status)
            {
                case Statuses.waiting:
                    Status = Statuses.prosprocessing;
                    break;
                case Statuses.prosprocessing:
                    Status = Statuses.done;
                    break;
                default:
                    break;
            }
        }
        public void MoveBackwardStatus()
        {
            switch (Status)
            {
                case Statuses.prosprocessing:
                    Status = Statuses.waiting;
                    break;
                case Statuses.done:
                    Console.WriteLine("Task Already Done and Cant Change Status");
                    break;
                default:
                    break;
            }
        }
        public static void PrintTask(Task task)
        {
            Console.WriteLine($"Id : {task.Id} * Title : {task.Title} * Status : {task.Status} * Estimated Time : {task.EstimatedTime} * Project Id : {task.ProjectId}");
        }


    }
}

public enum Statuses
{
    waiting = 1,
    prosprocessing,
    done
}