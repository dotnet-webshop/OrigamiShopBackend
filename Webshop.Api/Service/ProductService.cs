using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebShopApp.Data;
using WebShopApp.Models;

namespace WebShopApp.Service
{

    public class ProductService : IEntityService<Product, int>
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Could not delete product with id: {id}");
            }
        }

        public Product Edit(Product product)
        {
            if(!ExistsById(product.Id))
            {
                throw new KeyNotFoundException($"Product with {product.Id} was not found");
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return product;
        }

        public Product GetById(int id)
        {
            var product = _context.Products.Find(id);

            if(product == null)
            {
                throw new KeyNotFoundException($"Product with {id} was not found");
            }

            return product;

        }

        public Product Save(Product product)
        {

            _context.Add(product);
            _context.SaveChanges();

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .Select(product => product)
                .ToList();
        }

        private bool ExistsById(int id)
        {
            return _context.Products.Any(product => product.Id == id);
        }
    }
}
