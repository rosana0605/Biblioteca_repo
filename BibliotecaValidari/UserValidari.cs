using BibliotecaEntitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BibliotecaOperatii;

namespace BibliotecaValidari
{
    public class UserValidari
    {
        private bool UserValidation(User user)
        {
            bool userValid;

            if (user.UserId == 0 || user.UserId >= 100000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id User invalid!!!, idul trebuie sa fie intre 1 si 100000");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else if (user.UserName.Length <= 3 || user.UserName.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nume user invalid!!!, minimum 2 maximum 30 caractere permise");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else if (user.UserName.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nume user invalid!!!, numele nu trebuie sa contina cifre");
                Console.ForegroundColor = ConsoleColor.White;
                userValid = false;
            }
            else if (!(new Regex("([\\w\\.\\-_]+)?\\w+@[\\w-_]+(\\.\\w+){1,}").IsMatch(user.UserEmail)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email invalid!!!, emailul trebuie sa aiba formatul corespunzator");
                Console.ForegroundColor = ConsoleColor.White;
                userValid = false;
            }
            else if (user.UserPassword.Length <= 7 || user.UserPassword.Length > 15)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Parola invalida!!!, minimum 8 maximum 15 caractere permise");
                Console.ForegroundColor = ConsoleColor.White;

                userValid = false;
            }
            else
            {
                userValid = true;
            }
            return userValid;
        }

        UserOperatii userDAL = new UserOperatii();

        //RETRAGERE INFO USERI
        public List<User> GetAllUsersBLL()
        {
            List<User> users = userDAL.GetAllUserssDAL();
            return users;
        }
        //ADAUGARE USER
        public void AddUsersBLL(User user)
        {
            bool isValidated = UserValidation(user);
            if (isValidated)
            {
                /* UserDAL userDAL = new UserDAL();*/
                bool isDone = userDAL.AddUsersDAL(user);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Utilizator adaugat cu succes...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incearca din nou...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //MODIFICARE USER
        public void UpdateUsersBLL(User user)
        {
            bool isValidated = UserValidation(user);
            if (isValidated)
            {
                UserOperatii userDAL = new UserOperatii();
                bool isDone = userDAL.UpdateUsersDAL(user);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Utilizator modificat cu succes...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incearca din nou...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //STERGERE USER
        public void RemoveUsersBLL(int userId)
        {
            if (userId == 0 || userId >= 100000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id invalid...");
                Console.WriteLine("Incearca din nou...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                /*UserDAL userDAL = new UserDAL();*/
                bool isDone = userDAL.RemoveUsersDAL(userId);
                if (isDone)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Utilizator sters cu succes...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }



        }


        //COD PT USERI INDIVIDUALI......

        //LOGIN USER INDIVIDUAL
        public bool UserLogin(string userEmail, string userPass)
        {
            UserOperatii userDAL = new UserOperatii();
            List<User> users = userDAL.GetAllUserssDAL();
            bool isDone = users.Exists(u => u.UserEmail == userEmail && u.UserPassword == userPass);
            if (isDone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Logat cu succes...");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Email sau parola invalida...");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
        //RETRAGERE USER ID
        public int GetUserIdBLL(string userEmail)
        {
            List<User> users = userDAL.GetAllUserssDAL();
            User user = users.Find(u => u.UserEmail == userEmail);
            return user.UserId;
        }
        //CERERE CARTE
        public void RequestBookBLL(int bookId, int userId)
        {
            Carte book = CarteOperatii.books.Find(b => b.BookId == bookId);
            if (book.BookCopies > 0)
            {
                bool isDone = userDAL.RequestBookDAL(bookId, userId);
                if (isDone)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Carte ceruta cu succes...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cartea dorita nu este disponibila...");
                Console.WriteLine("Incearca din nou...");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        //RETREGERE CARTI CERUTE
        public List<RequestedBook> GetRequestBookBL()
        {
            return userDAL.GetRequestBookDAL();
        }
        //ACCEPTARE CARTE CERUTA
        public void AcceptRequestBLL(int userId, int bookId)
        {
            bool isDone = userDAL.AcceptRequestDAL(userId, bookId);
            if (isDone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Acceptat cu succes...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incearca din nou...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //RETRAGERE CARTI PRIMITE
        public List<RecievedBook> GetRecievedBookBLL()
        {
            return userDAL.GetRecievedBookDAL();
        }
        //RESTITUIRE CARTE
        public void DeleteRecievedBLL(int bookId, int userId)
        {
            double penalty = userDAL.DeleteRecievedDAL(bookId, userId);
            if (penalty == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Carte inapoiata cu succes...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if(penalty == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incearca din nou...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restituire intarziata. Restul de plata este "+penalty);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
