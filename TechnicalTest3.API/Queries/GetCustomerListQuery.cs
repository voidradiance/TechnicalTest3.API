using DataAccess.Models;
using MediatR;

namespace TechnicalTest3.API.Queries
{
    public class GetCustomerListQuery : IRequest<List<Customer>>
    {
    }
}
