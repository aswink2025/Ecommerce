﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBook.Domain.Entities
{
    public  class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DOB { get; set; }
        public string? Nationality { get; set; }
    }
}
