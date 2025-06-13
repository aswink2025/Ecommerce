using ECommerceBook.Application.Command._User;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Enum;
using ECommerceBook.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IGetUserQuery getUserQuery;

        public UserController(IGetUserQuery getUserQuery)
        {
            this.getUserQuery = getUserQuery;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var user = getUserQuery.GetAllUsers();
            return Ok(user);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var user = getUserQuery.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] User2Dto user2Dto)
        {
            var command = new UserCommand(Operation.Create, user2Dto: user2Dto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {
            if (id == userDto.Id)
            {
                var command = new UserCommand(Operation.Update, userDto);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = new UserDto { Id = id };
            var command = new UserCommand(Operation.Delete, user);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
