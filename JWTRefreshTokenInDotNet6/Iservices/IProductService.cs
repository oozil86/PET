using PET.Models;

namespace PET.Iservices
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product model);
        Task<Product> EditProduct(Product model);
        Task<bool> SaveProductPath(string Path, int ProductId);
        Task<bool> DeleteProduct(int id);
        Task<List<Product>> GetAllProduct();
        Task<Product> GetAllProductById(int ProductId);
        Task<List<Product>> GetAllProductBySubCate(int SubCategoryId);
        Task<List<SubCategory>> GetAllSubCate();
        Task<List<Category>> GetAllCategory();
        Task<List<SubCategory>> GetAllSubCategory(int CategoryId);
    }
}
