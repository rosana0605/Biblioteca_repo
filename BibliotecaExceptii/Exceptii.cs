using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaExceptii
{
    public class Exceptii:ApplicationException
    {
        public Exceptii() : base()
        {

        }
        public Exceptii(string message) : base(message)
        {

        }
        public Exceptii(string msg, FormatException InneException) : base(msg, InneException)
        {

        }
    }
}
