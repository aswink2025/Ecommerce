using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Entities;

namespace ECommerceBook.Domain.Dto
{
    public class Book2Dto
    {
        public string? Title { get; set; }
        public int AuthorId { get; set; }

        public Author? Author { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}
