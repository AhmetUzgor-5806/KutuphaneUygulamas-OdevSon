using System;
using KutuphaneUygulamasıOdev.entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasıOdev.service.interfaces
{
    internal interface IBookService
    {
        void saveBook (int id, string name, string writer, int stock);
        bool returnBook (int id, int requestid);
        List<Book> listBook();
        Book editBook (int id, int bid, string name, string writer, int stock);
    }
}
