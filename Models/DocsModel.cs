using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Models
{
    public class DocsModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public DocsModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string HtmlContent { get; private set; }

        public void OnGet()
        {
            var filePath = "/files/Privacy Policy.html";
            HtmlContent = System.IO.File.ReadAllText(filePath);
        }
    }
}
