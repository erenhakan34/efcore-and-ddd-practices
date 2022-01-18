using Business.CQRS.Customers.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Business.CQRS.Customers.Queries
{
    public class GetCustomersQuery : IRequest<IEnumerable<CustomerResultDTO>>
    {

    }
}
