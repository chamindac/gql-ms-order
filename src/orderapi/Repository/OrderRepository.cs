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
            order.State = OrderState.New;
            _context.Add(order);
            _context.SaveChanges();

            OrderCreatedMessage orderCreatedMsg = new OrderCreatedMessage()
            {
                OrderId = order.Id,
                OrderNumber = order.Number,
                OrderAmount = order.Items.Sum(oi => oi.Price * oi.Quantity)
            };

            _bus.PubSub.Publish<OrderCreatedMessage>(orderCreatedMsg,"Order.NewOrder");

            return order;
        }

        public void CancelOrderNoCredits(int orderId)
        {
            var order = _context.Orders.First(o => o.Id == orderId);
            order.State = OrderState.CanelledLowCredit;
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void ConfirmOrderWithCredits(int orderId)
        {
            var order = _context.Orders.First(o => o.Id == orderId);
            order.State = OrderState.Confirmed;
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
