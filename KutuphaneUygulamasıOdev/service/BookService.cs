using KutuphaneUygulamasıOdev.db.interfaces;
using KutuphaneUygulamasıOdev.db;
using KutuphaneUygulamasıOdev.entity;
using KutuphaneUygulamasıOdev.service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasıOdev.service
{
    internal class BookService : IBookService
    {
        IBookdb iBookdb = new Bookdb();

        public Book editBook(int id, int bid, string name, string writer, int stock)
        {
           return iBookdb.editBook(id, bid, name, writer, stock);
        }

        public List<Book> listBook()
        {
            return iBookdb.listBook();
        }

        public bool returnBook(int id, int requestid)
        {
           return iBookdb.returnBook(id, requestid);
        }

        public void saveBook(int id, string name, string writer, int stock)
        {
            
            Book book = new Book();
            book.id = id;
            book.name = name;
            book.writer = writer;
            book.stock = stock;
            
            iBookdb.saveBook(book);
        }
    }
}
