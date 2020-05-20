using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect3.Models
{
    public class FileDTO
    {
        public FileDTO()
        {
            this.ToDelete = false;
            this.PropertyLists = new HashSet<PropertyListDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public double Size { get; set; }

        public System.DateTime CreationDate { get; set; }

        public bool ToDelete { get; set; }

        public virtual ICollection<PropertyListDTO> PropertyLists { get; set; }
    }
}
