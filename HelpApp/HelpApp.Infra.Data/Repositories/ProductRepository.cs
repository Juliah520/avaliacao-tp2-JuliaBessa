using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> Create(Product produto)
        {
            _productContext.Add(produto);
            await _productContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Product> GetById(int? id)
        {
            var produto = await _productContext.Products.FindAsync(id);
            return produto;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productContext.Products.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<Product> Update(Product produto)
        {
            _productContext.Update(produto);
            await _productContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Product> Remove(Product produto)
        {
            _productContext.Remove(produto);
            await _productContext.SaveChangesAsync();
            return produto;
        }
    }
}
