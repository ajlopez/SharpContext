namespace SharpContext.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Space<T>
    {
        public IEnumerable<T> Retrieve(params object[] args)
        {
            return new List<T>();
        }
    }
}
