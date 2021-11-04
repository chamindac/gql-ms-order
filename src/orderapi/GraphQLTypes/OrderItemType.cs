using GraphQL.Types;
using orderapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.GraphQLTypes
{
    public class OrderItemType:ObjectGraphType<OrderItem>
    {
        public OrderItemType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the order object.");
            Field(x => x.ItemName).Description("Item name property from the order object.");
            Field(x => x.Quantity).Description("Quantity property from the order object.");
            Field(x => x.Price).Description("Price property from the order object.");
        }
    }
}
