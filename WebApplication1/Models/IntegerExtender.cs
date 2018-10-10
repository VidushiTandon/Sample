using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public static class IntegerExtender
    {
        public static int Reverse(this int x)
        {
            string str = x.ToString();
            char[] ary = str.ToCharArray();
            string temp = "";
            for(int i = ary.Length - 1; i >= 0; i--)
            {
                temp += ary[i];
            }
            int n = Convert.ToInt32(temp);
            return n;
        }
    }
}
