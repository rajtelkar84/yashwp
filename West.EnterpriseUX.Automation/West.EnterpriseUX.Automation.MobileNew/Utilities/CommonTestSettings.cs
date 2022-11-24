using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.Mobile.Utilities
{
    public static class CommonTestSettings
    {
        public const string AppiumServerUrl = "http://127.0.0.1:4723/wd/hub";
        //public const string TestUserEmailId = "Test_UX09@westpharma.com";
        //public const string TestUserPassword = "RGSMH1cWt+uachOYx5Mlxq13J0d0dXU64W5HiCGWEvc=";
        //public const string DevTestUserEmailId = "UX-Auto-testuser1@westpharma.com";
        //public const string DevTestUserPassword = "nNzLheKlOF15w7WErR2aSuiErsobi47axQFviCGG+8M=";


        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
    public static class TestResultColumns
    {
        public const string TestName = "TestName";
        public const string TestOutcome = "Status";
        public const string Duration = "Duration";
        public const string ErrorMessage = "ErrorMessage";
        public const string Screenshot = "Screenshot";
    }
}
