using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinderBayUnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderBayUnitTests.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            Program test = new Program();
            test.Login("martin", "martin");
            bool isValid = test.isLoggedIn;
            Assert.IsTrue(isValid);

        }
    }
}