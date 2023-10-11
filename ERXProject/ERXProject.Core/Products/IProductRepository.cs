namespace ERXProject.Core.Products
{
    public interface IProductRepository
    {
        Task<Product> InsertAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> GetByCodeAsync(int code);
        Task<Product> UpdateAsync(Product product);
        Task<Product> DeleteAsync(Guid id);
    }
}
