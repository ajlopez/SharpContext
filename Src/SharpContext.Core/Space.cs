﻿namespace SharpContext.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Space<T>
    {
        private IDictionary<string, IList<T>> values = new Dictionary<string, IList<T>>();

        public IEnumerable<T> Retrieve(params object[] args)
        {
            string key = ContextToString(args);

            if (this.values.ContainsKey(key))
                return this.values[key];

            return new List<T>();
        }

        public void Assert(T data, params object[] args)
        {
            string key = ContextToString(args);

            if (!this.values.ContainsKey(key))
                this.values[key] = new List<T>();

            this.values[key].Add(data);
        }

        private static string ContextToString(object[] args)
        {
            var words = args.Select(arg => arg.ToString()).ToArray();
            Array.Sort(words);

            string result = string.Empty;

            foreach (var word in words)
            {
                if (!string.IsNullOrWhiteSpace(result))
                    result += '|';
                result += word;
            }

            return result;
        }
    }
}
