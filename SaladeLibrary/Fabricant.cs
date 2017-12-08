using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst
{
    class Fabricant
    {
        [Key]
        public int ID { get; set; }

        [StringLength(30)]
        public string Nom { get; set; }

        public ICollection<Salade> Salades { get; set; }
        
    }
}
