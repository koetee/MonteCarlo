using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace montecarlo
{
    class PNG
    {
        private static string salt = "X1.13";

        private static int PreSeed = Salt.GetHashCode();
        private static string Seed = "";

        private static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed()) {
              
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash) {
                    sb.Append(b.ToString(salt));
                }

                return sb.ToString();
            }
        }

        private static uint Prepare()
        {
            int result = 0;

            DateTime now = DateTime.Now;
            Seed = Hash(now.ToString("o") + now.ToString("f") + Convert.ToString(PreSeed));

            for (int i = 0; i < Seed.Length; i++) {
                result += (int)(char)Seed[i] ^ 2;
            }


            PreSeed = result;

            return Convert.ToUInt32(result);
        }

        public static string Salt
        {
            get => salt;
            set => salt = value;
        }

        public static int getN(int x)
        {
            uint u = Prepare();
           
            return ((int)u % x);
        }
    }
}
