using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Inventory
    {

        private List<Item> inventory = new List<Item>();


        public List<Item> GetInventory()
        {
            return inventory;
        }

        public void DeleteItem(int ID)
        {
            // Szuka przedmiotu na podstawie jego ID.
            Item itemToRemove = inventory.FirstOrDefault(item => item.Id == ID);
            if (itemToRemove != null)
            {
                // Usunięcie przedmiotu z listy, jeśli istnieje.
                inventory.Remove(itemToRemove);
                
            }
            else
            {
                // Komunikat, gdy lista jest już pusta lub przedmiot nie istnieje.
                Console.WriteLine("Nie znaleziono przedmiotu o podanym ID.");
            }
        }

        public void ShowALL()
        {
            foreach (Item item in inventory)
            {
                Console.WriteLine($"{item.Name},{item.Price},{item.Quantity}");
            }
        }

        public void SortBy(String Type)
        {
            foreach( Item item in inventory)
            {
                if(item.Type == Type)
                {
                    Console.WriteLine($"Name:{item.Name}, Price:{item.Price}, Type:{item.Type}, Quantity{item.Quantity}");
                }
            }
        }

        public void SortName(String Name)
        {
            foreach (Item item in inventory)
            {
                if (item.Name.ToUpper() == Name.ToUpper())
                {
                    Console.WriteLine($"Name:{item.Name}, Price:{item.Price}, Type:{item.Type}, Quantity{item.Quantity}");
                }
            }
        }

    }
}

