using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProuductService
    {
        private readonly ApplicationDbContext _context;

        public ProuductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product AddProduct(string name , int price,int balance) { 
            Product product = new Product {
                Name = name,
                Price = price,
                Balance = balance
            };
            _context.Products.Add(product);

            _context.SaveChanges();

            return product;
        }
    }
}
