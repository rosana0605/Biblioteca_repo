using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEntitati;

namespace BibliotecaOperatii
{
    public class AdminOperatii
    {
        private static List<Admin> admins = new List<Admin>()
        {
            new Admin()
            {
                AdminId=1,AdminName="Roxana O",AdminEmail="rox@gmail.com",AdminPassword="123123"
            },
        };
        //RETURNARE ADMIN
        public List<Admin> GetAllAdminsDAL()
        {
            return admins;
        }
    }
}
