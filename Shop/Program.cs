using Shop;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Comands comands = new Comands();
        ItemService itemService = new ItemService();
        MoneyOriented moneyOriented = new MoneyOriented();
        PersonService personService = new PersonService();
        personService.AddPerson();
        Inventory inventory = new Inventory();
        List<Item> items = itemService.GetItems();
        List<Person> persons = personService.GetPerson();
        List<Item> inventorypl = inventory.GetInventory();


        itemService.AddNewItem("Brain",50,1);
        itemService.AddNewItem("stick", 24.60, 1);
        itemService.AddNewItem("Beer", 10, 1);
        itemService.AddNewItem("Bun", 15, 1);

        itemService.AddNewItemToPlayer(null, "Brain", 20.50, "HumanPart", 1, persons[0], inventory);
        itemService.AddNewItemToPlayer(null, "stick", 24.60,"Part", 1, persons[0], inventory);
        itemService.AddNewItemToPlayer(null, "Beer", 10, "Food", 1, persons[0], inventory);
        itemService.AddNewItemToPlayer(null, "Bun", 15, "Food", 1, persons[0], inventory);

        
        bool Shop = true;
        while (Shop)
        {
            Console.WriteLine("=========================[MAIN MENU]=========================");
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1) Zakup");
            Console.WriteLine("2) Sprzedaj");
            Console.WriteLine("3) Sprawdź ekwipunek");
            Console.WriteLine("4) Wyjść");
            Console.WriteLine("=============================================================");
            int.TryParse(Console.ReadLine(), out int choice);
            choice -= 1;
            switch (choice)
            {
                case 0:
                    moneyOriented.ShopBuy(persons[0], personService, items, itemService, inventorypl);
                    break;
                case 1:
                    moneyOriented.ShopSell(persons[0], personService, items, itemService, inventorypl, inventory);
                    break;
                case 2:
                    inventory.ShowALL();
                    Console.WriteLine("=============================================================");
                    Console.WriteLine("If you want to sort items by its type use Comand !T. If you want to sort items by Name ust !N");
                    Console.WriteLine("=============================================================");
                    comands.CommandLine(Console.ReadLine(), inventory, inventorypl, itemService, items, moneyOriented, personService);
                    break;
                case 3:
                    Shop = false;
                    break;
            }
        }

        moneyOriented.ShopSell(persons[0], personService, items, itemService, inventorypl,inventory);
        foreach (Item item in inventorypl)
        {
            Console.WriteLine(item.Quantity);
        }
    }
}
