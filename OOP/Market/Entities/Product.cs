using System.Numerics;

namespace Market.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public BigInteger Price { get; set; }
        public BigInteger AverageSale { get; set; } = 0;
    }
}