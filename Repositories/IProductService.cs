using WebApplication6.Entities;
namespace WebApplication6.Repositories
{
    public interface IProductService
    {
        public Task<List<Products>> GetProductListAsync();
        public Task<IEnumerable<Products>> GetProductByIdAsync(int Id);
        public Task<int> AddProductAsync(Products product);
        public Task<int> UpdateProductAsync(Products product);
        public Task<int> DeleteProductAsync(int Id);
    }
}

