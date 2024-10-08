using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Comands
    {
        public void CommandLine(String text, Inventory inventory, List<Item> inventoryList, ItemService itemService, List<Item> items, MoneyOriented moneyOriented, PersonService personService,Person person)
        {
            text = text.ToUpper();
            if (text == "!T")
            {
                TComand(inventory);
            }
            if (text == "!N")
            {
                NComand(inventory);
            }
            if (text == "!ADDMONEY")
            {
                CashAddComand(person);
            }
            if (text == "!REMOVEMONEY")
            {
                CashRemoveComand(person);
            }
            else
            {
                
            }
        }
        public void TComand(Inventory inventory)
        {
            Console.WriteLine("Type what type of item you wants:");
            String Chosen_Type = Console.ReadLine();
            inventory.SortBy(Chosen_Type);


        }
        public void NComand(Inventory inventory)
        {
            Console.WriteLine("Type what name should item have?");
            String Chosen_Name = Console.ReadLine();
            inventory.SortName(Chosen_Name);
        }

        public void CashAddComand(Person person)
        {
            double.TryParse(Console.ReadLine(), out double moneyamount);
            person.Money += moneyamount;
        }

        public void CashRemoveComand(Person person)
        {

            double.TryParse(Console.ReadLine(), out double moneyamount);
            person.Money -= moneyamount;
        }

    }

    
}
