using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string SenderCity { get; set; }
        public string SenderAdress { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverAdress { get; set; }
        public int Weight { get; set; }
        public DateTime ReciveDate { get; set; }
    }
}
