using PET.Dto;
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

        public async Task<bool> DeleteSaleProducts()
        {
            try
            {
                var SaleProducts = await _context.SalesProduct.ToListAsync();
                if (SaleProducts is not null)
                {
                    _context.SalesProduct.RemoveRange(SaleProducts);
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
            catch
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

        public async Task<List<OrderListDto>> GetOrders()
        {
            try
            {
                var orders = from order in _context.Orders.Include(c => c.OrderProducts).ThenInclude(c => c.Product)
                             .ThenInclude(c => c.SubCategory).ThenInclude(c => c.Category)
                             .Include(c=>c.OrderProducts).ThenInclude(c=>c.Product).ThenInclude(c=>c.User)
                             join User in _context.Users
                             on order.UserId equals User.Id
                             select new OrderListDto
                             {
                                 Name = order.Name,
                                 Id = order.Id,
                                 Phone = order.Phone,
                                 Status = order.Status,
                                 Address = order.Address,
                                 Appartment = order.Appartment,
                                 Price = order.Price,
                                 UserId = order.UserId,
                                 UserName = User.Email,
                                 OrderProducts = order.OrderProducts,
                                 
                             };
                
                return await orders.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> MakeOrder(OrderDto order)
        {
            try
            {
                var _order = new Order
                {
                    Id = order.Id,
                    Address = order.Address,
                    Appartment = order.Appartment,
                    Name = order.Name,
                    Phone = order.Phone,
                    Price = order.Price,
                    Status = order.Status,
                    UserId = order.UserId,
                };

                await _context.Orders.AddAsync(_order);
                await _context.SaveChangesAsync();

                var IsExists = new List<int>();
               
                foreach (var OrderProduct in order.OrderProducts)
                {

                    if (!IsExists.Where(c => c == OrderProduct.OrderProductId).Any())
                    {
                        var product = new OrderProduct
                        {
                            OrderId = _order.Id,
                            Quantity = order.OrderProducts.Where(c => c.OrderProductId == OrderProduct.OrderProductId).Sum(c => c.Quantity),
                            ProductId = OrderProduct.OrderProductId,
                        };
                        IsExists.Add(product.ProductId);
                        await _context.OrderProducts.AddAsync(product);
                        await _context.SaveChangesAsync();
                    } 
                }
                await DeleteSaleProducts();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<OrderListDto>> UpdateOrderStatus(int OrderId)
        {
            try
            {

                var Order = await _context.Orders.FindAsync(OrderId);

                Order.Status = "Delivered";
                _context.Orders.Update(Order);
                await _context.SaveChangesAsync();
                return await GetOrders();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
