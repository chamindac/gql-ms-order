using EasyNetQ;
using messages;
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
        private readonly IBus _bus;

        public OrderRepository(OrderDbContext context, IBus bus)
        {
            _context = context;
            _bus = bus;
        }

        public IEnumerable<Order> GetAll() => _context.Orders.ToList();

        public Order CreateOrder(Order order)
        {
            order.Date = DateTime.Now;
            _context.Add(order);
            _context.SaveChanges();

            OrderCreatedMessage orderCreatedMsg = new OrderCreatedMessage()
            {
                OrderId = order.Id,
                OrderNumber = order.Number,
                OrderAmount = order.Items.Sum(oi => oi.Price * oi.Quantity)
            };

            _bus.PubSub.Publish(orderCreatedMsg);

            return order;
        }
    }
}
