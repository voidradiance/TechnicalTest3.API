using MediatR;

namespace TechnicalTest3.API.Commands
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
    }
}
