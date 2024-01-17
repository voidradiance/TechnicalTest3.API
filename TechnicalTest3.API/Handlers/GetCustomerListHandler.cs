using DataAccess.Models;
using MediatR;
using TechnicalTest3.API.Queries;
using Repository.Repositories;

namespace TechnicalTest3.API.Handlers
{

    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, List<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerListHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Handle(GetCustomerListQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetAll();
        }
    }
}
