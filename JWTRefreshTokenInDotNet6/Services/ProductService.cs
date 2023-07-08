using PET.Iservices;
using PET.Models;

namespace PET.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) => _context = context;
        public async Task<Product> AddProduct(Product model)
        {
            try
            {
                await _context.Product.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var q = await _context.Product.FindAsync(id);
                if (q is not null)
                {
                    _context.Product.Remove(q);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                throw;
            }
        }

        public async Task<Product> EditProduct(Product model)
        {
            try
            {
                _context.Product.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Category>> GetAllCategory()
        {
            try
            {
                return await _context.Category.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetAllProduct()
        {
            try
            {
            return   await _context.Product.Where(a=>a.Qty != "0").Include(a=>a.SubCategory).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> GetAllProductById(int ProductId)
        {
            try
            {
                return await  _context.Product.FirstOrDefaultAsync(a => a.Id == ProductId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetAllProductBySubCate(int SubCategoryId)
        {
            try
            {
                return await _context.Product.Where(a=>a.SubCategoryId == SubCategoryId).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SubCategory>> GetAllSubCate()
        {
            try
            {
                return await _context.SubCategory.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SubCategory>> GetAllSubCategory(int CategoryId)
        {
            try
            {
                return await _context.SubCategory.Where(a => a.CategoryId == CategoryId).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SaveProductPath(string Path,int ProductId)
        {
            try
            {
                var product = await _context.Product.FindAsync(ProductId);
                if (product is not null)
                {
                    product.Photo = Path; 
                    _context.Product.Update(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                throw;
            }
        }
    }
}
