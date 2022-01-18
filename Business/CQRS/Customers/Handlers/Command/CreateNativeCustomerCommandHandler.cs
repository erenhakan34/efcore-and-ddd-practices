using Business.CQRS.Customers.Commands;
using Domain.Entities.Customer;
using Domain.Ports;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.CQRS.Customers.Handlers.Command
{
    public class CreateNativeCustomerCommandHandler : IRequestHandler<CreateNativeCustomerCommand>
    {
        private readonly IWriteRepository<int> _writeRepository;

        public CreateNativeCustomerCommandHandler(IWriteRepository<int> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(CreateNativeCustomerCommand request, CancellationToken cancellationToken)
        {
            NativeCustomer nativeCustomer = new NativeCustomer(request.CitizenNumber, request.FirstName, request.LastName,
                request.BirthDateUtc, request.NationalityCode);

            CustomerBuilder customerBuilder = new CustomerBuilder(nativeCustomer);
            nativeCustomer = customerBuilder.AddEmail(request.Email)
                           .AddMobileNumber(request.MobileCountryCode, request.MobileAreaCode, request.MobileNumber)
                           .AddAddress(request.Address).Build<NativeCustomer>();

            await _writeRepository.BeginTransactionAsync();
            await _writeRepository.AddAsync(nativeCustomer);

            return Unit.Value;
        }
    }
}
