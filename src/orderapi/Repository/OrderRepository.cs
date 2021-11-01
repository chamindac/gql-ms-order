using orderapi.Contracts;
using orderapi.Entities;
using orderapi.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll() => _context.Orders.ToList();

        public Order CreateOrder(Order order)
        {
            order.Date = DateTime.Now;
            _context.Add(order);
            _context.SaveChanges();
            return order;
        }
    }
}
