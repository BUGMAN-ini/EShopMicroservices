using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Query.GetOrdersByCustomer
{
    public class GetOrderByCustomerHandler(IApplicationDbContext dbcontext) 
        : IQueryHandler<GetOrderByCustomerQuery, GetOrdersByCustomerResult>
    {
        public Task<GetOrdersByCustomerResult> Handle(GetOrderByCustomerQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
