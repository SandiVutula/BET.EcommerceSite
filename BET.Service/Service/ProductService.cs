using BET.Data.GenericRepository;
using BET.Data.Model;
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
    }
}
