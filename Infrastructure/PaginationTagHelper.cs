using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Intex2Group22.Infrastructure
{
    [HtmlTargetElement("div", Attributes ="page-number")]
    public class PaginationTagHelper : TagHelper
    {
        //dynamically create page links for us
    }
}
