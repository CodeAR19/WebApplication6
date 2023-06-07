using WebApplication6.Data;
using WebApplication6.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace WebApplication6.Repositories
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;

        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Products>> GetProductListAsync()
        {
            return await _dbContext.Product
                .FromSqlRaw<Products>("GetPrductList")
                .ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProductByIdAsync(int ProductId)
        {
            var param = new SqlParameter("@ProductId", ProductId);

            var productDetails = await Task.Run(() => _dbContext.Product
                            .FromSqlRaw(@"exec GetPrductByID @ProductId", param).ToListAsync());

            return productDetails;
        }

        public async Task<int> AddProductAsync(Products product)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@ProductId", product.ProductId));
            parameter.Add(new SqlParameter("@ProductName", product.ProductName));
            parameter.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            parameter.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
            parameter.Add(new SqlParameter("@ProductStock", product.ProductStock));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewProduct @ProductId,@ProductName, @ProductDescription, @ProductPrice, @ProductStock", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateProductAsync(Products product)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@ProductId", product.ProductId));
            parameter.Add(new SqlParameter("@ProductName", product.ProductName));
            parameter.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            parameter.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
            parameter.Add(new SqlParameter("@ProductStock", product.ProductStock));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateProduct @ProductId, @ProductName, @ProductDescription, @ProductPrice, @ProductStock", parameter.ToArray()));
            return result;
        }
        public async Task<int> DeleteProductAsync(int ProductId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeletePrductByID {ProductId}"));
        }
    }
}
