using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RateYourEntertainment.TagHelpers
{
    [HtmlTargetElement("welcome-message")]
    public class CustomTagHelper : TagHelper
    {
        public string Name
        {
            get;
            set;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "CustomTagHelper";
            output.TagMode = TagMode.StartTagAndEndTag;
            var sb = new StringBuilder();
            sb.AppendFormat("<span>Hi! {0}</span>", this.Name);
            output.PreContent.SetHtmlContent(sb.ToString());
        }
    }
}