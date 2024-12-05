using KutuphaneUygulamasıOdev.db.interfaces;
using KutuphaneUygulamasıOdev.entity;
using static System.Reflection.Metadata.BlobBuilder;

namespace KutuphaneUygulamasıOdev.db
{
    internal class Requestdb : IRequestdb
    {
        public void saveRequest(Request request)
        {
            MsDB MsDB = new MsDB();
            MsDB.requests.Add(request);
        }

        public List<Request>  listRequest()
        {
            return MsDB.requests;
        }

        public bool requestConfirmation(int id)
        {
            foreach (Request request in MsDB.requests)
            {
                if (request.id == id)
                {
                    request.status = "Onaylandı - Kitap Teslim Edildi";

                    IBookdb bookdb = new Bookdb();
                    bookdb.dropstock(request.bookid);


                    return true;

                }
            }
            return false;
        }

        public bool rejectRequest(int id)
        {
            foreach (Request request in MsDB.requests)
            {
                if (request.id == id)
                {
                    request.status = "Reddedildi";

                    return true;

                }
            }
            return false;
        }

        public bool requestCanceled(int id)
        {
            foreach (Request request in MsDB.requests)
            {
                if (request.id == id)
                {
                    if (request.status == "Bekliyor")
                    {

                        request.status = "Talep İptal Edildi";

                        return true;
                    }
                    else 
                    {
                       Console.WriteLine("Onaylanan talepler iptal edilemez");
                    }
                    
                }
            }
            return false;
        }

        public List<Book> getBooksRentedByUserId(long userId)
        {
            List<Book> userBooks = new List<Book>();
            foreach (Request request in MsDB.requests)
            {
                if (request.userid == userId)
                {
                    if (request.status == "Onaylandı - Kitap Teslim Edildi")
                    {
                        IBookdb bookdb = new Bookdb();
                        List<Book> book = bookdb.listBookById(request.bookid);

                        if (book != null && book.Count > 0)
                        {
                            userBooks.AddRange(book);
                        }
                    }
                }
            }
            return userBooks; 
        }

        public void returnRequest(int requestid)
        {
            foreach (Request request in MsDB.requests)
            {
                if (request.id == requestid)
                {
                    request.status = "Kitap İade Edildi";                  

                }
            }
            
        }
    }
}
