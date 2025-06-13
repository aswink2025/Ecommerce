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
    public class GetUserQuery : IGetUserQuery
    {
        private readonly IMapper mapper;
        private readonly ECommerceDbContext dbContext;

        public GetUserQuery(IMapper mapper, ECommerceDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public IList<UserDto> GetAllUsers()
        {
            return mapper.Map<IList<UserDto>>(dbContext.Users.ToList());
        }

        public UserDto GetUserById(int id)
        {
            return mapper.Map<UserDto>(dbContext.Users.FirstOrDefault(x => x.Id == id));
        }
    }
}
