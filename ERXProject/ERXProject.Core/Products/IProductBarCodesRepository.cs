namespace ERXProject.Core.Products
{
    public interface IProductBarCodesRepository
    {
        Task<bool> InsertBarCodesAsync(Guid productId, List<string> barCodes);
        Task<List<string>> GetBarCodesAsync(Guid productId);
        Task<bool> DeleteBarCodesAsync(Guid productId);
    }
}
