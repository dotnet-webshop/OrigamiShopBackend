using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Webshop.Api.Data;
using Webshop.Api.Models;

namespace Webshop.Api.Service
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
            }
            else
            {
                throw new KeyNotFoundException($"Could not delete order with id: {id}");
            }
        }

        public Order Edit(Order editedOrder)
        {
            if (!ExistsById(editedOrder.Id))
            {
                throw new KeyNotFoundException($"Order with {editedOrder.Id} was not found");
            }

            editedOrder.TotalPrice = CalculateTotalPrice(editedOrder);
            _context.Entry(editedOrder).State = EntityState.Modified;
            _context.SaveChanges();
            var o = GetById(editedOrder.Id);
            return o;
        }

        public double CalculateTotalPrice(Order editedOrder)
        {
            var productIds = editedOrder.Products.Select(e => e.ProductId);
            var products = _context.Products.Where( e => productIds.Contains(e.Id)).ToList();
            if (!products.Any()) return 0.0;
            var total = 0.0;
            foreach (var item in editedOrder.Products)
            {
                var actualProduct = products.First( p => p.Id == item.ProductId);
                var quantity = item.Quantity <= 0 ? 1 : item.Quantity;
                total += actualProduct.ProductPrice * quantity;
                products.Remove(actualProduct);
            } 
            return total;
        }
        public Order GetById(int id)
        {
            var order = _context.Orders
                .Include(o => o.Products)
                .ThenInclude(item => item.Product).First(o => o.Id == id);
            

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with {id} was not found");
            }
            
            
            
            return order;
        }

        public Order Save(Order order)
        {
            order.TotalPrice = CalculateTotalPrice(order);
            _context.Add(order);
            _context.SaveChanges();

            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Select(order => order)
                .Include(o => o.Products)
                .ThenInclude(items => items.Product)
                .ToList();
        }

        private bool ExistsById(int id)
        {
            return _context.Orders.Any(order => order.Id == id);
        }
    }
}