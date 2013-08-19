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
                if (!(args[k] is string))
                    throw new InvalidOperationException("Property name should be an string");

                string key = (string)args[k];

                if (args[k + 1] == null)
                    throw new InvalidOperationException("Value cannot be null");

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

        public string AsString()
        {
            var names = this.values.Keys.ToArray();
            Array.Sort(names);

            string result = string.Empty;

            foreach (var name in names)
            {
                if (!string.IsNullOrWhiteSpace(result))
                    result += "|";

                result += name;
                result += "=";
                result += this.values[name].ToString();
            }

            return result;
        }
    }
}
