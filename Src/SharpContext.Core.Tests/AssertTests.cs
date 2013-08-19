namespace SharpContext.Core.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AssertTests
    {
        [TestMethod]
        public void AssertAndRetrieve()
        {
            Space<string> space = new Space<string>();

            space.Assert("John", new DynamicContext("Country", "UK"));

            var result = space.Retrieve(new DynamicContext("Country", "UK"));

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("John", result.First());
        }

        [TestMethod]
        public void AssertAndRetrieveOtherContext()
        {
            Space<string> space = new Space<string>();

            space.Assert("John", new DynamicContext("Country", "UK"));

            var result = space.Retrieve(new DynamicContext("Country", "Japan"));

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AssertTwoValuesAndRetrieveThem()
        {
            Space<string> space = new Space<string>();

            space.Assert("John", new DynamicContext("Country", "UK"));
            space.Assert("Mary", new DynamicContext("Country", "UK"));

            var result = space.Retrieve(new DynamicContext("Country", "UK"));

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("John", result.First());
            Assert.AreEqual("Mary", result.Skip(1).First());
        }
    }
}
