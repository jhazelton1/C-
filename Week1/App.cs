using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class App
    {
        static void Main(string[] args)
        {
            //FizzBuzz fizzBuzz = new FizzBuzz(1, 20);
            //Console.WriteLine(fizzBuzz.GetOutput);

            /*List<string> words = new List<string>() { "Deleveled", "Noon", "Racecar", "Java", "CSHARP" }
            words.ForEach(word => Console.WriteLine(Palindrome.isPalindrome(word)));*/

            Console.WriteLine(new FizzBuzzTwo(1, 20).GetOutput());
            Console.WriteLine(new FizzBuzzTwo(1, 20).GetLuckyOutput());
            Console.WriteLine(new FizzBuzzTwo(1, 1000).GetReport());

            Console.ReadKey();
        }
    }
}
