using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    public class FizzBuzzTwo : FizzBuzz
    {
        public FizzBuzzTwo(int x, int y) : base(x, y)
        {

        }

        public string GetLuckyOutput()
        {
            return this.GetOutput().Equals("") ? "" : string.Join(" ", this.GetOutput().Split(' ').Select((c, i) => (i + 1).ToString().Contains("3") ? c = "lucky" : c));
        }

        public Dictionary<string, int> StringToDictionary(string str)
        {
            if (str.Length == 0)
            {
                return new Dictionary<string, int>();
            }

            return str.Split(' ').Aggregate(new Dictionary<string, int>(), (acc, c) =>
            {
                int tmp;
                if (Int32.TryParse(c, out tmp))
                {
                    if (acc.ContainsKey("integer"))
                    {
                        acc["integer"] = acc["integer"] += 1;
                    }
                    else
                    {
                        acc["integer"] = 1;

                    }
                }
                else if (acc.ContainsKey(c))
                {
                    acc[c] = acc[c] += 1;
                }
                else
                {
                    acc[c] = 1;
                }

                return acc;

            });
        }

        public string GetReport()
        {
            string report = "";

            Dictionary<string, int> dictionary = StringToDictionary(this.GetLuckyOutput());

            List<string> keys = new List<string>(dictionary.Keys);

            if (keys.Count() == 0)
            {
                return "No Report Available";
            }

            keys.ForEach(key => report += key + ": " + dictionary[key] + "\n");


            return report;
        }

    }
}
