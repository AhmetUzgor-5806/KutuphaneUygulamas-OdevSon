using KutuphaneUygulamasıOdev.db.interfaces;
using KutuphaneUygulamasıOdev.entity;
using System.Xml.Linq;


namespace KutuphaneUygulamasıOdev.db
{
    internal class Userdb : IUserdb

    {
        MsDB MsDB = new MsDB();

        public User editUser(long id, string name, string surname, string email, string password)
        {
            foreach (User user in MsDB.users)
            {
                if (user.email == email) 
                {
                    user.id = id;
                    user.name = name;
                    user.surname = surname;
                    user.password = password;
                    return user;    
                }
            }
            return null;
        }

        public User editUserAdmin(long id, long newid, string name, string surname, string email, string password)
        {
            foreach (User user in MsDB.users)
            {
                if (user.id == id)
                {
                    user.id = newid;
                    user.name = name;
                    user.surname = surname;
                    user.password = password;
                    user.email = email;
                    return user;
                }
            }
            return null;

        }

        public User editUserMail(long id, string email)
        {
            foreach (User user in MsDB.users)
            {
                if (user.id == id)
                {
                    user.email= email;
                    return user;
                }
            }
            return null;
        }

        public void saveAdmin(User user)
        {

            MsDB.users.Add(user);
        }

        public void saveUser(User user)
        {

            MsDB.users.Add(user);
        }

        public void userList()
        {
            foreach (User user in MsDB.users)

            {
                Console.WriteLine(user.id);
                Console.WriteLine(user.name);
                Console.WriteLine(user.surname);
                Console.WriteLine(user.email);
                Console.WriteLine(user.password);
                Console.WriteLine(user.admin);
            }
        }

         public User userLogin(string email, string password)
        {
            foreach (User user in MsDB.users)

            {
                if (user.email == email && user.password == password)
                {
                    return user;
                }

                                
             
            }

            return null;

        }
    }
}
