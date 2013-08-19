namespace SharpContext.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Space<T>
    {
        private IDictionary<string, IList<T>> values = new Dictionary<string, IList<T>>();

        public IEnumerable<T> Retrieve(DynamicContext context)
        {
            string key = context.AsString();

            if (this.values.ContainsKey(key))
                return this.values[key];

            return new List<T>();
        }

        public void Assert(T data, DynamicContext context)
        {
            string key = context.AsString();

            if (!this.values.ContainsKey(key))
                this.values[key] = new List<T>();

            this.values[key].Add(data);
        }
    }
}
