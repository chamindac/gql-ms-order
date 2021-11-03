using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.GraphQLTypes
{
    public class OrderInputType : InputObjectGraphType
    {
        public OrderInputType()
        {
            Name = "orderInput";
            Field<NonNullGraphType<StringGraphType>>("number");
            Field<NonNullGraphType<StringGraphType>>("customername");
            Field<ListGraphType<OrderItemInputType>>("items");
            //Field<NonNullGraphType<DateTimeGraphType>>("date");
        }
    }
}
