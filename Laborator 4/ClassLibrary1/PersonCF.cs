using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    public class PersonCF
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string FirstName { get; set; }
        [MaxLength(40)]
        public string MiddleName { get; set; }
        [MaxLength(40)]
        public string LastName { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        protected PersonCF() { }
    }
}
