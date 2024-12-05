

using KutuphaneUygulamasıOdev.entity;

namespace KutuphaneUygulamasıOdev.db.interfaces
{
    internal interface IBookdb
    {
        void dropstock(int bookid);
        Book editBook(int id, int bid, string name, string writer, int stock);
        List<Book> listBook();
        List<Book> listBookById(int bookid);
        bool returnBook(int id, int requestid);
        void saveBook(Book book);
        bool stockControl(int bookid);
    }
}
