using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1
{
    public class CustomerCF
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        public ICollection<OrderCF> Orders { get; set; }
        protected CustomerCF() { }
    }
}
