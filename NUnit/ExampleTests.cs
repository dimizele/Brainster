using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace NUnit
{
    [TestFixture]
    public class ExampleTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUpFunctionExample()
        {

        }

        [SetUp]
        public void SetUpFunctionExample()
        {

        }

        [Category("RegressionTest"), Category("SmokeTest")]
        [Description("This test will run second")]
        [Test]
        public void FirstTest()
        {

        }

        [Category("RegressionTest")]
        [Category("SmokeTest")]
        [Description("This test will run first")]
        [Test]
        public void SecondTest()
        {

        }

        [Category("SmokeTest")]
        [Description("This test will run third")]
        [Test]
        public void ThirdTest()
        {

        }

        [Ignore("This test does not meet the test criteria")]
        [Test]
        public void IgnoredTest()
        {

        }

        [Explicit("This test will only run as part of a larger test run")]
        [Test]
        public void ExplicitTest()
        {

        }

        [Explicit("This test will only run as part of a larger test run")]
        [Test]
        public void ExplicitTest2()
        {

        }

        [Test]
        public void FailedRetryTest()
        {
            int randomNumber = new Random().Next(0, 5);
            Assert.AreEqual(4, randomNumber);
        }

        [Retry(10)]
        [Test]
        public void PassingRetryTest()
        {
            int randomNumber = new Random().Next(0, 5);
            Assert.AreEqual(4, randomNumber);
        }

        [Repeat(10)]
        [Test]
        public void RepeatTest()
        {
            int randomNumber = new Random().Next(0, 5);
            Assert.AreNotEqual(4, randomNumber);
        }

        [Parallelizable(ParallelScope.Children)]
        [TestCase(3, 4, 12)]
        [TestCase(2, 4, 8)]
        [TestCase(4, 4, 16)]
        [TestCase(5, 4, 20)]
        [Test]
        public void MultiplicationTests(int a, int b, int c)
        {
            Thread.Sleep(3000);
            Assert.AreEqual(c, a * b);
        }

        [TestCase(3, 4, 12, ExpectedResult = 19)]
        [TestCase(3, 5, 12, ExpectedResult = 20)]
        [TestCase(4, 4, 13, ExpectedResult = 31)]
        [Test]
        public int AdditionTests(int a, int b, int c)
        {
            return a + b + c;
        }

        [TestCase("ab", "ba", "abba")]
        [TestCase("ab", "ba", "notabba")]
        [Test]
        public void ConcatTests(string a, string b, string c)
        {
            if (c == a + b)
            {
                throw new Exception();
            }

            Assert.AreEqual(c, a + b);

            Assert.AreEqual(c, a + b, $"We expected to be {c} but was {a + b}");
        }

        [MaxTime(3000)]
        [Test]
        public void MaxTimeTest1()
        {
            Thread.Sleep(4000);
            Assert.Pass();
        }

        [MaxTime(3000)]
        [Test]
        public void MaxTimeTest3()
        {
            Thread.Sleep(2000);
            Assert.Pass();
        }

        [MaxTime(3000)]
        [Test]
        public void MaxTimeTest2()
        {
            Thread.Sleep(4000);
            Assert.AreEqual(1, 2, "1 is not equal to 2");
        }

        [Timeout(3000)]
        [Test]
        public void TimeoutTest1()
        {
            Thread.Sleep(4000);
            Assert.Pass();
        }

        [Timeout(3000)]
        [Test]
        public void TimeoutTest2()
        {
            Thread.Sleep(4000);
            Assert.AreEqual(1, 2, "1 is not equal to 2");
        }

        [Timeout(3000)]
        [Test]
        public void TimeoutTest3()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(1, 2, "1 is not equal to 2");
        }

        [Test]
        public void AssertTest()
        {
            Assert.AreEqual(2, 2);
            Assert.AreNotEqual(2, 3);
            Assert.IsNull(null);
            Assert.IsNotNull(new List());
            Assert.Fail("This assert instantly fails the test");
            Assert.Ignore("This assert instantly ignore the test");
            Assert.Pass("This assert instantly passes the test");
        }

        [Test]
        public void MultipleAssertTest()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(2, 2);
                Assert.AreNotEqual(2, 3);
            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(2,2);
                Assert.AreEqual(2,3);
                Assert.AreNotEqual(2,3);
                Assert.AreNotEqual(2,2);
            });
        }

        [TearDown]
        public void TearDownFunctionExample()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDownFunctionExample()
        {

        }


        public void IWorkWithInts(int hehe)
        {
            throw new Exception();
        }

        public void IAddNumbersToList(List<int> list)
        {
            list.Add(5);
        }
    }
}
