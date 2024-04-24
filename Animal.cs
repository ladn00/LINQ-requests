using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_запросы_Animal
{
    class Animal
    {
        public string Name { get; set; }
        public string Poroda { get; set; }
        public DateTime Year { get; set; }
        public string Color { get; set; }

        public Animal(string Name, string Poroda, DateTime Year, string Color)
        {
            this.Name = Name;
            this.Poroda = Poroda;
            this.Year = Year;
            this.Color = Color;
        }
    }
}
