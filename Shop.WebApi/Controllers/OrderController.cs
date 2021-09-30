using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Orders.Dtos;
using Shop.Application.Orders.Queries;
using Shop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private ISender _mediator;
        public ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();


        [HttpGet("GetOrderById")]
        public async Task<ActionResult<OrderDto>> GetOrderById
            ([FromQuery] GetOrderByIdQuery query)
        {
            return await Mediator.Send(query);
        }


        [HttpGet("GetOrders")]
        public async Task<IEnumerable<OrderDto>> GetOrders
    ([FromQuery] GetOrdersQuery query)
        {
            return await Mediator.Send(query);
        }







    }
}
