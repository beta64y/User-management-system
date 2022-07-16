using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using User_management_system.DataBase.Models;
using User_management_system.DataBase.Repository;

namespace User_management_system.ApplicationLogic
{
    

    public class Validations
    {
        public virtual bool IsCorrect(string text)
        {
            return true;
        }

    }
    public class TextValidation : Validations
    {
        
        public override bool IsCorrect(string text)
        {
            Regex validationText = new Regex(@"^[A-Z][a-z]{2,29}$");
            if (validationText.IsMatch(text))
            {
                return true;
            }
            return false;
        }
    }
    public class EmailValidation : Validations
    {
        
        public override bool IsCorrect(string text)
        {
            Regex validationText = new Regex(@"^([a-zA-Z0-9]{10,30})(@code\.edu\.az)$");
            if (validationText.IsMatch(text))
            {
                foreach(User user in UserRepository.Userslist)
                {
                    if (user.Email == text)
                    {
                        return false;
                    }

                }
                return true;
            }
            return false;
        }
    }
    public class PasswordValidation : Validations
    {
        public override bool IsCorrect(string text)
        {
            bool upper = false, lower = false, digit = false;
            
            foreach (char character in text)
            {
                if (char.IsUpper(character)) { upper = true; }
                if (char.IsLower(character)) { lower = true; }
                if (char.IsDigit(character)) { digit = true; }
            }
            if( upper && lower && digit && text.Length >=8)
            {
                return true;
            }
            return false;


        }
    }
}
