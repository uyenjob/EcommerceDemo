using Ecommerce.Application.Commands.Orders;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Queries.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var res = await _mediator.Send(new GetOrderByIdQuery(id));
            if (res == null) return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create(CreateOrderCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
