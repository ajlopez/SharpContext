namespace SharpContext.Core.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RetrieveTests
    {
        [TestMethod]
        public void RetrieveEmptyContext()
        {
            Space<string> space = new Space<string>();

            var result = space.Retrieve("Country", "UK");

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AssertAndRetrieveInDifferentOrder()
        {
            Space<string> space = new Space<string>();

            space.Assert("John", "Country", "UK", "Category", "Beverages");
            var result = space.Retrieve("Category", "Beverages", "Country", "UK");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("John", result.First());
        }
    }
}
