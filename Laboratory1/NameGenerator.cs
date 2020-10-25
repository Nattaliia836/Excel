using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory1
{
    class NameGenerator
    {
        const int BASE = 26;
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
            foreach(int s in symbols)
            {
                result += ((char)('A' + s)).ToString();
            }
            return result;
        }
    }
}
