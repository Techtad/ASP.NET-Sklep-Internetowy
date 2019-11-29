using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace as_webforms_webApi_sklep
{
    public static class KeyGen
    {
        private static string[] chars = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "L", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public static string randomKey()
        {
            string key = "";

            var rand = new Random();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    key += chars[rand.Next(chars.Length)];
                }
                if (i < 2) key += "-";
            }

            return key;
        }
    }
}