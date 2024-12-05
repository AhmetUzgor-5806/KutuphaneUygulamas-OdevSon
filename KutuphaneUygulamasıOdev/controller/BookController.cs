using KutuphaneUygulamasıOdev.db;
using KutuphaneUygulamasıOdev.entity;
using KutuphaneUygulamasıOdev.service;
using KutuphaneUygulamasıOdev.service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasıOdev.controller
{
    internal class BookController
    {
        IBookService bookService = new BookService();
        public void saveBook(int id, string name, string writer, int stock) 
        {

         bookService.saveBook(id, name, writer, stock);
        
        }

        public Book editBook(int id, int bid, string name, string writer, int stock) 
        {

         return bookService.editBook(id,bid, name, writer, stock);
        
        }
        public bool returnBook(int id, int requestid) 
        {
            return bookService.returnBook(id, requestid);
        }

        public List<Book> listBook() 
        {
          return bookService.listBook();
        }
    }
}
