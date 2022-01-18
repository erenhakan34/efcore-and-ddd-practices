using Business.CQRS.Customers.Commands;
using Domain.Entities.Customer;
using Domain.Ports;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.CQRS.Customers.Handlers.Command
{
    public class CreateForeignCustomerCommandHandler : IRequestHandler<CreateForeignCustomerCommand>
    {
        private readonly IWriteRepository<int> _writeRepository;

        public CreateForeignCustomerCommandHandler(IWriteRepository<int> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateForeignCustomerCommand request, CancellationToken cancellationToken)
        {
            ForeignCustomer foreignCustomer = new ForeignCustomer(request.PassportNumber, request.FirstName, request.LastName,
                request.BirthDateUtc, request.NationalityCode);

            CustomerBuilder customerBuilder = new CustomerBuilder(foreignCustomer);

            foreignCustomer = customerBuilder.AddEmail(request.Email)
                           .AddMobileNumber(request.MobileCountryCode, request.MobileAreaCode, request.MobileNumber)
                           .AddAddress(request.Address).Build<ForeignCustomer>();

            await _writeRepository.BeginTransactionAsync();
            await _writeRepository.AddAsync(foreignCustomer);

            return Unit.Value;
        }
    }
}
