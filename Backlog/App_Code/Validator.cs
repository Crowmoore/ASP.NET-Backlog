using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Backlog
{
    public class Validator
    {
        public bool Validate(string username, string password, string email)
        {
            if (CheckUsername(username) && CheckPassword(password) && CheckEmail(email))
            {
                return true;
            }
            return false;
        }

        private bool CheckPassword(string password)
        {
            int specialChars = password.Count(c => !char.IsLetterOrDigit(c));
            if (password.Length > 6 && password.Length < 20 && specialChars == 0)
            {
                return true;
            }
            HttpContext.Current.Session["Error"] = "Password length is 6-20 characters and no special characters";
            return false;
        }

        private bool CheckUsername(string username)
        {
            int specialChars = username.Count(c => !char.IsLetterOrDigit(c));
            if (username.Length > 0 && username.Length <= 10 && specialChars == 0)
            {
                return true;
            }
            HttpContext.Current.Session["Error"] = "Username length is 1-10 characters and no special characters";
            return false;
        }

        private bool CheckEmail(string email)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                return true;
            }
            HttpContext.Current.Session["Error"] = "Not a valid email";
            return false;
        }

    }
}