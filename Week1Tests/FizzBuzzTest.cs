using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Week1;

namespace Week1Tests
{
    [TestClass]
    public class FizzBuzzTest
    {

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


        [TestMethod]
        public void ZeroNotDivisible()
        {

            FizzBuzz fizzBuzz = new FizzBuzz(0, 20);
            string output = fizzBuzz.GetOutput();
            Console.WriteLine(output);

            Assert.IsTrue(output.StartsWith("0"));

        }

        [TestMethod]
        public void EndIsGreaterThanStart()
        {
            FizzBuzz fizzBuzz = new FizzBuzz(1, 0);
            string output = fizzBuzz.GetOutput();

            Assert.IsTrue(String.IsNullOrEmpty(output));
        }

        [TestMethod]
        public void DivisibleByThreeAndFiveAndFifteen()
        {
            FizzBuzz fizzBuzz = new FizzBuzz(1, 15);
            string output = fizzBuzz.GetOutput();

            TestContext.WriteLine(output);

            Assert.IsTrue(output.Equals("1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz"));
        }

        [TestMethod]
        public void DefaultConstructorNoOutput()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            string output = fizzBuzz.GetOutput();

            Assert.IsTrue(String.IsNullOrEmpty(output));
        }

        [TestMethod]
        public void StartAndEndSameValueReturnsEmptyString()
        {
            FizzBuzz fizzBuzz = new FizzBuzz(1,1);
            string output = fizzBuzz.GetOutput();

            Assert.IsTrue(String.IsNullOrEmpty(output));
        }


    }

}
