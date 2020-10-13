using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnit
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class ParallelizableTests
    {
        [Parallelizable(ParallelScope.Self)]
        [Test]
        public void FirstParallelTest()
        {
            Thread.Sleep(5000);
        }

        [Parallelizable(ParallelScope.Self)]
        [Test]
        public void SecondParallelTest()
        {
            Thread.Sleep(4000);
        }

        [Parallelizable(ParallelScope.Self)]
        [Test]
        public void ThirdParallelTest()
        {
            Thread.Sleep(6000);
        }

        [Test]
        public void FirstNonParallelTest()
        {
            Thread.Sleep(3000);
        }

        [Parallelizable(ParallelScope.None)]
        [Test]
        public void SecondNonParallelTest()
        {
            Thread.Sleep(6000);
        }
    }
}
