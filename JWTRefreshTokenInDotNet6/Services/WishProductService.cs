using PET.Iservices;
using PET.Models;

namespace PET.Services
{
    public class WishProductService: IWishProductService
    {
        private readonly ApplicationDbContext _context;
        public WishProductService(ApplicationDbContext context) => _context = context;

        public async Task<WishProduct> AddWishProduct(WishProduct model)
        {
            try
            {
                await _context.WishProduct.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteWishProduct(int id)
        {
            try
            {
                var q = await _context.WishProduct.FindAsync(id);
                if (q is not null)
                {
                    _context.WishProduct.Remove(q);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<WishProduct>> GetAllWishProduct()
        {
            try
            {
                return await _context.WishProduct.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
