using GraphQL;
using GraphQL.Types;
using orderapi.Contracts;
using orderapi.Entities;
using orderapi.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.GrapshQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IOrderRepository repository)
        {
            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "order" }),
                resolve: context =>
                {
                    var order = context.GetArgument<Order>("order");
                    return repository.CreateOrder(order);
                }
            );
        }
    }
}
