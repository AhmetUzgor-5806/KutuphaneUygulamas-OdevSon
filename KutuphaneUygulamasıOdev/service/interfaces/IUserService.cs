using KutuphaneUygulamasıOdev.entity;

namespace KutuphaneUygulamasıOdev.service.interfaces
{
    internal interface IUserService

    {
        
        public void saveUser(long id, string name, string surname, string email, string password);
        public void saveAdmin(long id, string name, string surname, string email, string password);
        User loginUser(string email, string password);
        User editUser(long id, string name, string surname, string email, string password);
        User editUserMail(long id, string email);
        User editUserAdmin(long id, long newid, string name, string surname, string email, string password);








    }
}
