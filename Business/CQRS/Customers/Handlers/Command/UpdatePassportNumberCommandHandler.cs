using Business.CQRS.Customers.Commands;
using Domain.Entities.Customer;
using Domain.Ports;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Business.CQRS.Customers.Handlers.Command
{
    public class UpdatePassportNumberCommandHandler : IRequestHandler<UpdatePassportNumberCommand>
    {
        private readonly IWriteRepository<int> _writeRepository;

        public UpdatePassportNumberCommandHandler(IWriteRepository<int> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Unit> Handle(UpdatePassportNumberCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.BeginTransactionAsync();

            ForeignCustomer foreignCustomer = await _writeRepository.Get<ForeignCustomer>(f => f.Id == request.CustomerId).FirstOrDefaultAsync();

            foreignCustomer.UpdatePassportNumber(request.PassportNumber);

            await _writeRepository.UpdateAsync(foreignCustomer);

            return Unit.Value;
        }
    }
}
