using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBook.Domain.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]

        public Book? Book { get; set; }
        public long Price { get; set; }
        public long Stock { get; set; }
        public long Payment { get; set; }
    }
}
