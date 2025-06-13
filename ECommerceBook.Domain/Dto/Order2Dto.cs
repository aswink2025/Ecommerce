using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBook.Domain.Dto
{
    public class Order2Dto
    {
        public int LoginId { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }
        public int? Quantity { get; set; }
        public long TotalPrice { get; set; }
    }
}
