using Domain.Entities.Customer;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly IReadRepository<int> _readRepository;
        private readonly IWriteRepository<int> _writeRepository;

        public CustomerController(IReadRepository<int> readRepository, IWriteRepository<int> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        [HttpPost("[controller].customers)]")]
        public async Task<IActionResult> AddCustomer()
        {
            string citizenNumber = "11122233344";
            string firstName = "Hakan";
            string lastName = "Eren";
            string nationalityCode = "TR";
            DateTime birthDateUtc = new DateTime(1990, 08, 14, 0, 0, 0, DateTimeKind.Utc);

            NativeCustomer nativeCustomer = new NativeCustomer(citizenNumber, firstName, lastName, birthDateUtc, nationalityCode);

            await _writeRepository.BeginTransactionAsync();
            await _writeRepository.AddAsync(nativeCustomer);

            return Ok();
        }

        [HttpGet("[controller].customers/id)]")]
        public async Task<IActionResult> GetCustomerById(int id) 
        {
            var customer = _readRepository.Get<NativeCustomer>(id);
            return Ok(customer);
        }

        [HttpGet("[controller].customers)]")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = _readRepository.GetAll<NativeCustomer>();
            return Ok(customers);
        }


        [HttpPut("[controller].customers)]")]
        public async Task<IActionResult> UpdateCustomer()
        {
            var nativeCustomer = _readRepository.GetAll<NativeCustomer>().FirstOrDefault();
            nativeCustomer.SetEmail("xxxxx@gmail.com");

            await _writeRepository.UpdateAsync(nativeCustomer);

            return Ok();
        }

        [HttpDelete("[controller].customers)]")]
        public async Task<IActionResult> DeleteCustomerSoftly()
        {
            var nativeCustomer = _readRepository.GetAll<NativeCustomer>().FirstOrDefault();

            await _writeRepository.RemoveAsync(nativeCustomer);

            return Ok();
        }
    }
}
