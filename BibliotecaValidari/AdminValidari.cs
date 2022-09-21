using BibliotecaEntitati;
using BibliotecaOperatii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaValidari
{
    public class AdminValidari
    {
        public bool AdminLogin(string adminEmail, string adminPass)
        {
            AdminOperatii adminOp = new AdminOperatii();
            List<Admin> admins = adminOp.GetAllAdminsDAL();
            bool isDone = admins.Exists(a => a.AdminEmail == adminEmail && a.AdminPassword == adminPass);
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
    }
}
