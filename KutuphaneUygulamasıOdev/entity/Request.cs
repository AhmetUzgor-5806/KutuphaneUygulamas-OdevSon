using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasıOdev.entity
{
    internal class Request
    {
        public int id { get; set; }
        public long userid { get; set; }
        public int bookid { get; set; }
        public string status { get; set; }

    }
}
