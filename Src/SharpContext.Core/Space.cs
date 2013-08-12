namespace SharpContext.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Space<T>
    {
        private IDictionary<string, T> values = new Dictionary<string, T>();

        public IEnumerable<T> Retrieve(params object[] args)
        {
            string key = ContextToString(args);

            if (this.values.ContainsKey(key))
                return new List<T>() { this.values[key] };

            return new List<T>();
        }

        public void Assert(T data, params object[] args)
        {
            string key = ContextToString(args);
            this.values[key] = data;
        }

        private static string ContextToString(object[] args)
        {
            string result = string.Empty;

            foreach (var arg in args)
            {
                if (!string.IsNullOrWhiteSpace(result))
                    result += '|';
                result += arg.ToString();
            }

            return result;
        }
    }
}
