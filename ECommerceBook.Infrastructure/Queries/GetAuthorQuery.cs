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
    public class GetAuthorQuery : IGetAuthorQuery
    {
        private readonly ECommerceDbContext context;

        private readonly IMapper mapper;

        public GetAuthorQuery(ECommerceDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IList<AuthorDto> GetAllAuthors()
        {
            return mapper.Map<IList<AuthorDto>>(context.Authors.ToList());
        }

        public AuthorDto GetAuthorById(int id)
        {
            return mapper.Map<AuthorDto>(context.Authors.FirstOrDefault(x => x.Id == id));
        }
    }
}
