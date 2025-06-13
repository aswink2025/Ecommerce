using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Enum;
using MediatR;

namespace ECommerceBook.Application.Command._Author
{
    public class AuthorCommand : IRequest<AuthorDto>
    {
        public AuthorCommand(Operation operation, AuthorDto authorDto = null, Author2Dto author2Dto = null)
        {
            Operation = operation;
            AuthorDto = authorDto;
            Author2Dto = author2Dto;
        }

        public Operation Operation { get; set; }
        public AuthorDto? AuthorDto { get; set; }
        public Author2Dto? Author2Dto { get; set; }
    }
}
