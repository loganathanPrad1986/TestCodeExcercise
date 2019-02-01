using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    public static class Utility
    {

        public static string ReadConfigKeys(string Key)
        {
            return ConfigurationSettings.AppSettings.Get(Key).ToString();
        }

        public static void DisplyMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static bool ValidateInput(string[] message)
        {
            bool validInput = false;
            if (message.Length == 0)
            {
                DisplyMessage("please enter 2 arguments,argument length is not empty. ");
            }
            if (message.Length < 2)
            {
                DisplyMessage("please enter 2 arguments,argument length is incorrect. ");

            }
            if (message.Length == 2)
            {
                var fileSize = Utility.ReadConfigKeys("size");
                var fileVersion = Utility.ReadConfigKeys("version");

                if (fileSize.Split(',').Contains(message[0]) || (fileVersion.Split(',').Contains(message[0])))
                {

                    validInput = true;
                }
                else
                {
                    DisplyMessage("arguments are incorrect. ");

                }

            }

            return validInput;

        }

    }
}
