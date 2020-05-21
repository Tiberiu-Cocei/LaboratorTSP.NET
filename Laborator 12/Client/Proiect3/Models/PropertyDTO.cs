using System.Collections.Generic;

namespace Proiect3.Models
{
    public class PropertyDTO
    {
        public PropertyDTO()
        {
            this.PropertyLists = new HashSet<PropertyListDTO>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<PropertyListDTO> PropertyLists { get; set; }
    }
}
