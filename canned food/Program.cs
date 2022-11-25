using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canned_food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage(new CannedFood[]
            {
                new CannedFood("ГОСТ", 2000, 20),
                new CannedFood("Коровка", 2019, 5),
                new CannedFood("ГОСТ", 1964, 15),
                new CannedFood("Потемки", 2004, 20),
                new CannedFood("ГОСТ", 2005, 18),
                new CannedFood("Потемки", 2007, 3),
                new CannedFood("Коровка", 2015, 6),
                new CannedFood("Тушенка - карамель", 2019, 3),
            });
            CannedFood[] BuiltCannedFood = storage.GetBuilt(2022);

            storage.ShowInfo();

            Console.WriteLine();

            foreach (var cannedFood in BuiltCannedFood)
            {
                Console.WriteLine($"{cannedFood.Name}, Дата изготовления: {cannedFood.YearOfIssue} год, срок годности: {cannedFood.BestBeforeDate} лет - просрочено");
            }

            Console.ReadKey();
        }
    }

    class Storage
    {
        private CannedFood[] _storage;

        public Storage(CannedFood[] storage)
        {
            _storage = storage;
        }

        public CannedFood[] GetBuilt(int nowYear)
        {
            return _storage.Where(cannedFood => cannedFood.YearOfIssue + cannedFood.BestBeforeDate < nowYear).ToArray();
        }

        public void ShowInfo()
        {
            foreach (var cannedFood in _storage)
            {
                Console.WriteLine($"{cannedFood.Name}, Дата изготовления: {cannedFood.YearOfIssue} год, срок годности: {cannedFood.BestBeforeDate} лет");
            }
        }
    }

    class CannedFood
    {
        public string Name { get; private set; }
        public int YearOfIssue { get; private set; }
        public int BestBeforeDate { get; private set; }

        public CannedFood(string name, int yearOfIssue, int bestBeforeDate)
        {
            Name = name;
            YearOfIssue = yearOfIssue;
            BestBeforeDate = bestBeforeDate;
        }
    }
}
