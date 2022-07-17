using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_management_system.DataBase.Models;

namespace User_management_system.DataBase.Repository
{
    internal class UserRepository
    {
        public static List<User> Userslist = new List<User>();
    public static void Add(string name ,string lastname ,string email ,string password)
        {
            DateTime created = DateTime.Now;
            User user = new User(name,lastname,email,password,created);
            Userslist.Add(user);
    }
    public static string WhenAdded(string email)
        {
            foreach (User user in Userslist)
            {
                if (user.Email == email)
                {
                    return user.Created.ToString();
                }
            }
            return "not Found";
        }
        public static string LogIn(string email, string password)
        {
            foreach (User user in Userslist)
            {
                if (email == "admin@gmail.com" && password == "123321")
                {
                    return "admin";
                }
                if (user.Email == email && user.Password == password)
                {
                    return $"{user.Name} {user.LastName} {user.Email}";
                }
            }
            return "none";
            
        }
        public static void  Show_users(string person)
        {
            if (person == "admin")
            {
                foreach (User user in Userslist)
                {
                    Console.WriteLine($"Name : \"{user.Name} {user.LastName}\" \nEmail : {user.Email} | Password : {user.Password} | ID : {user.Id} | Register Date : {user.Created.ToString()}");
                    Console.WriteLine("********************************************************");
                }
            }
            else { Console.WriteLine("Only admin can use this command"); }

        }
        
     









    }
    
}
