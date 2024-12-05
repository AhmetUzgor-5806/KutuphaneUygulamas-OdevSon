using KutuphaneUygulamasıOdev.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KutuphaneUygulamasıOdev.service.interfaces
{
    internal interface IRequestService
    {
         bool saveRequest(int id, long userid, int bookid); 
         bool requestConfirmation (int id);
         bool rejectRequest(int id);
         bool requestCanceled (int id);
         List<Book> getBooksRentedByUserId (long userId);
         List<Request> listRequest();


    }
}
