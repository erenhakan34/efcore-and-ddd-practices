using MediatR;

namespace Business.CQRS.Customers.Commands
{
    public class UpdatePassportNumberCommand : IRequest
    {
        public int CustomerId { get; set; }

        public string PassportNumber { get; set; }
    }
}
