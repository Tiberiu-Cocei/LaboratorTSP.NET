using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1
{
    public class ArtistCF
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string FirstName { get; set; }
        [MaxLength(40)]
        public string LastName { get; set; }
        public ICollection<AlbumCF> Albums { get; set; }
        protected ArtistCF() { }
    }
}
