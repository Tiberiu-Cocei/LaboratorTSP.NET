namespace Proiect3.Models
{
    public class PropertyListDTO
    {
        public int Id { get; set; }

        public int FileId { get; set; }

        public int PropertyId { get; set; }

        public virtual FileDTO File { get; set; }

        public virtual PropertyDTO Property { get; set; }
    }
}
