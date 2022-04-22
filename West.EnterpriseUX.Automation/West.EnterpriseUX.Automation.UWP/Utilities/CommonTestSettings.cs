using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace West.EnterpriseUX.Automation.UWP.Utilities
{
    public static class CommonTestSettings
    {
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        public const string appCenterURL = "https://install.appcenter.ms/sign-in?original_url=install://";
        public const string feedbackAPI = "https://enterpriseux-fd-dev.azurefd.net/email/userfeedback";
        public const string LoginBaseURL = "https://login.microsoftonline.com/61a70d37-ff63-45e3-bb68-f0edbf718ffd";
        public const string APIResouceURL = "https://enterpriseuxapi-dev.azurewebsites.net/";
        public const string APIResouceDvv = "https://enterpriseuxapi-dvv.azurewebsites.net/";
        public const string APIResouceUAT = "https://enterpriseuxapi-uat.azurewebsites.net/";
        public const string APIResoucePreProd = "https://enterpriseuxapi-preprod.azurewebsites.net/";
        public const string ClientId = "cac78be3-00a2-4c2c-b9e0-af008b4a1fad";
        public const string ClientSecret = "IdJLVd1.WLOm]E/8R:PwYm9QcCcm6sWB";
        public const string GrantType = "client_credentials";
        public const string AzureKeyVaultClientId = "9d9bdd28-3aee-473a-8231-eac7a8515a60";
        public const string AzureKeyVaultBaseURI = "https://enterpriseux-kv-uat.vault.azure.net/";
        public const string AzureKeyVaultClientSecret = "P87HZ1BFV6~.3qMFUbEYec.Fe.a_30.3Lx";

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
    public static class TestInboxFields
    {
        public const string SINO = "SINO";
        public const string InboxName = "InboxName";
        public const string InboxOutcome = "InboxOutcome";
        public const string InboxStatus = "InboxStatus";
        public const string ElapsedTime = "ElapsedTime";
        public const string AppMemory = "AppMemory";
        public const string Screenshot = "Screenshot";
    }
}
