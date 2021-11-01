using GraphQL.Types;
using orderapi.Contracts;
using orderapi.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderapi.GrapshQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOrderRepository repository)
        {
            Field<ListGraphType<OrderType>>(
               "orders",
               resolve: context => repository.GetAll()
           );
        }
    }
}
