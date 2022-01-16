using Domain.Entities.Customer;
using Domain.Ports;
using Domain.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        [HttpPost("[controller].customers)")]
        public async Task<IActionResult> AddCustomer()
        {
            #region Add native customer

            string citizenNumber = "11122233344";
            string firstName = "Hakan";
            string lastName = "Eren";
            string nationalityCode = "TR";
            DateTime birthDateUtc = new DateTime(1990, 08, 14, 0, 0, 0, DateTimeKind.Utc);

            NativeCustomer nativeCustomer = new NativeCustomer(citizenNumber, firstName, lastName, birthDateUtc, nationalityCode);
            nativeCustomer.SetEmail("xxxxxx@gmail.com").SetMobileNumber("90", "111", "1111111");

            await _writeRepository.BeginTransactionAsync();
            await _writeRepository.AddAsync(nativeCustomer);


            List<NativeCustomer> nativeCustomerList = new List<NativeCustomer>();

            citizenNumber = "22211133355";
            firstName = "Ali";
            lastName = "Test";
            NativeCustomer nativeCustomer2 = new NativeCustomer(citizenNumber, firstName, lastName, birthDateUtc, nationalityCode);
            nativeCustomer2.SetEmail("bbbbbb@gmail.com");
            nativeCustomerList.Add(nativeCustomer2);

            citizenNumber = "33311122255";
            firstName = "Mehmet";
            lastName = "Test";
            NativeCustomer nativeCustomer3 = new NativeCustomer(citizenNumber, firstName, lastName, birthDateUtc, nationalityCode);
            nativeCustomer3.SetEmail("kkkkkk@gmail.com");
            nativeCustomerList.Add(nativeCustomer3);

            await _writeRepository.AddRangeAsync(nativeCustomerList);

            #endregion

            #region Add foreign customer

            string passportNumber = "D10GH45H";
            nationalityCode = "DE";
            firstName = "John";
            lastName = "Travolta";

            ForeignCustomer foreignCustomer = new ForeignCustomer(passportNumber, firstName, lastName, birthDateUtc, nationalityCode);
            await _writeRepository.AddAsync(foreignCustomer);

            #endregion

            return Ok();
        }

        [HttpGet("[controller].customers/id)")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _readRepository.Get<Customer>(id).FirstOrDefaultAsync();
            return Ok(customer);
        }

        [HttpGet("[controller].customers)")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var nativeCustomers = await _readRepository.GetAll<NativeCustomer>().ToListAsync();
            var foreignCustomers = await _readRepository.GetAll<ForeignCustomer>().ToListAsync();

            var orderedCustomersByEmail = await _readRepository.GetAll<Customer>()
                .OrderByEmailDesc<Customer>().ToListAsync();

            return Ok(new { nativeCustomers, foreignCustomers, orderedCustomersByEmail });
        }


        [HttpPut("[controller].customers)")]
        public async Task<IActionResult> UpdateCustomer()
        {
            await _writeRepository.BeginTransactionAsync();

            var nativeCustomer = _readRepository.GetAll<NativeCustomer>().FirstOrDefault();
            nativeCustomer.SetEmail("yyyyyy@gmail.com");

            await _writeRepository.UpdateAsync(nativeCustomer);

            return Ok();
        }

        [HttpDelete("[controller].customers)")]
        public async Task<IActionResult> DeleteCustomerSoftly()
        {
            await _writeRepository.BeginTransactionAsync();

            var nativeCustomer = _readRepository.GetAll<NativeCustomer>().FirstOrDefault();

            await _writeRepository.RemoveAsync(nativeCustomer);

            return Ok();
        }
    }
}
