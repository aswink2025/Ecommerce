using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Dto;

namespace ECommerceBook.Domain.Interface
{
    public interface IGetUserQuery
    {
        IList<UserDto> GetAllUsers();

        UserDto GetUserById(int id);
    }
}
