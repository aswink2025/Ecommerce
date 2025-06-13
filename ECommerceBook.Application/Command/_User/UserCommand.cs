using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Enum;
using MediatR;

namespace ECommerceBook.Application.Command._User
{
    public class UserCommand : IRequest<UserDto>
    {
        public UserCommand(Operation operation, UserDto userDto = null, User2Dto user2Dto = null)
        {
            Operation = operation;
            UserDto = userDto;
            User2Dto = user2Dto;
        }

        public Operation Operation { get; set; }
        public UserDto UserDto { get; set; }
        public User2Dto User2Dto { get; set; }
    }
}
