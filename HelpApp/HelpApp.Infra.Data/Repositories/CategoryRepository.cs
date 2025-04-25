using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HelpApp.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _categoryContext ;

        public CategoryRepository(ApplicationDbContext context)
        {
        _categoryContext = context; 
        }

        public async Task<Category> Create(Category categoria)
        {
             _categoryContext.Add(categoria);
            await _categoryContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Category> GetById(int? id)
        {
            var categoria = await _categoryContext.Categories.FindAsync(id);
            return categoria;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<Category> Update(Category categoria)
        {
            _categoryContext.Update(categoria);
            await _categoryContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Category> Remove(Category categoria)
        {
            _categoryContext.Remove(categoria);
            await _categoryContext.SaveChangesAsync();
            return categoria;
        }

    }
}
