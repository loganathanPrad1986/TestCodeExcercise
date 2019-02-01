using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;
using System.Configuration;

namespace FileData
{
    public static class Program
    {

        public static string ReturnFileInformation(string fileOption, string filePath)
        {
            string fileInformation = Constant.invalidMessage;
            FileDetails fileDetails = new FileDetails();
            var fileSize = Utility.ReadConfigKeys("size");

            if (fileSize.Split(',').Contains(fileOption))
            {
                fileInformation = Constant.filesSizeMessage + fileDetails.Size(filePath).ToString();

            }
            else
            {

                var fileVersion = Utility.ReadConfigKeys("version");
                if (fileVersion.Split(',').Contains(fileOption))
                {
                    fileInformation = Constant.filesVersionMessage + fileDetails.Version(filePath).ToString();
                }
            }

            return fileInformation;

        }


        public static void Main(string[] args)
        {
            try
            {

                if (Utility.ValidateInput(args))
                {
                    string fileInfo = Program.ReturnFileInformation(args[0], args[1]);
                    Utility.DisplyMessage(fileInfo);
                    Console.Read();

                }
            }
            catch (Exception ex)
            {
                Utility.DisplyMessage(Constant.exceptionMessage + ex.Message.ToString());
                Console.Read();
            }

        }



    }
}
