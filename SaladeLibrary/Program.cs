using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SaladesContext())
            {
                //var a = new Aliment()
                //{
                //    Nom = "TestAlimentSalade"
                //};

                //db.Aliments.Add(a);
                //db.SaveChanges();
                if (!db.Salades.Any(s => s.Nom == "Sodebo Fraicheur&Minceur"))
                {
                    var s = new Salade()
                    {
                        Nom = "Sodebo Fraicheur&Minceur",
                        Description = "Une super bonne salade"
                    };
                    db.Salades.Add(s);
                    db.SaveChanges();
                    Console.WriteLine("La salade est créée :)");
                }
                else
                {
                    Console.WriteLine("Already created...");
                }
                Console.ReadKey();
            }
        }
    }
}
