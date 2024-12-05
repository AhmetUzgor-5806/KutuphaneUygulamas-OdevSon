

using KutuphaneUygulamasıOdev.entity;

namespace KutuphaneUygulamasıOdev.db.interfaces
{
    internal interface IRequestdb
    {
        List<Book> getBooksRentedByUserId(long userId);
        bool rejectRequest(int id);
        bool requestCanceled(int id);
        bool requestConfirmation(int id);
        void saveRequest(Request request);
        public List<Request> listRequest();
        void returnRequest(int requestid);
    }
}
