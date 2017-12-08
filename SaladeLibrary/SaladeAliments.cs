using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst
{
    class SaladeAliments
    {
        public int SaladeID { get; set; }
        public int AlimentID { get; set; }

        public virtual Aliment Aliment { get; set; }
        public virtual Salade Salade { get; set; }
    }
}
