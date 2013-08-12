namespace SharpContext.Core.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicContextTests
    {
        [TestMethod]
        public void GetUnknownValue()
        {
            DynamicContext context = new DynamicContext();

            Assert.IsNull(context.GetValue("Country"));
        }
        
        [TestMethod]
        public void CreateWithKeyValue()
        {
            DynamicContext context = new DynamicContext("Country", "Japan");

            Assert.AreEqual("Japan", context.GetValue("Country"));
        }

        [TestMethod]
        public void CreateWithTwoKeyValue()
        {
            DynamicContext context = new DynamicContext("Country", "Japan", "Category", "Beverages");

            Assert.AreEqual("Japan", context.GetValue("Country"));
            Assert.AreEqual("Beverages", context.GetValue("Category"));
            Assert.IsNull(context.GetValue("Unknown"));
        }
    }
}
