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
    }
}
