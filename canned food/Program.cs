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
            Storage storage = new Storage(new CanOfStew[]
            {
                new CanOfStew("ГОСТ", 2000, 20),
                new CanOfStew("Коровка", 2019, 5),
                new CanOfStew("ГОСТ", 1964, 15),
                new CanOfStew("Потемки", 2004, 20),
                new CanOfStew("ГОСТ", 2005, 18),
                new CanOfStew("Потемки", 2007, 3),
                new CanOfStew("Коровка", 2015, 6),
                new CanOfStew("Тушенка - карамель", 2019, 3),
            });

            storage.ShowAllCansOfStew();
            Console.WriteLine("\nПросроченные: ");
            storage.ShowOverdueCansOfStew();
            Console.ReadKey();
        }
    }

    class Storage
    {
        private CanOfStew[] _cansOfStew;
        private CanOfStew[] _overdueCansOfStew;

        public Storage(CanOfStew[] cansOfStew)
        {
            int currentYear = 2022;
            _cansOfStew = cansOfStew;
            _overdueCansOfStew = _cansOfStew.Where(cannedFood => cannedFood.YearOfIssue + cannedFood.BestBeforeDate < currentYear).ToArray();
        }

        public void ShowAllCansOfStew()
        {
            foreach (var cannedFood in _cansOfStew)
            {
                Console.WriteLine($"{cannedFood.Name}, Дата изготовления: {cannedFood.YearOfIssue} год, срок годности: {cannedFood.BestBeforeDate} лет");
            }
        }

        public void ShowOverdueCansOfStew()
        {
            foreach (var cannedFood in _overdueCansOfStew)
            {
                Console.WriteLine($"{cannedFood.Name}, Дата изготовления: {cannedFood.YearOfIssue} год, срок годности: {cannedFood.BestBeforeDate} лет - просрочена");
            }
        }
    }

    class CanOfStew
    {
        public string Name { get; private set; }
        public int YearOfIssue { get; private set; }
        public int BestBeforeDate { get; private set; }

        public CanOfStew(string name, int yearOfIssue, int bestBeforeDate)
        {
            Name = name;
            YearOfIssue = yearOfIssue;
            BestBeforeDate = bestBeforeDate;
        }
    }
}
