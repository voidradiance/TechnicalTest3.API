using MediatR;
using TechnicalTest3.API.Commands;
using Repository.Repositories;

namespace TechnicalTest3.API.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerDetails = await _customerRepository.GetByID(command.CustomerId);
            if (customerDetails == null)
                return default;

            customerDetails.CustomerCode = command.CustomerCode;
            customerDetails.CustomerName = command.CustomerName;
            customerDetails.CustomerAddress = command.CustomerAddress;

            return await _customerRepository.UpdateCustomer(customerDetails);
        }
    }
}
