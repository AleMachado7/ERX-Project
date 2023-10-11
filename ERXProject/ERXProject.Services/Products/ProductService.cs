using ERXProject.Core.Products;

namespace ERXProject.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImagesRepository _productImagesRepository;
        private readonly IProductBarCodesRepository _productBarCodesRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<ProductResult> CreateAsync(ProductParams createParams)
        {
            try
            {
                var model = await Product.CreateAsync(createParams);
                var product = await this._productRepository.InsertAsync(model);

                return new ProductResult(product);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ProductResult>> GetAllAsync()
        {
            try
            {
                var productsResult = new List<ProductResult>();
                var products = await this._productRepository.GetAllAsync();

                products.ForEach(product => productsResult.Add(new ProductResult(product)));

                return productsResult;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ProductResult> GetByIdAsync(Guid id)
        {
            try
            {
                var product = await this._productRepository.GetByIdAsync(id);
                product.Images = await this._productImagesRepository.GetImagesAsync(product.Id);
                product.BarCodes = await this._productBarCodesRepository.GetBarCodesAsync(product.Id);

                return new ProductResult(product);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ProductResult> GetByCodeAsync(int code)
        {
            try
            {
                var product = await this._productRepository.GetByCodeAsync(code);

                return new ProductResult(product);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ProductResult> UpdateAsync(Guid id, ProductParams updateParams)
        {
            try
            {
                var model = await this._productRepository.GetByIdAsync(id);

                if (model == null) return null;

                var product = await model.Update(updateParams);

                await this._productRepository.UpdateAsync(product);
                await this._productImagesRepository.DeleteImagesAsync(product.Id);
                await this._productBarCodesRepository.DeleteBarCodesAsync(product.Id);

                if (product.Images.Count > 0)
                {
                    await this._productImagesRepository.InsertImagesAsync(product.Id, product.Images);
                }

                if (product.BarCodes.Count > 0)
                {
                    await this._productBarCodesRepository.InsertBarCodesAsync(product.Id, product.BarCodes);
                }

                return new ProductResult(product);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task<ProductResult> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
