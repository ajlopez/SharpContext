namespace SharpContext.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Space<T>
    {
        private T data;

        public IEnumerable<T> Retrieve(params object[] args)
        {
            if (data != null)
                return new List<T>() { data };

            return new List<T>();
        }

        public void Assert(T data, params object[] args)
        {
            this.data = data;    
        }
    }
}
