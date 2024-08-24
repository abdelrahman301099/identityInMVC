using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace webapplicationday8.Models
{




    public static class HtmlHelperExtensions
    {
        public static IHtmlContent DisplayAsParagraph(string item)
        {
            if (string.IsNullOrEmpty(item)) return new HtmlString("<p>No data available</p>");

            return new HtmlString($"<p><em>{item}</em></p>");
        }
    }

}

