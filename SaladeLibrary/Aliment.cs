using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst
{
    class Aliment
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        public virtual ICollection<Salade> Salade { get; set; }
    }
}
