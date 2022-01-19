using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShopApp.Data;
using WebShopApp.Models;
using WebShopApp.Models.ModelDTO;

namespace WebShopApp.Service
{
    public class CustomerService : IEntityService<Customer, string>
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteById(string id)
        {
            var customer = _context.Customers.Find(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Could not delete customer with id: {id}");
            }
        }

        public Customer Edit(Customer customer)
        {
            if (ExistsById(customer.Id))
            {
                throw new KeyNotFoundException($"Customer with {customer.Id} was not found");
            }

            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();

            return customer;
        }

        public Customer GetById(string id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with {id} was not found");
            }

            return customer;
        }

        public Customer Save(Customer customer)
        {

            _context.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers
                .Select(customer => customer)
                .ToList();
        }

        private bool ExistsById(string id)
        {
            return _context.Customers.Any(customer => customer.Id == id);
        }
    }
}
