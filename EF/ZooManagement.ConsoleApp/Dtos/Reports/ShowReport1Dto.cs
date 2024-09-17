using ZooManagement.ConsoleApp.Dtos.Animals;

namespace ZooManagement.ConsoleApp.Dtos.Reports;

public class ShowReport1Dto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<ShowAnimalDto> Animals { get; set; }
}