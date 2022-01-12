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
            try
            {
                return customerRepository.GetCustomers();
            }
            catch (Exception)
            {
                throw;
            }
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
            if (ModelState.IsValid)
            {
                try
                {
                    customerRepository.SaveCustomer(customer);
                    responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("Customer " + customer.FirstName + " " + customer.LastName + " added.")
                    };
                    return responseMessage;
                }
                catch (Exception)
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    return responseMessage;
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

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