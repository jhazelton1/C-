using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    public class FizzBuzz
    {

        private int x;
        private int y;
        public FizzBuzz()
        {

        }

        public FizzBuzz(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetRange(int startNumber, int endNumber)
        {
            this.x = startNumber;
            this.y = endNumber;
        }

        public virtual string GetOutput()
        {
            string output = "";

            if (this.x >= this.y)
            {
                return "";
            }

            for (int i = this.x; i <= this.y; i++)
            {

                if (i == 0)
                {
                    output += i + " ";
                }
                else if (i % 3 == 0 && i % 5 == 0)
                {
                    output += "fizzbuzz ";
                }
                else if (i % 3 == 0)
                {
                    output += "fizz ";
                }
                else if (i % 5 == 0)
                {
                    output += "buzz ";
                }
                else
                {
                    output += i + " ";
                }
            }


            return output.Substring(0, output.Length - 1);

        }

    }

}
