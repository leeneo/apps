using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(30)]
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "TEst";
        }
    }
}
