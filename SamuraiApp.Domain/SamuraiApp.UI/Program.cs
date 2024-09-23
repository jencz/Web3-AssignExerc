using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp.UI
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            AddSamurais("Claudiu Sensei", "Aref Sensei", "Sandy Sensei", "Meghrig Sensei", "Gabriel Sensei", "Larry Sensei", "Ian Sensei", "Helen Sensei", "Vik Sensei", "Talib Sensei");
            QueryAggregates();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        private static void GetSamurai(string msg)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{msg} Samurai count is {samurais.Count}");

            if (samurais.Count > 0)
            {
                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
            else
                Console.WriteLine("No samurais.");
        }
        private static void AddSamurais(params string[] names)
        {
            foreach (string name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
            }
            _context.SaveChanges();
        }
        private static void QueryAggregates()
        {
            var name = "Claudiu Sensei";
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);

            var id = 5;
            var samurai2 = _context.Samurais.Find(id);

            Print(samurai);
            Print(samurai2);
        }
        private static void Print(IEnumerable<Samurai> samurais, string extra = "")
        {
            foreach (var samurai in samurais)
            {
                Console.WriteLine(extra + samurai.Name);
            }
        }
        private static void Print(Samurai samurai)
        {
            if (samurai != null)
                Console.WriteLine(samurai.Name);
            else
                Console.WriteLine("Samurai is null");
        }
        private static void AddVariousTypes()
        {
            _context.AddRange(new Samurai { Name = "Shimada" }, new Samurai { Name = "Okamoto" }, new Battle { Name = "Battle of Anegawa" }, new Battle { Name = "Battle of Nagashino" });
            _context.SaveChanges();
        }
        private static void QueryFilters()
        {
            var name = "C%";
            var samurais = _context.Samurais.Where(s => s.Name == name).ToList();

            var filter = "C%";
            var samurais2 = _context.Samurais.Where(s => EF.Functions.Like(s.Name, filter)).ToList();

            var samurais3 = _context.Samurais.Where(s => s.Name.Contains("C")).ToList();

            Print(samurais, "1.");
            Print(samurais2, "2.");
            Print(samurais3, "3.");
        }
        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";

            _context.SaveChanges();
            Print(samurai);
        }
        private static void RetrieveAndUpdateMultipleSamurai()
        {
            var samurai = _context.Samurais.Skip(1).Take(4).ToList();
            samurai.ForEach(s => s.Name += "San");

            _context.SaveChanges();
            Print(samurai);
        }
    } 
}
