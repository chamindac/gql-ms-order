using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.GraphQLTypes
{
    public class OrderItemInputType : InputObjectGraphType
    {
        public OrderItemInputType()
        {
            Name = "orderItemInput";
            Field<NonNullGraphType<StringGraphType>>("itemname");
            Field<NonNullGraphType<IntGraphType>>("quantity");
            Field<NonNullGraphType<DecimalGraphType>>("price");
            //Field<NonNullGraphType<IntGraphType>>("orderid");
        }
    }
}
