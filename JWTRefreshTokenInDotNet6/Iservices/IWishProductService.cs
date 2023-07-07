using PET.Models;

namespace PET.Iservices
{
    public interface IWishProductService
    {

        Task<WishProduct> AddWishProduct(WishProduct model);
        Task<List<WishProduct>> GetAllWishProduct();
        Task<bool> DeleteWishProduct(int id);


    }
}
