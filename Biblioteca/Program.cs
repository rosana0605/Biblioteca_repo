using BibliotecaExceptii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {

            bool logLoop = true;
            while (logLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Bun venit la sistemul de gestiune al bibliotecii");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Apasa 1 pentru logare ca Admin\n" +
                    "2) Apasa 2 pentru logare ca User\n" +
                    "3) Apasa 3 pentru a iesi");

                    int logCase = int.Parse(Console.ReadLine());
                    switch (logCase)
                    {
                        case 1:
                            AdminMeniu adminPL = new AdminMeniu();
                            adminPL.AdminLogin();
                            break;
                        case 2:
                            UserMeniu userPL = new UserMeniu();
                            userPL.UserLogin();
                            break;
                        case 3:
                            logLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Introdu un input valid...");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    logLoop = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incearca din nou...");
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
