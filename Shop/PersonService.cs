using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    // Klasa PersonService zarządza operacjami związanymi z osobami w sklepie.
    internal class PersonService
    {
        // Lista przechowująca wszystkie osoby.
        private List<Person> persons = new List<Person>();

        // Metoda dodająca nową osobę do listy.
        public void AddPerson()
        {
            // Tworzenie nowej osoby z unikalnym ID i początkową kwotą pieniędzy.
            Person person = new Person() { ID = persons.Count + 1, Money = 100 };
            persons.Add(person); // Dodanie nowej osoby do listy.
        }

        // Metoda zwracająca listę wszystkich osób.
        public List<Person> GetPerson()
        {
            return persons; // Zwraca listę osób.
        }

        // Metoda usuwająca określoną kwotę pieniędzy od danej osoby.
        public void RemoveMoney(Person person, double HowManyToTake)
        {
            // Odjęcie określonej kwoty od pieniędzy danej osoby.
            Person WhoMoneyRemoveTo = person;
            WhoMoneyRemoveTo.Money -= HowManyToTake;
        }

        // Metoda dodająca określoną kwotę pieniędzy do danej osoby.
        public void AddMoney(Person person, int HowManyToAdd)
        {
            // Dodanie określonej kwoty do pieniędzy danej osoby.
            Person WhoMoneyAddTo = person;
            WhoMoneyAddTo.Money += HowManyToAdd;
        }

        public void ShowMoney(Person person)
        {
            Console.WriteLine($"You have {person.Money} in your account");
        }
    }
}
