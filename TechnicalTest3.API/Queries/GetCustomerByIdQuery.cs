using DataAccess.Models;
using MediatR;

namespace TechnicalTest3.API.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int CustomerId { get; set; }
    }
}
