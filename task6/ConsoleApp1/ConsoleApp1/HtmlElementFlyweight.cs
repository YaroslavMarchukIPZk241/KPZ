using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class HtmlElementFlyweight
    {
        private readonly string _tag;

        public HtmlElementFlyweight(string tag)
        {
            _tag = tag;
        }

        public string Render(string content)
        {
            return $"<{_tag}>{content}</{_tag}>";
        }
    }
}
