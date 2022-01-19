using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApp.Data;
using WebShopApp.Models;

namespace WebShopApp.Service
{
    public class OrderService : IEntityService<Order, int>
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            var order = _context.Orders.Find(id);

	    if (order != null)
	    {
                _context.Orders.Remove(order);
                _context.SaveChanges();
	    } else
	    {
                throw new KeyNotFoundException($"Could not delete order with id: {id}");
            }
        }

        public Order Edit(Order order)
	{
	    if (ExistsById(order.Id))
	    {
                throw new KeyNotFoundException($"Order with {order.Id} was not found");
            }

            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();

            return order;
	}

        public Order GetById(int id)
	{
            var order = _context.Orders.Find(id);

	    if (order == null)
	    {
                throw new KeyNotFoundException($"Order with {id} was not found");
            }

            return order;
	}

        public Order Save(Order order)
	{
            _context.Add(order);
	    _context.SaveChanges();

	    return order;
	}

        public IEnumerable<Order> GetAll()
	{
            return _context.Orders.Select(order => order).ToList();
	}

        private bool ExistsById(int id)
        {
            return _context.Orders.Any(order => order.Id == id);
        }

    }
}
