using System;
using System.Linq;
using System.Text;

namespace Main
{
    public static class Converter
    {
        public static string ConvertToString(string value)
        {
            var counter = 0;
            var sb = new StringBuilder();
            for (var index = value.Length - 1; index >= 0; index--)
            {
                sb.Append(value[index]);
                counter++;
                
                if (counter < 3)
                    continue;

                counter = 0;
                
                if (index != 0 && value[index - 1] != '-')
                    sb.Append('.');
            }

            var array = sb.ToString().ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public static bool ConvertToInt(string value, out int result)
        {
            var clearString = new string(value.Where(item => item != '.').ToArray());
            return int.TryParse(clearString, out result);
        }
    }

}