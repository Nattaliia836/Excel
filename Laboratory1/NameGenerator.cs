using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory1
{
    class NameGenerator
    {
        private const int BASE = 26;
        public static string ConvertToBase26(int index)
        {
            string result = "";
            List<int> symbols = new List<int>();
            while (index > (BASE - 1))
            {
                symbols.Add(index / BASE - 1);
                index %= BASE;
            }
            symbols.Add(index);
            foreach (int s in symbols)
            {
                result += ((char)('A' + s)).ToString();
            }
            return result;
        }

        public static Tuple<int, int> ConvertFromBase26(string nameCell)
        {
            string col = "";
            int row = 0;
            int i = 0;
            while (Char.IsLetter(nameCell[i]))
            {
                col += nameCell[i];
                ++i;
            }
            row = Convert.ToInt32(nameCell.Substring(i)) - 1;
            char[] chArray = col.ToCharArray();
            int length = chArray.Length;
            int column = 0;
            for(int j = length - 2; j >= 0; --j)
            {
                column += (( (int)chArray[j] - (int)'A' ) + 1) * Convert.ToInt32(Math.Pow(BASE, length - j - 1));
            }
            column += ((int)chArray[length - 1] - (int)'A');
            return new Tuple<int, int>(row, column);
        }
    }
}
