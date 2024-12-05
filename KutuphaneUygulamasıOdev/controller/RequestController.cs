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
    internal class RequestController
    {
        IRequestService requestService = new RequestService ();
        public List<Request> listRequest() 
        {
        return requestService.listRequest();
        }

        public bool requestConfirmation(int id) 
        {
        return requestService.requestConfirmation(id);
        }

        public bool rejectRequest(int id) 
        {
        return requestService .rejectRequest(id);
        }

        public bool saveRequest(int id, long userid, int bookid) 
        {
          return requestService.saveRequest(id, userid, bookid);
        }

        public bool requestCanceled(int id) 
        {
        return requestService.requestCanceled(id);
        }

        public List<Book> getBooksRentedByUserId(long userId) 
        {
         return requestService.getBooksRentedByUserId (userId);
        }
    }
}
