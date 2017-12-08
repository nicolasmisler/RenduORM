using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCodeFirst
{
    class Salade
    {
        // auto incrément automatique
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [Column(TypeName ="nvarchar(max)")]
        public string Description { get; set; }

        public virtual Fabricant Fabricant { get; set; }

        public virtual ICollection<Aliment> Aliment { get; set; }
    }
}