namespace Mountaineering.Entities
{
    public class Ascent
    {

        public int Id { get; set; }
        public int MountainId { get; set; }
        public int MountaineeringId { get; set; }
        public DateTime Date { get; set; }

        public void PrintAscent()
        {
            Console.WriteLine($"Id: {Id}, MountainId: {MountainId}, MountaineeringId: {MountaineeringId}, Date: {Date}");
        }
    }
}