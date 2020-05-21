using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect3.Models;
using ServiceReferenceProiect;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proiect3.Pages.Property
{
    public class IndexModel : PageModel
    {
        FilePropertyClient fpc = new FilePropertyClient();

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public List<PropertyDTO> Properties { get; set; }

        public IndexModel()
        {
            Properties = new List<PropertyDTO>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var properties = await fpc.GetAllPropertiesAsync();
            foreach (var item in properties)
            {
                if(!string.IsNullOrEmpty(SearchString) && item.Description.ToLower().Contains(SearchString.ToLower()))
                {
                    return RedirectToPage("/File/Index", "PropertyId", new { propertyId = item.Id });
                }

                PropertyDTO pd = new PropertyDTO();
                pd.Description = item.Description;
                pd.Id = item.Id;

                Properties.Add(pd);
            }
            Properties = Properties.OrderBy(x => x.Description).ToList();
            return null;
        }
    }
}