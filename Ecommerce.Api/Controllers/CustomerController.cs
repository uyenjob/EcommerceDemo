using Ecommerce.Application.Commands.Customers;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Queries.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(int id)
        {
            var res = await _mediator.Send(new GetCustomerByIdQuery(id));
            if (res == null) return NotFound();
            return Ok(res);
        }
    }
}
