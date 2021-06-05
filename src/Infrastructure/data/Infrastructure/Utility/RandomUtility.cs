using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Infrastructure.Utility
{
   
    public class RandomUtility : IRandomUtility
    {
        public int GenerateRandomNumber(int digit)
        {
            Random ran = new Random();
            int minValue = (int)Math.Pow(10, digit);
            int maxValue = (int)Math.Pow(10, digit+1)-1;
            return ran.Next(minValue,maxValue);
        }

        public string GenerateRandomString(int length)
        {
            Random ran = new Random();
            string b = "123456789ABCDEFGHJKLMNPRTUWXY";      
            string random =string.Empty;

            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(b.Length);
                random = random + b.ElementAt(a);
            }
            return random;
        }
    }
}
