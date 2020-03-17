using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class OrderCF
    {
        public int Id { get; set; }
        public double TotalValue { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        protected OrderCF() { }
    }
}
