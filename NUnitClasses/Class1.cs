using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitClasses
{
    [TestFixture]
    public class Class1
    {
        [OneTimeSetUp]
        public void OneTimeSetUpMethod()
        {
            Console.WriteLine("This will be done only once before all tests");
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("This will be done once before every test");
        }

        [Ignore("")]
        [Category("Ignored")]
        [Test]
        public void Test1()
        {
            Thread.Sleep(1000);
        }

        [Ignore("")]
        [Category("Ignored")]
        [Test]
        public void Test2()
        {
            Thread.Sleep(1000);
        }

        [Explicit("")]
        [Category("Explicit")]
        [Test]
        public void Test3()
        {
            Thread.Sleep(1000);
        }

        [Explicit("")]
        [Category("Explicit")]
        [Test]
        public void Test4()
        {
            Thread.Sleep(1000);
        }

        [Explicit("")]
        [Category("Explicit")]
        [Test]
        public void Test5()
        {
            Thread.Sleep(1000);
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("This will be done once after every test");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("This will be done only once after all tests");
        }
    }
}
