using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    // Klasa Item reprezentuje pojedynczy przedmiot w sklepie.
    internal class Item
    {
        // Właściwość Id identyfikuje unikalnie przedmiot.
        public int Id { get; set; }

        // Właściwość Name przechowuje nazwę przedmiotu.
        public string Name { get; set; }

        // Właściwość Quantity określa ilość danego przedmiotu dostępnego w sklepie.
        public int Quantity { get; set; }

        // Właściwość Price określa cenę przedmiotu.
        public double Price { get; set; }
    }
}
