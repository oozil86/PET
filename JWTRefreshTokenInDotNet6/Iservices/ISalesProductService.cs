using PET.Dto;
using PET.Models;

namespace PET.Iservices
{
    public interface ISalesProductService
    {

        Task<SalesProduct> AddSalesProduct(SalesProduct model);
        Task<List<OrderListDto>> UpdateOrderStatus(int OrderId);
        Task<bool> DeleteSalesProduct(int id);
        Task<List<SalesProduct>> GetAllSalesProduct();
        Task<bool> MakeOrder(OrderDto order);
        Task<List<OrderListDto>> GetOrders();
        Task<bool> DeleteSaleProducts();

    }
}
