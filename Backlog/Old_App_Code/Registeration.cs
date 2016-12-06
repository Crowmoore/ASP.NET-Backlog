using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;

namespace Backlog
{
    public class Registeration
    {
        private string username;
        private string email;
        private string password;
        private string hash;

        public Registeration(string username, string password, string email)
        {
            this.username = username;
            this.password = Login.HashPassword(password);
            this.email = email;
            this.hash = GenerateVerificationHash();
        }
        private string GenerateVerificationHash()
        {
            Random rand = new Random();
            string hash = Login.HashPassword(rand.Next(0, 1000).ToString());
            return hash;
        }

        public bool RegisterUser()
        {
            try
            {
                Database.AddUserToDatabase(this.username, this.password, this.email, this.hash);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}