using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public Product Product { get; set; } = new();
        public int Count { get; set; }
        public DateTime Date;
    }
}