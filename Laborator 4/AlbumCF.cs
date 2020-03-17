using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1
{
    public class AlbumCF
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string AlbumName { get; set; }
        public ICollection<ArtistCF> Artists { get; set; }
        protected AlbumCF() { }
    }
}
