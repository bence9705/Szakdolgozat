using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class IsThereTests
    {
        [TestMethod]
        public void IsThereTest()
        {
            bool igaz = true;
            Assert.IsTrue(igaz);
        }
    }
}
