using ZooManagement.ConsoleApp.Dtos.Partitions;

namespace ZooManagement.ConsoleApp.Dtos.Reports;

public class ShowReport2Dto
{
    public string Name { get; set; }
    public int PartitionsCount { get; set; }
    public List<ShowPartitionForReport2Dto> Partitons { get; set; }
}