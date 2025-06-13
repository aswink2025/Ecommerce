using ECommerceBook.Application.Command._Author;
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
    public class AuthorController : ApiController
    {
        private readonly IGetAuthorQuery getAuthorQuery;

        public AuthorController(IGetAuthorQuery getAuthorQuery)
        {
            this.getAuthorQuery = getAuthorQuery;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var author = getAuthorQuery.GetAllAuthors();
            return Ok(author);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var author = getAuthorQuery.GetAuthorById(id);
            return Ok(author);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Author2Dto author2Dto)
        {
            var command = new AuthorCommand(Operation.Create, author2Dto: author2Dto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AuthorDto authorDto)
        {
            if (id == authorDto.Id)
            {
                var command = new AuthorCommand(Operation.Update, authorDto: authorDto);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = new AuthorDto { Id = id };
            var command = new AuthorCommand(Operation.Delete, author);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
