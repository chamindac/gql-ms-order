using GraphQL.Types;
using orderapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.GraphQLTypes
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the order object.");
            Field(x => x.Number).Description("Order number property from the order object.");
            Field(x => x.CustomerCode).Description("Customer code property from the order object.");
            Field(x => x.CustomerName).Description("Customer name property from the order object.");
            Field<ListGraphType<OrderItemType>>("items");
            //Field(x => x.Date).Description("Order date property from the order object.");
        }
    }
}
