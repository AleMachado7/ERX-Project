namespace ERXProject.Core.Products
{
    public interface IProductService
    {
        Task<ProductResult> CreateAsync(ProductParams createParams);
        Task<List<ProductResult>> GetAllAsync();
        Task<ProductResult> GetByIdAsync(Guid id);
        Task<ProductResult> GetByCodeAsync(int code);
        Task<ProductResult> UpdateAsync(Guid id, ProductParams updateParams);
        Task<ProductResult> DeleteAsync(Guid id);
    }
}
