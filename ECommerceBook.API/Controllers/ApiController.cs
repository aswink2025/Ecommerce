using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private ISender? mediator;

        protected ISender? Mediator => mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
