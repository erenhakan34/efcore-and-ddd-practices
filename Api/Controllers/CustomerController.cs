using Business.CQRS.Customers.Commands;
using Business.CQRS.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[controller].createNativeCustomer)")]
        public async Task<IActionResult> CreateNativeCustomer([FromBody] CreateNativeCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("[controller].createForeignCustomer)")]
        public async Task<IActionResult> CreateForeignCustomer([FromBody] CreateForeignCustomerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("[controller].updatePassportNumber)")]
        public async Task<IActionResult> UpdatePassportNumber([FromBody] UpdatePassportNumberCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("[controller].customers/id)")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(customer);
        }

        [HttpGet("[controller].customers)")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetCustomersQuery());
            return Ok(customers);
        }
    }
}
