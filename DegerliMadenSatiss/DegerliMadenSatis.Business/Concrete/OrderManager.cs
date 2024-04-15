using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task CancelOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Order order)
        {
            await _orderRepository.CreateAsync(order);
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(x => x.Id == orderId, source=>source
            .Include(x=>x.OrderDetails)
            .ThenInclude(y=>y.Product));
            return order;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync(null,
                source=>source
                .Include(x=>x.OrderDetails)
                .ThenInclude(y=>y.Product));                
            return orders;
        }

        public async Task<List<Order>> GetOrdersAsync(string userId)
        {
            var orders = await _orderRepository.GetAllAsync(x=>x.UserId==userId,
                source => source
                .Include(x => x.OrderDetails)
                .ThenInclude(y => y.Product));
            return orders;
        }
    }
}
