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
    }
}
