using PET.Iservices;
using PET.Models;

namespace PET.Services
{
    public class SalesProductService : ISalesProductService
    {
        private readonly ApplicationDbContext _context;
        public SalesProductService(ApplicationDbContext context) => _context = context;

        public async Task<SalesProduct> AddSalesProduct(SalesProduct model)
        {
            try
            {

                var q = await _context.Product.FindAsync(model.ProductId);
                model.Qty = 1.ToString();

                var qty = Convert.ToInt64(q.Qty) - 1;
                q.Qty = qty.ToString();
                 _context.Product.Update(q);
                await _context.SalesProduct.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteSalesProduct(int id)
        {
            try
            {
                var q = await _context.SalesProduct.FindAsync(id);
                if (q is not null)
                {
                    _context.SalesProduct.Remove(q);
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

        public async Task<List<SalesProduct>> GetAllSalesProduct()
        {
            try
            {
                return await _context.SalesProduct.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
