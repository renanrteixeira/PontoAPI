using System.Text;
using System.Security.Cryptography;

namespace PontoAPI.Core.Helper
{
    public static class Hash
    {
        public static string GerarHash(string password){
            
            var tmpSource = ASCIIEncoding.ASCII.GetBytes(password);

            var result = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            
            return ByteArrayToString(result);
        }

        public static bool CompareHash(string password, string passwordDb){

            var tmpSource = ASCIIEncoding.ASCII.GetBytes(password);

            var tmpPasswordDb = ASCIIEncoding.ASCII.GetBytes(passwordDb);

            var tmpNewHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            var i = 0;
            if (tmpNewHash.Length == tmpPasswordDb.Length)
            {
                while ((i < tmpNewHash.Length) && (tmpNewHash[i] == tmpPasswordDb[i]))
                {
                    i += 1;
                }
            }

            return i == tmpNewHash.Length;
        }

        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i=0;i < arrInput.Length -1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}