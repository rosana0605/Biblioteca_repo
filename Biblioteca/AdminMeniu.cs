using BibliotecaExceptii;
using BibliotecaValidari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class AdminMeniu
    {
        public void AdminLogin()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Admin-Login-----------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Email Id: ");
                string adminEmail = Console.ReadLine();
                Console.Write("Parola: ");
                string adminPass = Console.ReadLine();
                AdminValidari adminBLL = new AdminValidari();
                bool isDone = adminBLL.AdminLogin(adminEmail, adminPass);
                if (isDone)
                {
                    AdminSection();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exceptii)
            {
                throw new Exceptii("Eroare..");
            }

        }
        //ADMIN 
        private void GetAdminMenu()
        {
            Console.Write("1) Apasa 1 pentru a afisa sectiunea de carti\n" +
                "2) Apasa 2 pentru a afisa sectiunea de utilizatori\n" +
                "3) Apasa 3 pentru a afisa sectiunea de cereri\n" +
                "4) Apasa 4 pentru a afisa sectiunea de accept\n" +
                "5) Apasa 5 pentru ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("logout");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        //ADMIN SECTIUNE COMPLETA
        private void AdminSection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Bun-venit-Sectiunea-Admin--------------");
            Console.ForegroundColor = ConsoleColor.White;
            bool adminLoop = true;
            while (adminLoop == true)
            {
                try
                {
                    GetAdminMenu();
                    int adminCase = int.Parse(Console.ReadLine());
                    switch (adminCase)
                    {
                        case 1:
                            CarteMeniu bookSection = new CarteMeniu();
                            bookSection.BookSection();
                            break;
                        case 2:
                            UserMeniu userSection = new UserMeniu();
                            userSection.UserSection();
                            break;
                        case 3:
                            RequestedSection();
                            break;
                        case 4:
                            RecievedSection();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Delogat cu succes..\nSa ai o zi buna...");
                            Console.ForegroundColor = ConsoleColor.White;
                            adminLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("input invalid!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exceptii)
                {
                    throw new Exceptii("Eroare..");
                }
            }
        }
        //ACCEPTA O CERERE PT CARTE
        public void AcceptRequest()
        {
            try
            {
                Console.Write("Id User: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Id Carte: ");
                int bookId = int.Parse(Console.ReadLine());
                UserValidari userBLL = new UserValidari();
                userBLL.AcceptRequestBLL(userId, bookId);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Introdu un input valid...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exceptii)
            {
                throw new Exceptii("Eroare..");
            }

        }
        //MENIU CERERI ADMIN
        private void RequestedSection()
        {
            bool reqLoop = true;
            while (reqLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Bun-venit-Sectiunea-Cereri--------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Apasa 1 pentru a afisa toate cererile\n" +
                        "2) Apasa 2 pentru a accepta o cerere\n" +
                        "3) Apasa 3 pentru a iesi");
                    int reqCase = int.Parse(Console.ReadLine());
                    switch (reqCase)
                    {
                        case 1:
                            UserMeniu userPL = new UserMeniu();
                            userPL.GetRequestBook();
                            break;
                        case 2:
                            AcceptRequest();
                            break;
                        case 3:
                            Console.WriteLine("");
                            reqLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Input invalid!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exceptii)
                {
                    throw new Exceptii("Eroare..");
                }
            }
        }
        //STERGE O CERERE
        public void DeleteRecieved()
        {
            try
            {
                Console.Write("Id user: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Id carte: ");
                int bookId = int.Parse(Console.ReadLine());
                UserValidari userBLL = new UserValidari();
                userBLL.DeleteRecievedBLL(bookId, userId);

            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Introdu un input valid...");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch (Exceptii)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incearca din nou...");
                Console.ForegroundColor = ConsoleColor.White;
                /*throw new LibraryMSException("Some unknown exception is occured..");*/
            }
        }
        private void RecievedSection()
        {
            bool recLoop = true;
            while (recLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Bun-venit-Sectiunea-Acceptat--------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Apasa 1 pentru a afisa cererile acceptate\n" +
                        "2) Apasa 2 pentru a anula o cerere acceptata\n" +
                        "3) Apasa 3 pentru a iesi");
                    int recCase = int.Parse(Console.ReadLine());
                    switch (recCase)
                    {
                        case 1:
                            UserMeniu userPL = new UserMeniu();
                            userPL.GetRecievedBook();
                            break;
                        case 2:
                            DeleteRecieved();
                            break;
                        case 3:
                            Console.WriteLine();
                            recLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Input invalid!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exceptii)
                {
                    throw new Exceptii("Eroare..");
                }
            }
        }
    }
}
