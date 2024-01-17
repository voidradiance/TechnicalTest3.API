using Azure;
using DataAccess.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest3.API.Commands;
using TechnicalTest3.API.Queries;
using TechnicalTest3.API.Validator;
using TechnicalTest3.API.ViewModel;

namespace TechnicalTest3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseGetVM> GetAll()
        {
            var response = new ResponseGetVM();
            var customerDetails = await mediator.Send(new GetCustomerListQuery());
            if (customerDetails != null)
            {
                response.message = $"Success get {customerDetails.Count} customers";
                response.data = customerDetails;
            }
            else
            {
                response.message = "Data not found";
            }

            return response;
        }

        [HttpGet("customerId")]
        public async Task<ResponseGetVM> GetById(int customerId)
        {
            var response = new ResponseGetVM();
            var customerDetails = await mediator.Send(new GetCustomerByIdQuery() { CustomerId = customerId });
            if (customerDetails != null)
            {
                response.message = $"Success get customer: {customerDetails.CustomerName}";
                response.data = new List<Customer> { customerDetails };
            }
            else
            {
                response.message = "Data not found";
            }

            return response;
        }

        [HttpPost]
        public async Task<ResponseVM> Insert(CreateCustomerVM vm)
        {
            var response = new ResponseVM();
            var validator = new CustomerValidator();
            ValidationResult result = validator.Validate(new Customer()
            {
                CustomerCode = vm.CustomerCode,
                CustomerName = vm.CustomerName,
                CustomerAddress = vm.CustomerAddress
            });

            if (result.IsValid)
            {
                await mediator.Send(new CreateCustomerCommand(
                vm.CustomerCode,
                vm.CustomerName,
                vm.CustomerAddress));

                response.message = "Success insert data";
            }
            else
            {
                response.message = "Fail insert data";
            }

            return response;
        }

        [HttpPut]
        public async Task<ResponseVM> Update(UpdateCustomerVM vm)
        {
            var response = new ResponseVM();
            var validator = new CustomerValidator();
            ValidationResult result = validator.Validate(new Customer()
            {
                CustomerId = vm.CustomerId,
                CustomerCode = vm.CustomerCode,
                CustomerName = vm.CustomerName,
                CustomerAddress = vm.CustomerAddress
            });

            if (result.IsValid)
            {
                var isCustomerDetailUpdated = await mediator.Send(new UpdateCustomerCommand(
                   vm.CustomerId,
                   vm.CustomerCode,
                   vm.CustomerName,
                   vm.CustomerAddress));
                if (isCustomerDetailUpdated != 0)
                {
                    response.message = "Success update data";
                }
                else
                {
                    response.message = "Data not found";
                }
            }
            else
            {
                response.message = "Fail update data";
            }
            
            return response;
        }

        [HttpDelete]
        public async Task<ResponseVM> Delete(int Id)
        {
            var response = new ResponseVM();
            var isSuccess = (await mediator.Send(new DeleteCustomerCommand() { CustomerId = Id }) != 0);
            if (isSuccess)
            {
                response.message = "Success delete data";
            }
            else
            {
                response.message = "Fail delete data";
            }
            return response;
        }
    }
}
