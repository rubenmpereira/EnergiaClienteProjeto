using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergiaClienteDominio
{
    public class Reading
    {
        public int id { get; set; }
        public int vazio { get; set; }
        public int ponta { get; set; }
        public int cheias { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public DateTime readingDate { get; set; }
        public int habitation { get; set; }
        public bool estimated { get; set; }
    }
}
