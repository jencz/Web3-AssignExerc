using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp.UI
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            GetSamurai("Before Add:");
            AddSamurais("Claudiu Sensei", "Aref Sensei", "Sandy Sensei", "Meghrig Sensei", "Gabriel Sensei", "Larry Sensei", "Ian Sensei", "Helen Sensei", "Vik Sensei", "Talib Sensei");
            GetSamurai("After Add:");
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
    } 
}
