using System;
using System.Collections.Generic;
using System.Text;

namespace VeterinarioConsulta.Utils
{
    public static class ParseDeString
    {

        /// <summary>
        /// Comverte String para Inteiro sem a necessidade de uma validação
        /// </summary>
        /// <param name="inteiro"></param>
        /// <returns></returns>
        public static int ToInt(this string inteiro)
        {
            int resultado;
            int.TryParse(inteiro, out resultado);
            return resultado;
        }

        /// <summary>
        /// Comverte String para Double sem a necessidade de uma validação
        /// </summary>
        /// <param name="inteiro"></param>
        /// <returns></returns>
        public static double ToDouble(this string Double)
        {
            double resultado;
            double.TryParse(Double, out resultado);
            return resultado;
        }

        /// <summary>
        /// Comverte String para Float sem a necessidade de uma validação
        /// </summary>
        /// <param name="inteiro"></param>
        /// <returns></returns>
        public static float ToFloat(this string Flutuante)
        {
            float resultado;
            float.TryParse(Flutuante, out resultado);
            return resultado;
        }

        /// <summary>
        /// Comverte String para Decimal sem a necessidade de uma validação
        /// </summary>
        /// <param name="inteiro"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string Decimal)
        {
            decimal resultado;
            decimal.TryParse(Decimal, out resultado);
            return resultado;
        }

        /// <summary>
        /// Comverte String para Boolean sem a necessidade de uma validação
        /// </summary>
        /// <param name="inteiro"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string Boolean)
        {
            bool resultado;
            bool.TryParse(Boolean, out resultado);
            return resultado;
        }


    }
}
