using NVAPI.Models;
using NVAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NVAPI.Controllers
{
    public class CustomerController : ApiController
    {
        public CustomerRepository customerRepository;
        public CustomerController()
        {
            this.customerRepository = new CustomerRepository();
        }
        // GET api/<controller>
        // GET api/Customers
        [HttpGet]
        public List<Customer> Get()
        {
            return customerRepository.GetCustomers();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        // POST api/Customers
        [HttpPost]
        public HttpResponseMessage Post(Customer customer)
        {
            HttpResponseMessage responseMessage;
            

            try
            {
                if((customer.EmailAddress == null) ||(IsValidEmailAddress(customer.EmailAddress)))
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    return responseMessage;
                }
                customerRepository.SaveCustomer(customer);
                responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                return responseMessage;
            }
            catch (Exception)
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return responseMessage;
            }
        }

        private bool IsValidEmailAddress(string emailAddress)
        {
            return !(new EmailAddressAttribute().IsValid(emailAddress));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}