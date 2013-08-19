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

        [TestMethod]
        public void AsString()
        {
            DynamicContext context = new DynamicContext("Country", "Japan", "Category", "Beverages", "Amount", 1000);

            Assert.AreEqual("Amount=1000|Category=Beverages|Country=Japan", context.AsString());
        }

        [TestMethod]
        public void OddNumberOfArguments()
        {
            try
            {
                new DynamicContext("One", "Two", "Three");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Odd number of arguments", ex.Message);
            }
        }

        [TestMethod]
        public void PropertyNameIsNotAnString()
        {
            try
            {
                new DynamicContext(1, "One");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Property name should be an string", ex.Message);
            }
        }

        [TestMethod]
        public void PropertyNameIsNull()
        {
            try
            {
                new DynamicContext("One", 1, null, 2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Property name should be an string", ex.Message);
            }
        }

        [TestMethod]
        public void ValueIsNull()
        {
            try
            {
                new DynamicContext("One", 1, "Two", null, "Three", 3);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Value cannot be null", ex.Message);
            }
        }
    }
}
