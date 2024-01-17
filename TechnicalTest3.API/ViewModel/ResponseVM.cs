using DataAccess.Models;

namespace TechnicalTest3.API.ViewModel
{
    public class ResponseGetVM
    {
        public string message { get; set; }
        public Guid transactionId { get; set; } = Guid.NewGuid();
        public List<Customer> data { get; set; }
    }

    public class ResponseVM
    {
        public string message { get; set; }
        public Guid transactionId { get; set; } = Guid.NewGuid();
    }
}
