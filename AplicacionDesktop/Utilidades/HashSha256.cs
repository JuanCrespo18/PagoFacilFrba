using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Utilidades
{
    class HashSha256
    {
        public static String hashTo256(String password) {

            SHA256Managed manager = new SHA256Managed();
            String hash = string.Empty;
            byte[] encriptacion = manager.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte bit in encriptacion)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }
    }
}
