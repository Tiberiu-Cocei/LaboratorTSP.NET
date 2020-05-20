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

        public List<FileDTO> Files { get; set; }

        public IndexModel()
        {
            Properties = new List<PropertyDTO>();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var properties = await fpc.GetAllPropertiesAsync();
            foreach (var item in properties)
            {
                if(!string.IsNullOrEmpty(SearchString))
                {
                    return RedirectToPage("/File");
                }
                // Trebuia folosit AutoMapper. Transform Post in PostDTO
                PropertyDTO pd = new PropertyDTO();
                pd.Description = item.Description;
                pd.Id = item.Id;
                //foreach (var cc in item.Comments)
                //{
                //    CommentDTO cdto = new CommentDTO();
                //    cdto.PostPostId = cc.PostPostId;
                //    cdto.Text = cc.Text;
                //    pd.Comments.Add(cdto);
                //}
                Properties.Add(pd);
            }
            Properties = Properties.OrderBy(x => x.Description).ToList();
            return null;
        }
    }
}