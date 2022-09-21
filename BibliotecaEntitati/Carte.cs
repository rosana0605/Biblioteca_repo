using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntitati
{
    public class Carte
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookISBN { get; set; }
        public string BookPrice { get; set; }
        public string BookDisp { get; set; }
        public int BookCopies { get; set; }
        public Carte()
        {
            BookId = 0;
            BookName = string.Empty;
            BookAuthor = string.Empty;
            BookISBN = string.Empty;
            BookPrice = string.Empty;
            BookDisp = string.Empty;
            BookCopies = 0;
        }
    }
}
