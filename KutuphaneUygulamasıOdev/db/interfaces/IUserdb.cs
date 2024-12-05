

using KutuphaneUygulamasıOdev.entity;

namespace KutuphaneUygulamasıOdev.db.interfaces
{
    internal interface IUserdb
    {
        User editUser(long id, string name, string surname, string email, string password);
        User editUserAdmin(long id, long newid, string name, string surname, string email, string password);
        User editUserMail(long id, string email);
        void saveAdmin(User user);
        void saveUser(User user);
        User userLogin(string email, string password);
    }
}
