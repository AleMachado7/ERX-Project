using ERXProject.Core.Products;
using ERXProject.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERXProject.API.Controllers
{
    [Route("/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductController(IProductService productService, IUserService userService, IHttpContextAccessor contextAccessor)
        {
            this._productService = productService;
            this._userService = userService;
            this._contextAccessor = contextAccessor;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ProductParams createParams)
        {
            var product = await this._productService.CreateAsync(createParams);

            if (product == null) { return BadRequest(); }

            return this.Ok(product);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var products = await this._productService.GetAllAsync();

            if (products == null) { return BadRequest(); }

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var product = await this._productService.GetByIdAsync(id);

            if (product == null) { return BadRequest(); }

            return this.Ok(product);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ProductParams updateParams)
        {
            var product = await this._productService.UpdateAsync(id, updateParams);

            if (product == null) { return BadRequest(); }

            return this.Ok(product);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            return this.Ok("Hello World");
        }

    }
}
