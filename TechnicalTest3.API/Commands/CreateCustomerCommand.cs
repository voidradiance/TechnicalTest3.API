using DataAccess.Models;
using MediatR;

namespace TechnicalTest3.API.Commands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        public CreateCustomerCommand(string customerCode, string customerName, string customerAddress)
        {
            CustomerCode = customerCode;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
        }
    }
}
