using Renci.SshNet;
using System;
using System.IO;

namespace UploadFileInLinux
{
    class Program
    {
        // Enter your host name or IP here
        private static string host = "192.168.50.183";
        // Enter your sftp username here
        private static string username = "finacusmaster";
        // Enter your sftp password here
        private static string password = "Admin@123";
        public static void Main(string[] args)
        {

            Console.WriteLine("Create client Object");
            using (SftpClient client = new SftpClient(host, 22, username, password))
            {
                Console.WriteLine("Connect to server");
                client.Connect();
                client.CreateDirectory("/home/finacusmaster/Upload/TelegramData");
                client.ChangeDirectory("/home/finacusmaster/Upload/TelegramData");
                Console.WriteLine("Creating FileStream object to stream a file");
                using (FileStream fs = new FileStream(@"E:\projects\Telegram\Texte.txt", FileMode.Open))
                {
                    client.BufferSize = 1024;
                    client.UploadFile(fs, Path.GetFileName(@"E:\projects\Telegram\Texte.txt"));
                }
                client.Dispose();
            }


        }

    }
}







