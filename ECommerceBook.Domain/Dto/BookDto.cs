using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Entities;

namespace ECommerceBook.Domain.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        
        public Author? Author { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}
