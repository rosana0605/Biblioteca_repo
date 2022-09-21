using BibliotecaEntitati;
using BibliotecaExceptii;
using BibliotecaValidari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class UserMeniu
    {
        private User user = new User();
        //MENIU USER
        private void GetUserMenu()
        {
            Console.WriteLine("1) Apasa 1 pentru a adauga un utilizator\n" +
                "2) Apasa 2 pentru a modifica un utilizator\n" +
                "3) Apasa 3 pentru a sterge un utilizator\n" +
                "4) Apasa 4 pentru a afisa toti utilizatorii\n" +
                "5) Apasa 5 pentru a iesi");
        }
        //ADAUGARE USER
        private void AddUser()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Introdu detaliile utilizatorului..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Id user: ");
                user.UserId = int.Parse(Console.ReadLine());
                Console.Write("Nume user: ");
                user.UserName = Console.ReadLine();
                Console.Write("Email: ");
                user.UserEmail = Console.ReadLine();
                Console.Write("Parola: ");
                user.UserPassword = Console.ReadLine();
                UserValidari userBLL = new UserValidari();
                userBLL.AddUsersBLL(user);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Introdu un input valid!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exceptii)
            {
                throw new Exceptii("Eroare..");
            }
        }
        //MODIFICARE USER
        private void UpdateUser()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Introdu detaliile utilizatorului..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Id user: ");
                user.UserId = int.Parse(Console.ReadLine());
                Console.Write("Nume user: ");
                user.UserName = Console.ReadLine();
                Console.Write("Email: ");
                user.UserEmail = Console.ReadLine();
                Console.Write("Parola: ");
                user.UserPassword = Console.ReadLine();
                UserValidari userBLL = new UserValidari();
                userBLL.UpdateUsersBLL(user);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Introdu un input valid!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exceptii)
            {
                throw new Exceptii("Eroare..");
            }
        }
        //STERGERE USER
        private void RemoveUser()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Introdu detaliile utilizatorului..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Id user: ");
                int userId = int.Parse(Console.ReadLine());
                UserValidari userBLL = new UserValidari();
                userBLL.RemoveUsersBLL(userId);
            }
            catch (Exceptii)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Introdu un input valid");
                Console.ForegroundColor = ConsoleColor.White;
            }
            /*catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                throw new Exceptii("Some unknown exception is occured..");
            }*/
        }
        //AFISARE USERI
        private void GetAllUser()
        {
            List<User> users = new List<User>();
            UserValidari userBLL = new UserValidari();
            users = userBLL.GetAllUsersBLL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------Lista-utilizatori---------------------------");

            Console.WriteLine("--Id-----Nume---------------Email------------------Parola-----");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (User user in users)
            {
                Console.WriteLine("  " + user.UserId + "\t" + user.UserName + "\t " + user.UserEmail + "\t" + user.UserPassword);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //SECTIUNE COMPLETA
        public void UserSection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Bun-venit-Sectiunea-utilizator-------------");
            Console.ForegroundColor = ConsoleColor.White;
            bool userLoop = true;
            while (userLoop == true)
            {
                try
                {
                    GetUserMenu();
                    int userCase = int.Parse(Console.ReadLine());
                    switch (userCase)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            UpdateUser();
                            break;
                        case 3:
                            RemoveUser();
                            break;
                        case 4:
                            GetAllUser();
                            break;
                        case 5:
                            Console.WriteLine();
                            userLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!!!");
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



        //COD PT USER INDIVIDUAL.....

        //INDIVIDUAL USER LOGIN
        public void UserLogin()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("User-Login-----------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Email Id: ");
                string userEmail = Console.ReadLine();
                Console.Write("Parola: ");
                string userPass = Console.ReadLine();
                UserValidari userBLL = new UserValidari();
                bool isDone = userBLL.UserLogin(userEmail, userPass);
                if (isDone)
                {
                    int userId = userBLL.GetUserIdBLL(userEmail);
                    UserHomeSection(userId);
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
        //MENIU HOME
        private void GetUserHomeMenu()
        {
            Console.Write("1) Apasa 1 pentru a afisa sectiunea carte\n" +
                "2) Apasa 2 pentru a afisa sectiunea cererilor\n" +
                "3) Apasa 3 pentru a afisa sectiunea primiri\n" +
                "4) Apasa 4 pentru ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("logout");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        private void UserHomeSection(int userId)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Bun-venit-Sectiunea-Utilizator--------------");
            Console.ForegroundColor = ConsoleColor.White;
            bool userLoop = true;
            while (userLoop == true)
            {
                try
                {
                    GetUserHomeMenu();
                    int userCase = int.Parse(Console.ReadLine());
                    switch (userCase)
                    {
                        case 1:
                            CarteMeniu bookPL = new CarteMeniu();
                            bookPL.GetAllBook();
                            break;
                        case 2:
                            RequestSection(userId);
                            break;
                        case 3:
                            RecieveSection(userId);
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Delogat cu succes..\nSa ai o zi frumoasa...");
                            Console.ForegroundColor = ConsoleColor.White;
                            userLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!!!");
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
        //MENIU CERERE
        private void RequestSection(int userId)
        {
            bool reqLoop = true;
            while (reqLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Bun-venit-Sectiunea-Cereri--------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Apasa 1 pentru a crea o cerere\n" +
                        "2) Apasa 2 pentru a afisa catile cerute\n" +
                        "3) Apasa 3 pentru a iesi");
                    int reqCase = int.Parse(Console.ReadLine());
                    switch (reqCase)
                    {
                        case 1:
                            RequestBook(userId);
                            break;
                        case 2:
                            GetUserRequestBook(userId);
                            break;
                        case 3:
                            Console.WriteLine("");
                            reqLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!!!");
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
        private void RequestBook(int userId)
        {
            try
            {
                Console.Write("Id Carte: ");
                int bookId = int.Parse(Console.ReadLine());
                UserValidari userBLL = new UserValidari();
                userBLL.RequestBookBLL(bookId, userId);
            }
            catch (Exceptii)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Introdu un inout valid...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            /*catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                throw new Exceptii("Some unknown exception is occured..");
            }*/

        }
        //AFISARE CARTI CERUTE
        private void GetUserRequestBook(int userId)
        {
            UserValidari userBLL = new UserValidari();
            List<RequestedBook> requestedBooks = userBLL.GetRequestBookBL();
            List<RequestedBook> requestedBooksUser = requestedBooks.FindAll(s => s.UserId == userId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------Lista-carti-cerute-----------------\n" +
                              "--Id-Carte---Nume-Carte---------Data-Cererii--------");

            Console.ForegroundColor = ConsoleColor.White;
            foreach (RequestedBook requested in requestedBooksUser)
            {
                Console.WriteLine("  " + requested.BookId + "\t" + requested.BookName + "\t\t" + requested.DateRequested.ToShortDateString());
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //CARTI PRIMITE
        private void RecieveSection(int userId)
        {
            bool recLoop = true;
            while (recLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Bun-venit-Sectiunea-Carti-Primite--------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Apasa 1 pentru a restitui o carte primita\n" +
                        "2) Apasa 2 pentru a afisa cartile primite\n" +
                        "3) Apasa 3 pentru a iesi");
                    int recCase = int.Parse(Console.ReadLine());
                    switch (recCase)
                    {
                        case 1:
                            DeleteReieve(userId);
                            break;
                        case 2:
                            GetUserRecievedBook(userId);
                            break;
                        case 3:
                            Console.WriteLine("");
                            recLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (Exceptii)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        private void GetUserRecievedBook(int userId)
        {
            UserValidari userBLL = new UserValidari();
            List<RecievedBook> recievedBooks = userBLL.GetRecievedBookBLL();
            List<RecievedBook> recievedBooksUser = recievedBooks.FindAll(s => s.UserId == userId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------Lista-Carti-Primite-----------------\n" +
                              "--Id-Carte---Nume-Carte---------Data-Primirii----------");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (RecievedBook recieved in recievedBooksUser)
            {
                Console.WriteLine("  " + recieved.BookId + "\t" + recieved.BookName + "\t\t" + recieved.DateRecieved.ToShortDateString());
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void GetRequestBook()
        {
            UserValidari userBLL = new UserValidari();
            List<RequestedBook> requestedBooks = userBLL.GetRequestBookBL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------User+Carte-Lista-Cereri------------------------\n" +
                              "--Id-Carte---Nume-Carte-------Data--------User-Id---User-Name-----");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (RequestedBook requested in requestedBooks)
            {
                Console.WriteLine(" " + requested.BookId + "\t" + requested.BookName + "\t"
                    + requested.DateRequested.ToShortDateString() + "\t" + requested.UserId + "\t" + requested.UserName);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void GetRecievedBook()
        {
            UserValidari userBLL = new UserValidari();
            List<RecievedBook> recievedBooks = userBLL.GetRecievedBookBLL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------User+Carte-Lista-Primiri-------------------------\n" +
                              "--Id-Carte---Nume-Carte-------Data---------User-Id---User-Name-----");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (RecievedBook recieved in recievedBooks)
            {
                Console.WriteLine(" " + recieved.BookId + "\t" + recieved.BookName + "\t"
                    + recieved.DateRecieved.ToShortDateString() + "\t" + recieved.UserId + "\t" + recieved.UserName);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

        }
        //INAPOIAZA O CARTE
        private void DeleteReieve(int userId)
        {
            try
            {
                Console.Write("Id Carte: ");
                int bookId = int.Parse(Console.ReadLine());
                UserValidari userBLL = new UserValidari();
                userBLL.DeleteRecievedBLL(bookId, userId);

            }
            catch (Exceptii)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Introdu un input valid...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            /*catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                throw new Exceptii("Some unknown exception is occured..");
            }*/
        }
    }
}
