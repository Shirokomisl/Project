using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace LampShop.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderByUserIdAsync(int userId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.UserID == userId);
        }

        public async Task<Order?> GetOrderByProductIdAsync(int productId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderProducts.Any(op => op.ProductID == productId));
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(int orderId, Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(orderId);
            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.Status = order.Status;

            await _context.SaveChangesAsync();
            return existingOrder;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}