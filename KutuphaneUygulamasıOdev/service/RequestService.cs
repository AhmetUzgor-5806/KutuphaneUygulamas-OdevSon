using System;
using KutuphaneUygulamasıOdev.service.interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutuphaneUygulamasıOdev.db;
using KutuphaneUygulamasıOdev.entity;
using KutuphaneUygulamasıOdev.db.interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KutuphaneUygulamasıOdev.service
{
    internal class RequestService : IRequestService
    {
        IRequestdb iRequestdb = new Requestdb();

        public List<Book> getBooksRentedByUserId(long userId)
        {
            return iRequestdb.getBooksRentedByUserId(userId);
        }

        public bool rejectRequest(int id)
        {
            return iRequestdb.rejectRequest (id);
        }

        public bool requestCanceled(int id)
        {
            return iRequestdb.requestCanceled (id);
        }

        public bool requestConfirmation(int id)
        {
            return iRequestdb.requestConfirmation (id);
        }

        public bool saveRequest(int id, long userid, int bookid)
        {
            IBookdb bookdb = new Bookdb ();
            bool book = bookdb.stockControl(bookid);

            if (book == true)
            {

                Request request = new Request();
                request.id = id;
                request.userid = userid;
                request.bookid = bookid;
                request.status = "Bekliyor";

                iRequestdb.saveRequest(request);
                return true;
            }

            return false;

        } 




        public List<Request> listRequest() 
        {
        return iRequestdb.listRequest();
        }
    }
}
