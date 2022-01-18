using Business.CQRS.Customers.DTOs;
using MediatR;

namespace Business.CQRS.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerResultDTO>
    {
        public GetCustomerByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; set; }
    }
}
