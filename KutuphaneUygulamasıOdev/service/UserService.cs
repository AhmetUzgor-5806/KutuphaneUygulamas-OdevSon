using KutuphaneUygulamasıOdev.db;
using KutuphaneUygulamasıOdev.db.interfaces;
using KutuphaneUygulamasıOdev.entity;
using KutuphaneUygulamasıOdev.service.interfaces;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KutuphaneUygulamasıOdev.service
{
    internal class UserService : IUserService

    {
        
        IUserdb IUserdb = new Userdb();

        public User editUser(long id, string name, string surname, string email, string password)
        {
            return IUserdb.editUser(id, name, surname, email, password);
        }

        public User editUserAdmin(long id, long newid, string name, string surname, string email, string password)
        {
            return IUserdb.editUserAdmin(id,newid, name, surname, email, password);
        }

        public User editUserMail(long id, string email)
        {
            return IUserdb.editUserMail(id,email);
        }

        public User loginUser(string email, string password)
        {
            return IUserdb.userLogin(email, password);
        }

        public void saveAdmin(long id, string name, string surname, string email, string password)
        {

            User user = new User();
            user.id = id;
            user.name = name;
            user.surname = surname;
            user.email = email;
            user.password = password;
            user.admin = true;
            
            IUserdb.saveAdmin (user);
        }

        public void saveUser(long id, string name, string surname, string email, string password)
        {
            User user = new User();
            user.id = id;
            user.name = name;
            user.surname = surname;
            user.email = email;
            user.password = password;
            user.admin = false;

            IUserdb.saveUser (user);

        }

        
    }
}
