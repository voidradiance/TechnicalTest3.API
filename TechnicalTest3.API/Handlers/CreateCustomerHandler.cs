using DataAccess.Models;
using MediatR;
using TechnicalTest3.API.Commands;
using Repository.Repositories;

namespace TechnicalTest3.API.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerDetails = new Customer()
            {
                CustomerCode = command.CustomerCode,
                CustomerName = command.CustomerName,
                CustomerAddress = command.CustomerAddress
            };

            return await _customerRepository.CreateCustomer(customerDetails);
        }
    }
}
