using Application.IRepositories;
using Application.Queries.GetOrders;
using Common.DTO;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Search")]
        public IActionResult SearchOrder([FromQuery] Filter filters)
        {
            var query = new GetOrdersQuery(filters);

            return Ok(_sender.Send(query).Result);
        }
    }
}
