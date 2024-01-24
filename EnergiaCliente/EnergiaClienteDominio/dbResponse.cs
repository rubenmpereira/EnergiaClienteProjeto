using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergiaClienteDominio
{
    public class dbResponse<T>
    {
        public bool error { get; set; }
        public int statusCode { get; set; }
        public string errorMessage { get; set; }
        public List<T> result { get; set; }
    }
}
