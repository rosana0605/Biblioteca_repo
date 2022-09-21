using BibliotecaEntitati;
using BibliotecaOperatii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaValidari
{
    public class CarteValidari
    {
        private bool BookValidation(int bookId, string bookName, string bookAuthor, int bookCopies)
        {
            bool bookValid;

            if (bookId == 0 || bookId >= 100000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id invalid!!!, idul trebuie sa fie intre 1 si 1000000");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }
            else if (bookName.Length <= 2 || bookName.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nume invalid!!!, min 3 si max 30 de caractere permise");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }

            else if (bookAuthor.Length <= 2 || bookAuthor.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nume autor invalid!!!, minimum 3 maximum 30 caractere permise");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }
            else if (bookAuthor.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nume autor invalid!!!, numele nu trebuie sa contina cifre");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }

            else if (bookCopies < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nr copii invalid!!!, numarul trebuie sa fie mai mare ca 0");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }
            else
            {
                bookValid = true;
            }
            return bookValid;
        }


        CarteOperatii dalBook = new CarteOperatii();
        //ADAUGARE CARTE
        public void AddBookBLL(int bookId, string bookName, string bookAuthor, string bookISBN, string bookPrice, string bookDisp, int bookCopies)
        {
            bool isValidated = BookValidation(bookId, bookName, bookAuthor, bookCopies);
            if (isValidated)
            {
                /*BookDAL dalBook = new BookDAL();*/
                bool isDone = dalBook.AddBooksDAL(bookId, bookName, bookAuthor, bookISBN, bookPrice, bookDisp, bookCopies);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Carte adaugata cu succes...");
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
        //MODIFICARE CARTE
        public void UpdateBookBLL(int bookId, string bookName, string bookAuthor, string bookISBN, string bookPrice, string bookDisp, int bookCopies)
        {
            bool isValidated = BookValidation(bookId, bookName, bookAuthor, bookCopies);
            if (isValidated)
            {
                /* BookDAL dalBook = new BookDAL();*/
                bool isDone = dalBook.UpdateBooksDAL(bookId, bookName, bookAuthor, bookISBN, bookPrice, bookDisp, bookCopies);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Carte modificata cu succes...");
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
        //STERGERE CARTE
        public void RemoveBookBLL(int bookId)
        {
            if (bookId != 0 || bookId <= 100000)
            {
                /*BookDAL dalBook = new BookDAL();*/
                bool isDone = dalBook.RemoveBooksDAL(bookId);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Carte stearsa cu succes...");
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
                Console.WriteLine("Id invalid!!!");
                Console.WriteLine("Incearca din nou...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //AFISARE CARTI DISPONIBILE IN BIBLIOTECA
        public List<Carte> GetAllBookBLL()
        {

            List<Carte> books = dalBook.GetAllBooksDAL();
            List<Carte> books_disp = new List<Carte>();
            foreach (Carte book in books)
            {
                if (book.BookCopies == 0)
                {
                    book.BookDisp = "Indisponibila";
                }
                if (book.BookDisp == "Disponibila")
                {
                    books_disp.Add(book);
                }
            }
            return books_disp;
        }
    }
}
