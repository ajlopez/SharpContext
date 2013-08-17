namespace SharpContext.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DynamicContext
    {
        private IDictionary<string, object> values = new Dictionary<string, object>();

        public DynamicContext(params object[] args)
        {
            if (args.Length % 2 == 1)
                throw new InvalidOperationException("Odd number of arguments");

            for (int k = 0; k < args.Length; k += 2)
            {
                string key = (string)args[k];
                object value = args[k + 1];

                this.values[key] = value;
            }
        }

        public object GetValue(string name)
        {
            if (this.values.ContainsKey(name))
                return this.values[name];

            return null;
        }
    }
}
