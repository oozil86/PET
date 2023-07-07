using PET.Models;

namespace PET.Iservices
{
    public interface ISalesProductService
    {

        Task<SalesProduct> AddSalesProduct(SalesProduct model);
        Task<bool> DeleteSalesProduct(int id);
        Task<List<SalesProduct>> GetAllSalesProduct();

    }
}
