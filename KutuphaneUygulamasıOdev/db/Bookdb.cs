using KutuphaneUygulamasıOdev.db.interfaces;
using KutuphaneUygulamasıOdev.entity;
using KutuphaneUygulamasıOdev.service.interfaces;
using System.Net;


namespace KutuphaneUygulamasıOdev.db
{
    internal class Bookdb : IBookdb
    {
        public void saveBook(Book book)
        {
            MsDB MsDB = new MsDB();
            MsDB.books.Add(book);
        }


        public void printscreen()
        {
            foreach (Book book in MsDB.books)

            {
                Console.WriteLine(book.id);
                Console.WriteLine(book.name);
                Console.WriteLine(book.writer);
                Console.WriteLine(book.stock);

            }
        }

        public void dropstock(int bookid) 
        {
            foreach (Book book in MsDB.books) 
            {
                if (book.id == bookid)
                {
                    if (book.stock > 0)
                    {
                        book.stock -= 1;
                    }
                }
            }
                

        }

        public bool returnBook(int id, int requestid)
        {
            foreach (Book book in MsDB.books)
            {
                if (book.id == id)
                {
                    book.stock += 1;
                    IRequestdb request = new Requestdb();
                    request.returnRequest (requestid);
                    return true;   
                }
            }
         return false;
        }

        public List<Book> listBookById(int bookid)
        {
            List<Book> list = new List<Book>();

            foreach (Book book in MsDB.books)
            {
                if (book.id == bookid)
                {
                    list.Add(book);
                }
            }

            return list;
        }

        public List<Book> listBook()
        {
            return MsDB.books;
        }

        public Book editBook(int id, int bid, string name, string writer, int stock)
        {
            foreach (Book book in MsDB.books) 
            {
                if (book.id == id)
                {
                    book.id = bid;
                    book.name = name;
                    book.writer = writer;
                    book.stock = stock;

                    return book;

                }
                               
            
            }

            return null;
        }

        public bool stockControl(int bookid)
        {
            foreach (Book book in MsDB.books)
            {
                if (book.id == bookid && book.stock > 0)
                {
                                        
                    return true;
                }
            }
            return false;
        }
    }
}
