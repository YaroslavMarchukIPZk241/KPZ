using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class LightHTMLParser
    {
        public static string ConvertToHTML(string[] lines, HtmlElementFactory factory)
        {
            StringBuilder html = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string tag;

                if (i == 0)
                    tag = "h1";
                else if (line.Length < 20)
                    tag = "h2";
                else if (line.StartsWith(" "))
                    tag = "blockquote";
                else
                    tag = "p";

                var element = factory.GetElement(tag);
                html.AppendLine(element.Render(line.Trim()));
            }

            return html.ToString();
        }
    }
}
