using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Dto;

namespace ECommerceBook.Domain.Interface
{
    public interface IGetBookQuery
    {
        IList<BookDto> GetAllBooks();

        BookDto GetBookById(int id);
    }
}
