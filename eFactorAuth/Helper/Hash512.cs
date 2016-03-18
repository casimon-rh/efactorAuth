using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace eFactorAuth.Helper
{
    public static class Hash512
    {
        //public static string go(string texto) => (string.IsNullOrEmpty(texto)) ? Convert.ToBase64String((new SHA512Managed()).ComputeHash(Encoding.Default.GetBytes(texto))) : null;
        public static string go(string texto) => Convert.ToBase64String((new SHA512Managed()).ComputeHash(Encoding.Default.GetBytes(texto)));
        public static string go(string texto, int interacciones, string salt)
        {
            try
            {
                string aux = texto + salt;
                for (int i = 0; i <= interacciones; i++)
                    aux = go(aux);
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}