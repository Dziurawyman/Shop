namespace Shop
{
    // Klasa ItemService zarządza przedmiotami w sklepie.
    internal class ItemService
    {
            // Lista przechowująca wszystkie przedmioty.
            private List<Item> items = new List<Item>();

            // Metoda dodaje nowy przedmiot do listy przedmiotów.
            public void AddNewItem(string name, double price, int quantity)
            {
                // Tworzenie nowego obiektu Item z odpowiednimi właściwościami.
                Item item = new Item
                {
                    Id = items.Count + 1, // Ustala ID na podstawie liczby już istniejących przedmiotów.
                    Name = name.ToLower(), // Nazwa przedmiotu w formacie małych liter.
                    Price = price, // Ustalenie ceny przedmiotu.
                    Quantity = quantity // Ustalenie ilości przedmiotu.
                };

                // Dodanie nowego przedmiotu do listy.
                items.Add(item);
            }

        // Metoda dodaje nowy przedmiot do inwentarza gracza.
        public void AddNewItemToPlayer(Item IfOldItem, string name, double price, string type, int quantity, Person person, Inventory inventory)
        {
            Item item;

            if (IfOldItem != null)
            {
                // Create a new item based on the existing item.
                item = new Item
                {
                    Id = inventory.GetInventory().Count + 1,
                    Name = IfOldItem.Name,
                    Type = IfOldItem.Type,
                    Price = IfOldItem.Price,
                    Quantity = IfOldItem.Quantity,
                };
            }
            else
            {
                // Create a new item using the provided parameters.
                item = new Item
                {
                    Id = inventory.GetInventory().Count + 1,
                    Name = name.ToLower(),
                    Type = type,
                    Price = price,
                    Quantity = quantity
                };
            }

            // Add the new item directly to the player's inventory.
            inventory.GetInventory().Add(item);
        }


        // Metoda zwraca listę wszystkich przedmiotów.
        public List<Item> GetItems()
            {
                return items; // Zwraca listę przedmiotów.
            }

            // Metoda wyświetla szczegóły jednego przedmiotu.
            public void PrintItem(Item item)
            {
                try
                {
                    // Sprawdzenie, czy przekazany obiekt item nie jest null.
                    if (item != null)
                    {
                        // Wyświetlenie szczegółów przedmiotu.
                        Console.WriteLine($"Id: {item.Id}, Name: {item.Name},Type: {item.Type} Price: {item.Price}, Quantity: {item.Quantity}.");
                    }
                    else
                    {
                        // Rzucenie wyjątku ArgumentNullException, jeśli obiekt item jest null.
                        throw new ArgumentNullException(nameof(item), "Item cannot be null.");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    // Obsługa wyjątku: wyświetlenie komunikatu z wyjątku.
                    Console.WriteLine(ex.Message);
                }
            }

            // Metoda wyświetla szczegóły wszystkich przedmiotów w liście.
            public void PrintItems()
            {
                foreach (Item item in items)
                {
                // Wyświetlenie szczegółów każdego przedmiotu.
                PrintItem(item);
                }
            }

            // Metoda czyszczy listę przedmiotów.
            public void ClearItemList()
            {
                items.Clear(); // Usunięcie wszystkich przedmiotów z listy.
            }

            // Metoda usuwa przedmiot na podstawie jego ID.
            public void DeleteItem(int ID)
            {
                // Szuka przedmiotu na podstawie jego ID.
                Item itemToRemove = items.FirstOrDefault(item => item.Id == ID);
                if (items.Count > 0)
                {
                    // Usunięcie przedmiotu z listy, jeśli istnieje.
                    items.Remove(itemToRemove);
                }
                else
                {
                    // Komunikat, gdy lista jest już pusta.
                    Console.WriteLine("Lista jest już pusta, nie można usunąć więcej przedmiotów.");
                }
            }

            public double GetPrice(Item item)
            {
                return (item.Price);
            }
        
    }
}