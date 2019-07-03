using System;
using Week1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Week1Tests
{
    [TestClass]
    public class FizzBuzzTwoTest
    {
        [TestMethod]
        public void NoReportAvailableOnEmptyString()
        {

            FizzBuzzTwo fizzBuzzTwo = new FizzBuzzTwo(0, 0);
            string report = fizzBuzzTwo.GetReport();

            Assert.IsTrue(report.Equals("No Report Available"));
        }

        [TestMethod]
        public void ReturnEmptyDictionary()
        {
            FizzBuzzTwo fizzBuzzTwo = new FizzBuzzTwo(0, 0);
            string output = fizzBuzzTwo.GetLuckyOutput();

            Assert.IsTrue(fizzBuzzTwo.StringToDictionary(output).Keys.Count == 0);
        }

        [TestMethod]
        public void LuckyOutputChangesThreeToLucky()
        {
            FizzBuzzTwo fizzBuzzTwo = new FizzBuzzTwo(1, 30);
            
            string[] luckyOutputArray = fizzBuzzTwo.GetLuckyOutput().Split(' ');

            Assert.IsTrue(luckyOutputArray[3 - 1] == "lucky");
            Assert.IsTrue(luckyOutputArray[13 - 1] == "lucky");
            Assert.IsTrue(luckyOutputArray[23 - 1] == "lucky");
            Assert.IsTrue(luckyOutputArray[30 - 1] == "lucky");
        }

        [TestMethod]
        public void GetLuckyOutputTest()
        {
            FizzBuzzTwo fizzBuzzTwo = new FizzBuzzTwo(1, 20);
            string expected = "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz";
            string actual = fizzBuzzTwo.GetLuckyOutput();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetReportTest()
        {
            FizzBuzzTwo fizzBuzzTwo = new FizzBuzzTwo(1, 20);
            string expected = "integer: 10\nlucky: 2\nbuzz: 3\nfizz: 4\nfizzbuzz: 1\n";
            string actual = fizzBuzzTwo.GetReport();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BigReportTest()
        {
            FizzBuzzTwo fizzBuzzTwo = new FizzBuzzTwo(1, 1000);

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "integer", 378},
                { "lucky", 271},
                { "buzz", 109},
                { "fizz", 189},
                { "fizzbuzz", 53}
            };

            Dictionary<string, int> actual = fizzBuzzTwo.StringToDictionary(fizzBuzzTwo.GetLuckyOutput());

            foreach(String key in expected.Keys) {
                Assert.AreEqual(expected[key], actual[key]);
            }

        }

    }
}

