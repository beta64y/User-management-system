using System;
using User_management_system.DataBase.Models;
using User_management_system.DataBase.Repository;
using User_management_system.ApplicationLogic;

namespace User_management_system.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string person = "none";
            UserRepository.Add("Admin", "Admin", "adminadmin@code.edu.az", "Admin123");
            Console.WriteLine("Hi , You Can Use /help Command for Get Information about Commads !"); 
            while (true)
            {
                string command = Console.ReadLine();
                if(command == "/help")
                {
                    Console.WriteLine("/exit - close program");
                    Console.WriteLine("/register - allows you to register");
                    Console.WriteLine("/log_in - allows you to log in");
                    Console.WriteLine("/log_in_info - show active account");
                    Console.WriteLine("/get_register_date - shows selected email in register date");
                    Console.WriteLine("/show_users - open admin panel (only admin can use this command)");
                }
                else if(command == "/exit")
                {
                    break;
                }
                else if(command == "/register")
                {
                    bool name_wrongChecker = false, lastname_wrongChecker = false, email_wrongChecker = false, password_wrongChecker = false, re_password_wrongChecker = false;
                    string name = "", lastname = "", email = "", password = "", re_password = "";
                    TextValidation textvalidation = new TextValidation();
                    EmailValidation emailvalidation = new EmailValidation();
                    PasswordValidation passwordvalidation = new PasswordValidation();
                    while(!textvalidation.IsCorrect(name))
                    {
                        if(name_wrongChecker)
                        {
                            Console.WriteLine("The name you entered is incorrect, make sure the name contains only letters,\nthe first letter is capitalized, and the length is greater than 3 and less than 30.");
                        }
                        Console.WriteLine("Enter Name :");
                        name = Console.ReadLine();
                        name_wrongChecker = true;
                    }
                    while(!textvalidation.IsCorrect(lastname))
                    {
                        if (lastname_wrongChecker)
                        {
                            Console.WriteLine("The lastname you entered is incorrect, make sure the lastname contains only letters, \nthe first letter is capitalized, and the length is greater than 3 and less than 30.");
                        }
                        Console.WriteLine("Enter LastName :");
                        lastname = Console.ReadLine();
                        lastname_wrongChecker = true;
                    }
                    while(!emailvalidation.IsCorrect(email))
                    {
                        if (email_wrongChecker)
                        {
                            Console.WriteLine("The email you entered is incorrect, Receipent - can only be composed of letters and \nnumbers, the total length can be min 10 max 30, Separator - there must be an @ in \nbetween Domain - can only end with code.edu.az.");
                        }
                        Console.WriteLine("Enter Email :");
                        email = Console.ReadLine();
                        email_wrongChecker = true;
                    }
                    while (!passwordvalidation.IsCorrect(password))
                    {
                        if (password_wrongChecker)
                        {
                            Console.WriteLine("The password you entered is incorrect, Password - Must contain at least one uppercase \nletter, one lowercase letter and a number, and length cannot be less than 8");
                        }
                        Console.WriteLine("Enter Password:");
                        password = Console.ReadLine();
                        password_wrongChecker = true;
                    }
                    while (!(password == re_password))
                    {
                        if (re_password_wrongChecker)
                        {
                            Console.WriteLine("The password you re-entered is incorrect,Re-entered Password should be the same as the password ");
                        }
                        Console.WriteLine("Re-Enter Password :");
                        re_password = Console.ReadLine();
                        re_password_wrongChecker = true;
                    }
                    UserRepository.Add(name, lastname, email, password);
                    Console.WriteLine("You successfully registered, now you can login with your new account!");

                }
                else if(command == "/log_in")
                {
                    Console.WriteLine("Enter Email :");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter Password:");
                    string password = Console.ReadLine();
                    person = UserRepository.LogIn(email, password);
                    if(person == "none")
                    {
                        Console.WriteLine("Email or password is incorrect");
                    }
                    else if(person == "admin")
                    {
                        Console.WriteLine("Welcome to your account dear Admin ");
                    }
                    else
                    {
                        Console.WriteLine($"Welcome to your account {person}!");
                    }

                }
                else if(command == "/log_in_info")
                {
                    Console.WriteLine("Active account : " + person);
                }
                else if(command == "/get_register_date")
                {
                    Console.WriteLine("Enter Email :");
                    string email = Console.ReadLine();
                    Console.WriteLine("Register date : " + UserRepository.WhenAdded(email));
                }
                else if(command == "/show_users")
                {
                    UserRepository.Show_users(person);
                }
                else
                {
                    Console.WriteLine("Command not Found , You Can Use /help Command for Get Information about Commads !");
                }
            }
        }
    }
}
