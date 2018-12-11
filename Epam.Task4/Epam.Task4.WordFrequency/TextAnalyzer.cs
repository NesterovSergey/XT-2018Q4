using System;
using System.Collections.Generic;

namespace Epam.Task4.WordFrequency
{
    public class TextAnalyzer
    {
        private Dictionary<string, int> count = new Dictionary<string, int>();

        public string Text { get; set; }

        public Dictionary<string, int> Count => this.count;

        public void Counter()
        {
            string[] stringArray = this.Text.ToLower().Split(new char[] { ' ', '.' });

            foreach (var item in stringArray)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }

                if (this.count.ContainsKey(item))
                {
                    this.count[item] += 1;
                }
                else
                {
                    this.count.Add(item.Trim(), 1);
                }
            }
        }
    }
}
