using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Common.Models;
using Shop.Application.Orders.Commands;
using Shop.Application.Orders.Dtos;
using Shop.Application.Orders.Queries;
using Shop.Domain.Entities;
using Shop.Domain.Enums;
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
            _ = Task.Delay(1000);
            return await Mediator.Send(query);
        }



        [HttpGet("GetOrderById2")]
        public async Task<OrderDto> GetOrderById2
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


        [HttpGet("GetOrdersWithPagination")]
        public async Task<PaginatedList<OrderDto>> GetOrdersWithPagination
            ([FromQuery] GetOrdersWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create
          ([FromQuery] CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send( new DeleteOrderCommand { Id = id});
            return NoContent();
        }


        [HttpPut]
        public async Task<ActionResult> Update(UpdateOrderCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }


    }




}
