using BET.Data.GenericRepository;
using BET.Data.Model.Dto;
using BET.Service.Contract;

namespace BET.Service.Service
{
    public class ProductService : IProductService
    {

        private readonly IRepositoryReadOnly _iRepository;
        public ProductService(IRepositoryReadOnly iRepository)
        {
            _iRepository = iRepository;
        }

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            var products = await _iRepository.GetAllAsync<Product>();
            return products.ToList();
        }
        public async Task<Product> GetProductAsync(int productId)
        {
            var product = await _iRepository.GetOneAsync<Product>(p => p.ProductId== productId);
            return product;
        }
    }
}
