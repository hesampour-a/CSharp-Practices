using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class NewClass(string name, int id)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}