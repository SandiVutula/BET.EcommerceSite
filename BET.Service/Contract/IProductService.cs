using BET.Data.Model;

namespace BET.Service.Contract
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(int productId);
    }
}
