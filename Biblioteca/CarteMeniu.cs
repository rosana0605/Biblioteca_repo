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
    class CarteMeniu
    {
        private Carte book = new Carte();
        //MENIU CARTE
        private void GetBookMenu()
        {
            Console.WriteLine("1) Apasa 1 pentru a adauga o carte\n" +
                "2) Apasa 2 pentru a modifica o carte\n" +
                "3) Apasa 3 pentru a sterge o carte\n" +
                "4) Apasa 4 pentru a afisa toate cartile disponibile\n" +
                "5) Apasa 5 pentru a iesi");
        }
        //ADAUGARE CARTE
        private void AddBook()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Introdu detaliile cartii..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Id Carte: ");
                book.BookId = int.Parse(Console.ReadLine());
                Console.Write("Nume Carte: ");
                book.BookName = Console.ReadLine();
                Console.Write("Autor Carte: ");
                book.BookAuthor = Console.ReadLine();
                Console.Write("ISBN: ");
                book.BookISBN = Console.ReadLine();
                Console.Write("Pret Carte: ");
                book.BookPrice = Console.ReadLine();
                Console.Write("Disponibila: ");
                book.BookDisp = Console.ReadLine();
                Console.Write("Copii: ");
                book.BookCopies = int.Parse(Console.ReadLine());
                CarteValidari addBook = new CarteValidari();
                addBook.AddBookBLL(book.BookId, book.BookName, book.BookAuthor, book.BookISBN, book.BookPrice, book.BookDisp, book.BookCopies);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Introdu un input valid");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exceptii)
            {
                throw new Exceptii("Eroare..");
            }
        }
        //MODIFICARE CARTE
        private void UpdateBook()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Introdu detaliile cartii..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Id Carte: ");
                book.BookId = int.Parse(Console.ReadLine());
                Console.Write("Nume Carte: ");
                book.BookName = Console.ReadLine();
                Console.Write("Autor: ");
                book.BookAuthor = Console.ReadLine();
                Console.Write("ISBN: ");
                book.BookISBN = Console.ReadLine();
                Console.Write("Pret Carte: ");
                book.BookPrice = Console.ReadLine();
                Console.Write("Disponibila: ");
                book.BookDisp = Console.ReadLine();
                Console.Write("Copii: ");
                book.BookCopies = int.Parse(Console.ReadLine());
                CarteValidari updateBook = new CarteValidari();
                updateBook.UpdateBookBLL(book.BookId, book.BookName, book.BookAuthor, book.BookISBN, book.BookPrice, book.BookDisp, book.BookCopies);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Introdu un input valid");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exceptii)
            {
                throw new Exceptii("Eroare..");
            }
        }
        //STERGERE CARTE
        private void RemoveBook()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Eroare..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Id Carte: ");
                book.BookId = int.Parse(Console.ReadLine());
                CarteValidari removeBook = new CarteValidari();
                removeBook.RemoveBookBLL(book.BookId);
            }
            catch
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
        //AFISARE CARTI
        public void GetAllBook()
        {
            List<Carte> books = new List<Carte>();
            CarteValidari bookTemp = new CarteValidari();
            books = bookTemp.GetAllBookBLL();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------------------Lista-Carti-------------------------------------------");

            Console.WriteLine("--Id-----Nume Carte-----Autor-----------ISBN-----Pret-----Disponibilitate------Nr copii-----");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Carte book in books)
            {
                Console.WriteLine("  " + book.BookId + "\t" + book.BookName + "\t  " + book.BookAuthor + "\t\t\t" + book.BookISBN + "\t\t\t" + book.BookPrice + "\t\t\t" + book.BookDisp + "\t\t\t" + book.BookCopies);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //SECTIUNE COMPLETA
        public void BookSection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Bun-venit-Sectiunea-Carte-------------");
            Console.ForegroundColor = ConsoleColor.White;
            bool bookLoop = true;
            while (bookLoop == true)
            {
                try
                {
                    GetBookMenu();
                    int bookCase = int.Parse(Console.ReadLine());
                    switch (bookCase)
                    {
                        case 1:
                            AddBook();
                            break;
                        case 2:
                            UpdateBook();
                            break;
                        case 3:
                            RemoveBook();
                            break;
                        case 4:
                            GetAllBook();
                            break;
                        case 5:
                            Console.WriteLine("");
                            bookLoop = false;
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
    }
}
