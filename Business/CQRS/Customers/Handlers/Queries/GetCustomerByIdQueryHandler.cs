using Business.CQRS.Customers.DTOs;
using Business.CQRS.Customers.Queries;
using Domain.Entities.Customer;
using Domain.Ports;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Business.CQRS.Customers.Handlers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResultDTO>
    {
        private readonly IReadRepository<int> _readRepository;

        public GetCustomerByIdQueryHandler(IReadRepository<int> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<CustomerResultDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customerQuery = _readRepository.Get<Customer>(c => c.Id == request.CustomerId);

            return await customerQuery.ProjectToType<CustomerResultDTO>().FirstOrDefaultAsync();
        }
    }
}
