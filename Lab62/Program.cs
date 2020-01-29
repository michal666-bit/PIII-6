using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using RandomDataGenerator.Randomizers;
using RandomDataGenerator.FieldOptions;

namespace Lab62
{
    class Osoba
    {
        public int ID;
        public string imie;
        public string nazwisko;
        public Osoba(int id, string imie, string nazwisko)
        {
            ID = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var intGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsInteger());
            var nameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var lastnameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            var random = new Osoba(
                intGenerator.Generate().Value,
                nameGenerator.Generate(),
                lastnameGenerator.Generate());
            Console.WriteLine($"{random.ID} {random.imie} {random.nazwisko} ");

            
            var list = new List<Osoba>();
            for (int i = 0; i < 50; i++)
            {
                list.Add(new Osoba(
                intGenerator.Generate().Value,
                nameGenerator.Generate(),
                lastnameGenerator.Generate()));
            }
            list = list.OrderBy(x => x.nazwisko).ThenBy(x => x.imie).ToList();
            foreach (var item in list)
            {
                Console.WriteLine("{0} {1}", item.nazwisko, item.imie);

            }
            
            /*var lista = Enumerable.Range(100, 150).ToList();
            List<int> PodzielnePrzez3 =
               lista.Where(x => x % 3 == 0).ToList();
            int elementyNaStronie = 25;
            int nrStrony = 2;
            List<int> strona = lista.Skip(elementyNaStronie * (nrStrony - 1))
                .Take(elementyNaStronie)
                .ToList();
            var srednia = lista.Average();
            foreach (var item in strona)
            {
                Console.WriteLine(item);
            }
            List<Osoba> osoby = Enumerable.Range(1, 50)
              .Select(x => new Osoba()
            {
                ID = x,
                imie = x.ToString(),
                nazwisko = "aaa"
            }).ToList();

            foreach (var item in osoby)
            {
                Console.WriteLine($"{item.ID} {item.imie} {item.nazwisko} ");
            }
            IEnumerable<int> ids = osoby.Select(x => x.ID);
            foreach (var item in ids)
            {
                Console.WriteLine(item);
            }
            List<string> nazwiska = osoby.Select(x => x.nazwisko).ToList();
            foreach (var item in nazwiska)
            {
                Console.WriteLine(item);
            }
            osoby[36].nazwisko = "Yeti";
            osoby.Select(x => x.nazwisko).Distinct().ToList()
              .ForEach(x => Console.WriteLine(x));
            int pierwszy = lista.FirstOrDefault(x=>x%300==0);
            Console.WriteLine(pierwszy); */
        }
    }
}