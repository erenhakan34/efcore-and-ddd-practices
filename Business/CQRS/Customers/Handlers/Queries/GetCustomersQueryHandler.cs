using Business.CQRS.Customers.DTOs;
using Business.CQRS.Customers.Queries;
using Domain.Entities.Customer;
using Domain.Ports;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.CQRS.Customers.Handlers.Queries
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerResultDTO>>
    {
        private readonly IReadRepository<int> _readRepository;

        public GetCustomersQueryHandler(IReadRepository<int> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<CustomerResultDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customerQuery = _readRepository.GetAll<Customer>();

            return await customerQuery.ProjectToType<CustomerResultDTO>().ToListAsync();
        }
    }
}
