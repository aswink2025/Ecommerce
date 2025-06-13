using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Interface;
using ECommerceBook.Infrastructure.Data;

namespace ECommerceBook.Infrastructure.Queries
{
    public class GetBookQuery : IGetBookQuery
    {
        private readonly ECommerceDbContext context;
        private readonly IMapper mapper;

        public GetBookQuery(ECommerceDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IList<BookDto> GetAllBooks()
        {
            return mapper.Map<IList<BookDto>>(context.Books.ToList());
        }

        public BookDto GetBookById(int id)
        {
            return mapper.Map<BookDto>(context.Books.FirstOrDefault(x => x.Id == id));
        }
    }
}
