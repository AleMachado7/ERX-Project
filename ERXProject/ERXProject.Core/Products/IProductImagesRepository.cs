namespace ERXProject.Core.Products
{
    public interface IProductImagesRepository
    {
        Task<bool> InsertImagesAsync(Guid productId, List<string> images);
        Task<List<string>> GetImagesAsync(Guid productId);
        Task<bool> DeleteImagesAsync(Guid productId);
    }
}
