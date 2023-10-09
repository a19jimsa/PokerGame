using System;
using System.IO;

namespace UtilitiesLib
{
    public static class Util
    {
        public static int ConvertStringToInteger(string strNum)
        {
            bool status = Int32.TryParse(strNum, out int num);
            if (status)
            {
                return num;
            }
            return 0;
        }

        public static double ConvertStringtoDouble(string strNUM)
        {
            bool status = Double.TryParse(strNUM, out double num);
            if (status)
            {
                return num;
            }
            return 0;
        }

        public static string ConvertIntToString(int num)
        {
            return num.ToString();
        }
    }
}