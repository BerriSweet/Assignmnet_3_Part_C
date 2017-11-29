using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinderBayUnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderBayUnitTests.Tests
{
    /// <summary>
    /// All the Tests related to searching
    /// </summary>
    /// 

        //All tests were written by Danny Marshall
    [TestClass()]
    public class SearchTests
    {
        /// <summary>
        /// Tests if the tags being check exists in the database
        /// </summary>
        /// <returns>a bool</returns>
        [TestMethod()]
        public async Task CheckTagTest()
        {
            Search test = new Search();
            await test.getProducts();
            test.AddTags();
            test.CheckTag();
            bool isVaild = test.matchesTag;
            Assert.IsTrue(isVaild);
            
        }
        /// <summary>
        /// Tests to see if the word being searched exists in the database
        /// </summary>
        /// <returns>a bool</returns>
        [TestMethod()]
        public async Task CheckTagWithWordTest()
        {
            Search test = new Search();
            await test.getProducts();
            test.CheckTag();
            test.searchedWord = "small";
            bool isVaild = test.matchesTag;
            Assert.IsTrue(isVaild);
        }
        /// <summary>
        /// Tests to see if the word being searched does no exist in the database
        /// </summary>
        /// <returns>a bool</returns>
        [TestMethod()]
        public async Task CheckTagWithBadWordTest()
        {
            Search test = new Search();
            await test.getProducts();
            test.searchedWord = "dog";
            test.CheckTag(); 
            bool isntVaild = test.searchFailed;
            Assert.IsTrue(isntVaild);
        }
    }
}