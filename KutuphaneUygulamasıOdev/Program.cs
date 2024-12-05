using KutuphaneUygulamasıOdev.service.interfaces;
using KutuphaneUygulamasıOdev.service;
using KutuphaneUygulamasıOdev.db;
using KutuphaneUygulamasıOdev.entity;
using KutuphaneUygulamasıOdev.controller;
using System.Collections.Generic;

namespace KutuphaneUygulamasıOdev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menu = -1;

            UserController user = new UserController();
            RequestController request = new RequestController();
            BookController book = new BookController();
            user.saveAdmin(35761605058, "Ahmet", "Uzgör", "auzgor@hotmail.com", "Au145137-");
            while (menu != 0)
            {

                Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz");
                Console.WriteLine("1_Kayıt Ol \n2_Giriş Yap");
                int userChoice = Convert.ToInt32(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("TCKN Giriniz");
                        long tckn = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Ad");
                        string name = Console.ReadLine();
                        Console.WriteLine("Soyad");
                        string surname = Console.ReadLine();
                        Console.WriteLine("email");
                        string email = Console.ReadLine();
                        Console.WriteLine("Şifre");
                        string password = Console.ReadLine();

                        user.saveUser(tckn, name, surname, email, password);

                        Console.WriteLine("Kayıt Yapıldı");
                        break;
                    case 2:
                        Console.WriteLine("email");
                        string mail = Console.ReadLine();
                        Console.WriteLine("Şifre");
                        string pasword = Console.ReadLine();

                        User user2 = user.loginUser(mail, pasword);

                        if (user2 != null)
                        {
                            Console.WriteLine($"Giriş başarılı! Hoş geldiniz, {user2.name} {user2.surname}.");

                            if (user2.admin == true)
                            {
                                int adminMenuChoice = -1;
                                while (adminMenuChoice != 0)
                                {
                                    Console.WriteLine("******** ADMİN MENÜ ********");
                                    Console.WriteLine("1_Kitap Ekle \n2_Kitap Güncelle \n3_Talep Görüntüle \n4_Talep Onay \n5_Talep Red \n6_Admin Ekle \n7_Admin Düzenle \n8_Kullanıcı Mail Değiştir \n0_Çıkış");
                                    int userAdminChoice = Convert.ToInt32(Console.ReadLine());

                                    switch (userAdminChoice)
                                    {
                                        case 1:
                                            Console.WriteLine("Kitap İd Giriniz");
                                            int bookid = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Kitap Adını Giriniz");
                                            string bookname = Console.ReadLine();
                                            Console.WriteLine("Kitap Yazar Adını Giriniz");
                                            string bookwriter = Console.ReadLine();
                                            Console.WriteLine("Stok Giriniz");
                                            int bookstock = Convert.ToInt32(Console.ReadLine());

                                            book.saveBook(bookid, bookname, bookwriter, bookstock);

                                            break;
                                        case 2:
                                            Console.WriteLine("Mevcut Kitap id Giriniz");
                                            int id = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Yeni Kitap id Giriniz");
                                            int bid = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Yeni Kitap Adını Giriniz");
                                            string bname = Console.ReadLine();
                                            Console.WriteLine("Yeni Yazar Adını Giriniz");
                                            string bwriter = Console.ReadLine();
                                            Console.WriteLine("Yeni Stok Miktarını Giriniz");
                                            int bstock = Convert.ToInt32(Console.ReadLine());

                                            Book book2 = book.editBook(id, bid, bname, bwriter, bstock);
                                            if (book2 != null)
                                            {
                                                Console.WriteLine($"{book2.id} id numaralı kitap güncellendi.\nKitap Adı {book2.name} \nKitap Yazarı {book2.writer} \nKitap Stoğu {book2.stock}");

                                            }
                                            else
                                            {
                                                Console.WriteLine("Girilen kitap id hatalı veya veri tabanında yer almıyor");
                                            }
                                            break;
                                        case 3:

                                            List<Request> requests = request.listRequest();
                                            if (requests != null && requests.Count > 0)
                                                foreach (Request request2 in requests)
                                                {
                                                    Console.WriteLine($"Talep id {request2.id} Kullanıcı id {request2.userid} Kitap id {request2.bookid} Durum {request2.status}");
                                                }
                                            else
                                            {
                                                Console.WriteLine("Veri tabanında talep bulunmamaktadır");
                                            }
                                            break;
                                        case 4:
                                            Console.WriteLine("Onaylamak İstediğiniz Talep id Giriniz");
                                            int requestid = Convert.ToInt32(Console.ReadLine());
                                            bool request3 = request.requestConfirmation(requestid);
                                            if (request3 == true)
                                            {
                                                Console.WriteLine("Talep Onaylandı");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Talep id hatalı veya veri tabanında yok");
                                            }

                                            break;
                                        case 5:
                                            Console.WriteLine("Reddetmek İstediğiniz Talep id Giriniz");
                                            int requestid1 = Convert.ToInt32(Console.ReadLine());
                                            bool request4 = request.rejectRequest(requestid1);
                                            if (request4 == true)
                                            {
                                                Console.WriteLine("Talep Reddedildi");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Talep id hatalı veya veri tabanında yok");
                                            }

                                            break;
                                        case 6:
                                            Console.WriteLine("TCKN Giriniz");
                                            long tckn1 = Convert.ToInt64(Console.ReadLine());
                                            Console.WriteLine("Ad");
                                            string name1 = Console.ReadLine();
                                            Console.WriteLine("Soyad");
                                            string surname1 = Console.ReadLine();
                                            Console.WriteLine("email");
                                            string email1 = Console.ReadLine();
                                            Console.WriteLine("Şifre");
                                            string password1 = Console.ReadLine();

                                            user.saveAdmin(tckn1, name1, surname1, email1, password1);

                                            Console.WriteLine("Kayıt Yapıldı");

                                            break;
                                        case 7:
                                            Console.WriteLine("Mevcut id numaranızı yazınız");
                                            long id1 = Convert.ToInt64(Console.ReadLine());
                                            Console.WriteLine("Yeni id numaranızı yazınız");
                                            long newId = Convert.ToInt64(Console.ReadLine());
                                            Console.WriteLine("Yeni Ad Bilgisini Giriniz");
                                            string newName = Console.ReadLine();
                                            Console.WriteLine("Yeni Soyad bilgisini giriniz");
                                            string newSurname = Console.ReadLine();
                                            Console.WriteLine("Yeni email bilgisini giriniz");
                                            string newEmail = Console.ReadLine();
                                            Console.WriteLine("Yeni Şifre giriniz");
                                            string newPassword = Console.ReadLine();

                                            User newAdmin = user.editUserAdmin(id1, newId, newName, newSurname, newEmail, newPassword);

                                            if (newAdmin != null)
                                            {
                                                Console.WriteLine($"{newAdmin.id} id numaralı kişi bilgileri güncellendi.\nAdı {newAdmin.name} \nSoyadı {newAdmin.surname} \n email {newAdmin.email} Şifre {newAdmin.password}");

                                            }
                                            else
                                            {
                                                Console.WriteLine("Girilen mevcut admin id hatalı veya veri tabanında yer almıyor");
                                            }
                                            break;

                                        case 8:
                                            Console.WriteLine("Mevcut  Kullanıcı id numaranızı yazınız");
                                            long userId = Convert.ToInt64(Console.ReadLine());
                                            Console.WriteLine("Yeni email bilgisini giriniz");
                                            string newUserMail = Console.ReadLine();
                                            User newUser = user.editUserMail(userId, newUserMail);
                                            if (newUser != null)
                                            {
                                                Console.WriteLine($"{newUser.id} id numaralı kişi  mail bilgileri güncellendi.\nAdı {newUser.name} \nSoyadı {newUser.surname} \n email {newUser.email} Şifre {newUser.password}");

                                            }
                                            else
                                            {
                                                Console.WriteLine("Girilen mevcut admin id hatalı veya veri tabanında yer almıyor");
                                            }

                                            break;
                                        case 0:
                                            adminMenuChoice = 0;
                                            break;

                                        default:
                                            Console.WriteLine("Hatalı Seçim Yaptınız");
                                            break;





                                    }
                                }
                            }
                            else
                            {
                                int userMenuChoice = -1;
                                while (userMenuChoice != 0)
                                {
                                    Console.WriteLine("******** KULLANICI MENÜ ********");
                                    Console.WriteLine("1_Kitap Kiralama Talebi Oluştur \n2_Kitap Kiralama Talep İptali \n3_Kitap İade Et \n4_Daha Önce Kiralananlar Listesi \n5_Tüm Kitapları Gör \n6_Profil Güncelle \n0_Çıkış");
                                    int userUserChoice = Convert.ToInt32(Console.ReadLine());

                                    switch (userUserChoice)
                                    {
                                        case 1:
                                            Console.WriteLine("Talep id giriniz");
                                            int requestId = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("TCKN giriniz");
                                            long userTckn = Convert.ToInt64(Console.ReadLine());
                                            Console.WriteLine("Kiralamak istediğiniz kitap id giriniz");
                                            int userBookId = Convert.ToInt32(Console.ReadLine());

                                            bool request1 = request.saveRequest(requestId, userTckn, userBookId);

                                            if (request1 == true)
                                            {
                                                Console.WriteLine("Kitap kiralama talebi alındı");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Kitap stoğu kalmadı veya kitap veri tabanında yok");
                                            }

                                            break;
                                        case 2:
                                            Console.WriteLine("İptal etmek istediğiniz talep id giriniz");
                                            int id = Convert.ToInt32(Console.ReadLine());

                                            bool requestCanceled = request.requestCanceled(id);

                                            if (requestCanceled == true)
                                            {
                                                Console.WriteLine("Talep İptal Edildi");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Talep id hatalı");
                                            }

                                            break;
                                        case 3:
                                            Console.WriteLine("İade etmek istediğiniz kitap id giriniz");
                                            int bookid = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("İade talep numaranızı giriniz");
                                            int requestid = Convert.ToInt32(Console.ReadLine());
                                            bool returnBook = book.returnBook(bookid, requestid);

                                            if (returnBook == true)
                                            {
                                                Console.WriteLine("Kitap İade İşlemi Gerçekleştirildi.");
                                            }

                                            break;
                                        case 4:
                                            Console.WriteLine("TCKN yazınız");
                                            long tckn1 = Convert.ToInt64(Console.ReadLine());
                                            List<Book> listbook = request.getBooksRentedByUserId(tckn1);
                                            foreach (Book book1 in listbook)
                                            {
                                                Console.WriteLine($"Kitap id {book1.id} Kitap Adı {book1.name} Kitap Yazarı {book1.writer}");
                                            }
                                            break;
                                        case 5:
                                            List<Book> books = book.listBook();
                                            foreach (Book book1 in books)
                                            {
                                                Console.WriteLine($"Kitap id {book1.id} Kitap Adı {book1.name} Kitap Yazarı {book1.writer}");
                                            }
                                            break;
                                        case 6:
                                            Console.WriteLine("Bu alanda mail güncellenemez. Mail güncellemek için yöneticinize başvurunuz");
                                            Console.WriteLine("Mevcut mail adresinizi yazınız.");
                                            string mail1 = Console.ReadLine();
                                            Console.WriteLine("Yeni TCKN yazınız");
                                            long tckn2 = Convert.ToInt64(Console.ReadLine());
                                            Console.WriteLine("Yeni Ad Giriniz");
                                            string newName = Console.ReadLine();
                                            Console.WriteLine("Yeni Soyad Giriniz");
                                            string newSurname = Console.ReadLine();
                                            Console.WriteLine("Yeni Şifre Giriniz");
                                            string newPassword = Console.ReadLine();

                                            User newUser = user.editUser(tckn2, newName, newSurname, mail1, newPassword);
                                            if (newUser != null)
                                            {
                                                Console.WriteLine($"{newUser.id} Tckn numaralı kişi bilgileri güncellendi.\nAdı {newUser.name} \nSoyadı {newUser.surname} \n email {newUser.email} Şifre {newUser.password}");

                                            }
                                            else
                                            {
                                                Console.WriteLine("Girilen mail hatalı veya veri tabanında yer almıyor");
                                            }
                                            break;

                                            
                                        case 0:
                                            userMenuChoice = 0;
                                            break;
                                        default: Console.WriteLine("Hatalı Seçim Yaptınız"); break;

                                    }

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı e-posta veya şifre.");
                        }

                        break;
                    default:
                        Console.WriteLine("Hatalı Seçim Yapıldı");
                        break;

                }




            }


        }   

            

    }
}
