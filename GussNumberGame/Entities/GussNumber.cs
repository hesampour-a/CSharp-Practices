namespace GussNumberGame.Entities;

public class GussNumber(UI Ui)
{
    private int GoalNumber { get; set; } = new Random().Next(1, 100);
    public int TryCount { get; private set; } = 0;
    public bool IsWin { get; private set; } = false;


    void Play()
    {
        TryCount++;
        int number = Ui.GetNumberFromUser();

        if (GoalNumber < number)
            Ui.Print($"number {number} is grater than the goal");
        if (GoalNumber > number)
            Ui.Print($"number {number} is smaller than the goal");
        if (GoalNumber == number)
        {
            IsWin = true;
            Ui.Print($"you win with {TryCount} tries!");
        }
    }

    public void Start()
    {
        while (!IsWin)
        {
            Play();
        }
    }
}