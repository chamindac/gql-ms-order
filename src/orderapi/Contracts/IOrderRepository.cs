using orderapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.Contracts
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order CreateOrder(Order order);
        void CancelOrderNoCredits(int orderId);
        void ConfirmOrderWithCredits(int orderId);
    }
}
