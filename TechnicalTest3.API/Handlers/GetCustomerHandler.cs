using DataAccess.Models;
using MediatR;
using TechnicalTest3.API.Queries;
using Repository.Repositories;

namespace TechnicalTest3.API.Handlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetByID(query.CustomerId);
        }
    }
}
