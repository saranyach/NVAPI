using Newtonsoft.Json;
using NVAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace NVAPI.Services
{
    public class CustomerRepository
    {
        public List<Customer> GetCustomers()
        {
            string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Services\Data\Customers.json");
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            return customers;
            //fetch from text

        }

        public void SaveCustomer(Customer customer)
        {
            try
            {
                string oldJson = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Services\Data\Customers.json");
                List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(oldJson);

                customers.Add(customer);

                string newJson = JsonConvert.SerializeObject(customers);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Services\Data\Customers.json", newJson);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}