using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_management_system.DataBase.Models
{
    internal class User
    {
        public int Id { get; set; }
        
        private static int IdCounter = 1;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime Created { get; set; }
        public User(string name, string lastName, string email, string password,DateTime created)
        {
            Id = IdCounter++;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Created = created;

        }
    }
}
