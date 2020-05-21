using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect3.Models;
using ServiceReferenceProiect;

namespace Proiect3.Pages.File
{
    public class IndexModel : PageModel
    {
        FilePropertyClient fpc = new FilePropertyClient();

        public List<FileDTO> Files { get; set; }

        public int PropertyId { get; set; }

        public IndexModel()
        {
            Files = new List<FileDTO>();
        }

        public async Task OnGetPropertyId(int propertyId)
        {
            PropertyId = propertyId;
            List<int> propertyIds = new List<int>(new int[] { PropertyId });

            var files = await fpc.FileSearchAsync(propertyIds);
            foreach (var item in files)
            {
                FileDTO fd = new FileDTO();
                fd.Id = item.Id;
                fd.Name = item.Name;
                fd.Description = item.Description;
                fd.Path = item.Path;
                fd.Size = item.Size;
                fd.CreationDate = item.CreationDate;
                fd.ToDelete = item.ToDelete;
                fd.Properties = "";
                var properties = await fpc.GetFilePropertiesAsync(item.Id);
                foreach (var property in properties)
                {
                    fd.Properties = fd.Properties + property.Description + ", ";
                }
                fd.Properties = fd.Properties.Substring(0, fd.Properties.Length - 2);
                Files.Add(fd);
            }
        }
    }
}