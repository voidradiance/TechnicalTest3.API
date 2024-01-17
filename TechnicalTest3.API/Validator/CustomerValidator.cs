using DataAccess.Models;
using FluentValidation;
using TechnicalTest3.API.ViewModel;

namespace TechnicalTest3.API.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cus => cus.CustomerCode).MaximumLength(50).NotNull();
            RuleFor(cus => cus.CustomerName).MaximumLength(255).NotNull();
            RuleFor(cus => cus.CustomerAddress).MaximumLength(int.MaxValue).NotNull();
        }
    }
}
