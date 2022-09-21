using BibliotecaEntitati;
using BibliotecaExceptii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaOperatii
{
    public class CarteOperatii
    {
        public static List<Carte> books = new List<Carte>();

        //RETURNARE CARTI
        public List<Carte> GetAllBooksDAL()
        {
            return books;
        }
        //ADDAUGARE CARTE
        public bool AddBooksDAL(int bookId, string bookName, string bookAuthor, string bookISBN, string bookPrice, string bookDisp, int bookCopies)
        {
            bool isDone = false;
            try
            {
                Carte addBook = new Carte() { BookId = bookId, BookName = bookName, BookAuthor = bookAuthor, BookISBN = bookISBN, BookPrice = bookPrice, BookDisp = bookDisp, BookCopies = bookCopies };
                books.Add(addBook);
                isDone = true;

            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new Exceptii(e.Message);
            }
            return isDone;
        }
        //MODIFICARE CARTE
        public bool UpdateBooksDAL(int bookId, string bookName, string bookAuthor, string bookISBN, string bookPrice, string bookDisp, int bookCopies)
        {
            bool isDone = false;
            try
            {
                Carte updateBook = books.Find(s => s.BookId == bookId);
                updateBook.BookName = bookName;
                updateBook.BookAuthor = bookAuthor;
                updateBook.BookISBN = bookISBN;
                updateBook.BookPrice = bookPrice;
                updateBook.BookDisp = bookDisp;
                updateBook.BookCopies = bookCopies;
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new Exceptii(e.Message);

            }
            return isDone;
        }
        //STERGERE CARTE
        public bool RemoveBooksDAL(int bookId)
        {
            bool isDone = false;
            try
            {
                Carte removeBook = books.Find(s => s.BookId == bookId);
                books.Remove(removeBook);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new Exceptii(e.Message);
            }
            return isDone;
        }
    }
}
