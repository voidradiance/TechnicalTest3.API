using MediatR;
using TechnicalTest3.API.Commands;
using Repository.Repositories;

namespace TechnicalTest3.API.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerDetails = await _customerRepository.GetByID(command.CustomerId);
            if (customerDetails == null)
                return default;

            return await _customerRepository.DeleteCustomer(customerDetails.CustomerId);
        }
    }
}
