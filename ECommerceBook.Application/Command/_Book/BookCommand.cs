using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Enum;
using MediatR;

namespace ECommerceBook.Application.Command._Book
{
    public class BookCommand : IRequest<BookDto>
    {
        public BookCommand(Operation operation, BookDto bookDto = null, Book2Dto book2Dto = null )
        {
            Operation = operation;
            BookDto = bookDto;
            Book2Dto = book2Dto;
        }

        public Operation Operation { get; set; }
        public BookDto? BookDto { get; set; }
        public Book2Dto? Book2Dto { get; set; }
    }
}
