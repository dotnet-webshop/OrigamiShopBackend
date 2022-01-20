using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Webshop.Api.Data;
using Webshop.Api.Models;

namespace Webshop.Api.Service
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
            if (!ExistsById(customer.Id))
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

            customer.Orders = _context.Orders.Where(o => o.CustomerId.Equals(id))
                .Include(o => o.Products)
                .ThenInclude(p => p.Product)
                .ToList();
            
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
