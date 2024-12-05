using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasıOdev.entity
{
    internal class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public string writer { get; set; }
        public int stock { get; set; }

    }
}
