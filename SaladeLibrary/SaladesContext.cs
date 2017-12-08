using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst
{
    class SaladesContext : DbContext
    {
        public SaladesContext()
            : base("salades") // je donne le nom de la chaine de connexion
        {

        }

        // je défini mes DbSet (qui sont mappés aux tables)
        public virtual DbSet<Salade> Salades { get; set; }
        public virtual DbSet<Aliment> Aliments { get; set; }
        //public virtual DbSet<SaladeAliments> SaladeAliments { set; get; } 
    }
}
