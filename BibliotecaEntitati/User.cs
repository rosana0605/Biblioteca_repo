﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntitati
{
    public class User
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
    public class RequestedBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime DateRequested { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
    public class RecievedBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime DateRecieved { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
