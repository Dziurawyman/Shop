using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class MoneyOriented
    {
        public void ShopBuy(Person person, PersonService personService, List<Item> items, ItemService itemService, List<Item> inventory)
        {
            Console.WriteLine("=============[BUY]=============");
            Console.WriteLine("Welcome to the SHOP, what would you like to buy?");

            // Display all items with their prices and IDs
            foreach (Item item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Price: {item.Price}, Available: {item.Quantity}");
            }

            Console.WriteLine("Choose the item you want to buy by entering its ID.");

            // Read the chosen ID and validate input
            if (int.TryParse(Console.ReadLine(), out int chosenId) && chosenId > 0 && chosenId <= items.Count)
            {
                // Adjust for zero-based indexing
                Item selectedItem = items[chosenId - 1];

                // Check if the selected item is available
                if (selectedItem.Quantity > 0)
                {
                    // Check if the person has enough money
                    if (person.Money >= selectedItem.Price)
                    {
                        // Check if the item is already in the inventory
                        Item existingItem = inventory.FirstOrDefault(item => item.Id == selectedItem.Id);

                        if (existingItem != null)
                        {
                            // If the item is already in the inventory, increase its quantity
                            existingItem.Quantity += 1;
                            Console.WriteLine($"You already have {existingItem.Name} in your inventory. Quantity increased to {existingItem.Quantity}.");
                        }
                        else
                        {
                            // If the item is not in the inventory, add it
                            Item newItem = new Item
                            {
                                Id = selectedItem.Id,
                                Name = selectedItem.Name,
                                Price = selectedItem.Price,
                                Quantity = 1 // Add with initial quantity 1
                            };
                            inventory.Add(newItem);
                            Console.WriteLine($"You have purchased {newItem.Name} for {newItem.Price}. Quantity: {newItem.Quantity}.");
                        }

                        // Deduct the item's price from the person's money
                        personService.RemoveMoney(person, selectedItem.Price);

                        // Decrease the quantity of the item in the shop
                        selectedItem.Quantity--;

                        Console.WriteLine($"Remaining money: {person.Money}");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money.");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, this item is out of stock.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid item ID.");
            }
        }



        public void ShopSell(Person person, PersonService personService, List<Item> items, ItemService itemService, List<Item> inventory, Inventory inventorySe)
        {
            // Witaj w sklepie, co chcesz sprzedać?
            // wyświetl wszystkie ity gracza z cenami i ID
            //Wybirz co chcesz sprzedać podając jego ID:
            //Pobierz ID, i odejmij quantiti -1
            //jeśli quantiti przedmiotu jest równe 0 usuń go z EQ.
            // dodaj użytkownikowi pieniądze.

            Console.WriteLine("=============[SELL]=============");
            Console.WriteLine("Witaj, co planujesz sprzedać?");
            foreach( Item item in inventory)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Price: {item.Price}, Quantity {item.Quantity}");
            }
            Console.WriteLine("Chose item that you will want to sell.");
            int.TryParse(Console.ReadLine(), out int chosenId);
            chosenId -= 1;
            if ( chosenId != null)
            {
                if (chosenId <= inventory.Count || chosenId !<=0)
                {
                    Item wybrany = inventory[chosenId];
                    wybrany.Quantity -= 1;
                    if( wybrany.Quantity <= 0)
                    {
                        inventorySe.DeleteItem(chosenId+1);
                    }
                    person.Money += wybrany.Price;
                    Console.WriteLine($"Sprzedałeś {wybrany.Name} za cene {wybrany.Price} obecny stan konta {person.Money}");
                }
                else
                {
                    Console.WriteLine("Wybierz Id");
                }
            }
            else
            {
                Console.WriteLine("Wybierz element ekwipunku");
            }


        }
    }
}
