using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Palindrome
    {
        public static Boolean isPalindrome(string word)
        {
            return word.ToLower().Equals(String.Join("", word.ToLower().ToCharArray().Reverse()));
        }
    }
}
