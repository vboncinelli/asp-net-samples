using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PlayingWithTagHelpers.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Address { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Il nome del tag HTML da generare, in questo caso un link.
            output.TagName = "a"; 

            // Aggiunge l'attributo href="mailto:{address}"
            output.Attributes.SetAttribute("href", $"mailto:{Address}");
            
            // Produce l'HTML corrispondente
            output.Content.SetContent(Address);
        }
    }
}
