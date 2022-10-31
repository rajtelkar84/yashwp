using System;
using System.IO;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class Helper
    {
        public void CreateFolder(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public string GenerateRandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    s = "9";
                }
                else
                {
                    s = String.Concat(s, random.Next(10).ToString());
                }
            }

            return s;
        }
        public string GenerateUniqueRandomNumber()
        {
            Random random = new Random();
            return DateTime.Now.ToString("ddMMyy") + random.Next(1, 100).ToString();
        }
        public int GenerateRandomNumber(int maxNumber)
        {
            Random random = new Random();
            return random.Next(1, maxNumber);
        }

        public void DeleteDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    //Delete all files from the Directory
                    foreach (string file in Directory.GetFiles(path))
                    {
                        File.Delete(file);
                    }
                    //Delete all child Directories
                    foreach (string directory in Directory.GetDirectories(path))
                    {
                        DeleteDirectory(directory);
                    }
                    //Delete a Directory
                    Directory.Delete(path);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
