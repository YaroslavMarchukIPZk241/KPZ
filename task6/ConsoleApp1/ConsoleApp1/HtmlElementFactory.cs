using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HtmlElementFactory
    {
        private readonly Dictionary<string, HtmlElementFlyweight> _elements = new();

        public HtmlElementFlyweight GetElement(string tag)
        {
            if (!_elements.ContainsKey(tag))
            {
                _elements[tag] = new HtmlElementFlyweight(tag);
            }

            return _elements[tag];
        }

        public int Count => _elements.Count;
    }
}
