using EasyNetQ;
using messages;
using Microsoft.EntityFrameworkCore;
using orderapi.Contracts;
using orderapi.Entities.Context;
using orderapi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.EventHandlers
{
    public class OrderHandler
    {
        public static IBus bus;
        public static string ConString;
        
        private static IOrderRepository GetRepository()
        {
            DbContextOptions dbConOptions = new DbContextOptionsBuilder().UseSqlServer(ConString).Options;
            OrderDbContext dbcontext = new OrderDbContext(dbConOptions);
            IOrderRepository repository = new OrderRepository(dbcontext, bus);
            return repository;
        }

        public static void CustomerOrderCreditAvailable(CustomerOrderCreditAvailableMessage customerOrderCreditAvailableMessage)
        {
            IOrderRepository repository = GetRepository();
            repository.ConfirmOrderWithCredits(customerOrderCreditAvailableMessage.OrderId);
        }


        public static void CustomerOrderCreditNotAvailable(CustomerOrderCreditNotAvailableMessage customerOrderCreditNotAvailableMessage)
        {
            IOrderRepository repository = GetRepository();
            repository.CancelOrderNoCredits(customerOrderCreditNotAvailableMessage.OrderId);
        }
    }
}
