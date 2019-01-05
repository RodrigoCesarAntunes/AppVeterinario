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

        public bool Data(string data)
        {
            if (string.IsNullOrEmpty(data))
                return false;

            if (data.Length < 10)
                return false;

            int dia = data.Substring(0, 2).ToInt() ?? 0;
            int mes = data.Substring(3, 2).ToInt() ?? 0;
            int ano = data.Substring(6, 4).ToInt() ?? 0;



            if (dia == 0 || mes == 0 || ano == 0)
                return false;

            if (ano < 1900)
                return false;

            if (mes > 12)
                return false;

            switch (mes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (dia > 31) return false;
                    break;
                case 2:
                    if (dia > 29) return false;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (dia > 30)
                        return false;
                    break;
                default:
                    return true;

            }

            return true;
            
        }

    }
}
