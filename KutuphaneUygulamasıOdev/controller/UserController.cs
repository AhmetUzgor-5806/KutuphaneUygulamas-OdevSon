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
    internal class UserController
    {
       IUserService userService = new UserService();

        public void saveUser(long id, string name, string surname, string email, string password) 
        {
          userService.saveUser (id, name, surname, email, password);
        }

        public User loginUser(string email, string password)
        {
            return userService.loginUser (email, password);
               
        }

        public void saveAdmin(long id, string name, string surname, string email, string password)
        {
            userService.saveAdmin (id, name, surname, email, password);
        }

        public User editUserAdmin(long id, long newid, string name, string surname, string email, string password) 
        {
         return userService.editUserAdmin(id, newid, name, surname,email, password);
        }

        public User editUserMail(long id, string email) 
        {
        return userService.editUserMail(id, email);
        }

        public User editUser(long id, string name, string surname, string email, string password) 
        {
           return userService.editUser (id, name , surname, email, password);
        }

    }
}
