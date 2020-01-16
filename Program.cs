using System;
using System.Collections.Generic;
using System.Linq;
using RandomDataGenerator.Randomizers;
using RandomDataGenerator.FieldOptions;
// lista losowo generowanych osobo sor po nazwisku potem po imieniu 
namespace Lab6
{
    class Osoba
    {
        public string Imie;
        public string Nazwisko;
        public int Id;

        public Osoba(string imie, string nazwisko, int id)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Id = id;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = Enumerable.Range(150, 100)
               .Select(x => (int)x).ToList();
            #region
            /*  lista.ForEach(x => Console.WriteLine(x));

           /*  Osoba test = new Osoba()
             {
                 Imie = "aaA",
                 Nazwisko = "bbb",
                 Id = 10
             };
             List<Osoba> osoby =
           lista.Select(x => new Osoba()
           {
               Imie = x.ToString(),
               Nazwisko = "AAA",
               Id = x
           }).ToList();//.ForEach(x => Console.WriteLine($"{x.Id}:{x.Imie}:{x.Nazwisko}"));
           osoby[45].Nazwisko = "BBB";
           osoby.Select(x => x.Nazwisko).Distinct().ToList().ForEach(Console.WriteLine);
           Osoba osobaB = osoby.Where(x => x.Nazwisko.StartsWith("B")).First();
           int iloscElementowNaStronie = 10;
           int numerStrony = 2;
           List<Osoba> strona = osoby.Skip(iloscElementowNaStronie * (numerStrony - 1))
               .Take(iloscElementowNaStronie).ToList();
           foreach (var item in strona)
           {
               Console.WriteLine($"{item.Id}:{item.Imie}:{item.Nazwisko}");
           }

           foreach (var item in osoby)
           {
               Console.WriteLine($"{osobaB.Id}:{osobaB.Imie}:{osobaB.Nazwisko}");
           }
           {

           }

           foreach (var item in lista)
           {
               Console.WriteLine(item);
           }
           IEnumerable<int> podzielnePrzez3 = lista.Where(x => x % 3 == 0);
           foreach (var item in podzielnePrzez3) 
           {
               Console.WriteLine(item);
           }
           int suma = podzielnePrzez3.Sum();
           Console.WriteLine(suma);
           double srednia = podzielnePrzez3.Average();
           Console.WriteLine(srednia);
           {

           } */
            #endregion
            var generatorFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var generatorLastName =
                RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            List<Osoba> osoby = lista.Select(
                x => new Osoba(
                    generatorFirstName.Generate(),
                    generatorLastName.Generate(),
                    x)).ToList();
            foreach (var item in osoby)
            {
                Console.WriteLine($"{item.Id}:{item.Imie}:{item.Nazwisko}");
            }


        }
    }
}
