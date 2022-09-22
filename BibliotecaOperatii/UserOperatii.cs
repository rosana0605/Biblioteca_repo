using BibliotecaEntitati;
using BibliotecaExceptii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaOperatii
{
    public class UserOperatii
    {
        private static List<User> users = new List<User>();

        //RETURNARE USERI
        public List<User> GetAllUserssDAL()
        {
            return users;
        }
        //ADAUGARE USER
        public bool AddUsersDAL(User user)
        {
            bool isDone = false;
            try
            {
                User addUser = new User()
                {
                    UserId = user.UserId,
                    UserEmail = user.UserEmail,
                    UserName = user.UserName,
                    UserPassword = user.UserPassword
                };
                users.Add(addUser);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new Exceptii(e.Message);

            }
            return isDone;
        }
        //MODIFICARE USER
        public bool UpdateUsersDAL(User user)
        {
            bool isDone = false;
            try
            {
                User updateUser = users.Find(s => s.UserId == user.UserId);
                updateUser.UserEmail = user.UserEmail;
                updateUser.UserName = user.UserName;
                updateUser.UserPassword = user.UserPassword;
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new Exceptii(e.Message);

            }
            return isDone;
        }
        //STERGERE USER
        public bool RemoveUsersDAL(int userId)
        {
            bool isDone = false;
            try
            {
                User removeUser = users.Find(s => s.UserId == userId);

                users.Remove(removeUser);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new Exceptii(e.Message);

            }
            return isDone;
        }

        //LISTA UTILIZATA PT MEMORAREA CERERILOR
        public static List<RequestedBook> requestedBooks = new List<RequestedBook>();
        //LISTA PT MEMORAREA CARTILOR PRIMITE
        public static List<RecievedBook> recievedBooks = new List<RecievedBook>();

        //COD PT USERI INDIVIDUALI......
        //CERERE PT A IMPRUMUTA O CARTE
        public bool RequestBookDAL(int bookId, int userId)
        {
            bool isDone = false;
            try
            {
                User user = users.Find(u => u.UserId == userId);
                Carte book = CarteOperatii.books.Find(b => b.BookId == bookId);
                book.BookCopies = book.BookCopies - 1;
                requestedBooks.Add(new RequestedBook()
                {
                    BookId = book.BookId,
                    BookName = book.BookName,
                    DateRequested = DateTime.Now.Date,
                    UserId = user.UserId,
                    UserName = user.UserName
                });
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new Exceptii(e.Message);

            }
            return isDone;
        }
        //RETRAGERE CARTI CERUTE
        public List<RequestedBook> GetRequestBookDAL()
        {
            return requestedBooks;
        }
        //ACCEPT CERERE CARTE DE LA USER INDIVIDUAL
        public bool AcceptRequestDAL(int userId, int bookId)
        {
            bool isDone = false;
            try
            {
                RequestedBook requestBook = requestedBooks.Find(r => r.UserId == userId && r.BookId == bookId);
                RecievedBook recievedBook = new RecievedBook()
                {
                    BookId = requestBook.BookId,
                    BookName = requestBook.BookName,
                    DateRecieved = DateTime.Now.Date,
                    UserId = requestBook.UserId,
                    UserName = requestBook.UserName
                };
                recievedBooks.Add(recievedBook);
                requestedBooks.Remove(requestBook);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new Exceptii(e.Message);

            }
            return isDone;
        }
        //RETRAGERE INFO CARTI PRIMITE
        public List<RecievedBook> GetRecievedBookDAL()
        {
            return recievedBooks;
        }
        //RESTITUIRE CARTE PLUS CALCUL PENALITATE
        public double DeleteRecievedDAL(int bookId, int userId)
        {
            bool isDone = false;

            double penalty = 0;
            try
            {
                Carte book = CarteOperatii.books.Find(b => b.BookId == bookId);
                RecievedBook delRecievedBook = recievedBooks.Find(d => d.BookId == bookId && d.UserId == userId);

                recievedBooks.Remove(delRecievedBook);
                book.BookCopies = book.BookCopies + 1;
                penalty = 0;
                //delRecievedBook.DateRecieved = new DateTime(2022, 9, 4); --testare penalizare
                if (DateTime.Compare(DateTime.Now.Date, delRecievedBook.DateRecieved.AddDays(14))>0)
                {
                    penalty = double.Parse(book.BookPrice) / 100 * (DateTime.Now.Date - delRecievedBook.DateRecieved.AddDays(14)).TotalDays; //se poate verifica cu o data hardcodata--presupunem in viata reala ca momentul curent este cel in care se inapoiaza cartea si atunci se face calculul
                }
                //isDone = true;
            }
            catch (ApplicationException e)
            {
                //isDone = false;
                penalty = 1;
                throw new Exceptii(e.Message);

            }
            return penalty;
        }
    }
}
