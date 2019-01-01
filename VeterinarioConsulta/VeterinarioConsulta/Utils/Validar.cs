using System;
using System.Collections.Generic;
using System.Text;

namespace VeterinarioConsulta.Utils
{
    public class Validar
    {
        public bool Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            else if (email.Length < 5)
                return false;
            else if (!email.Contains("@") && !email.Contains("."))
                return false;
            else if (email.IndexOf("@") == 0)
                return false;
            else if (!email.Substring(email.IndexOf("@")).Contains("."))
                return false;

            return true;
        }

        public bool CPF()
        {
            return true;
        }
    }
}
