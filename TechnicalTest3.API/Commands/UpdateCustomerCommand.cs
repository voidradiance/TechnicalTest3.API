using MediatR;

namespace TechnicalTest3.API.Commands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        public UpdateCustomerCommand(int customerId, string customerCode, string customerName, string customerAddress)
        {
            CustomerId = customerId;
            CustomerCode = customerCode;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
        }
    }
}
