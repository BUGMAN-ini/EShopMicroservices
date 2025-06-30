using Microsoft.EntityFrameworkCore;
using Ordering.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Query.GetOrdersByName
{
    public class GetOrdersByNameHandler(IApplicationDbContext dbcontext) 
        : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery request, CancellationToken cancellationToken)
        {
            var orders = await dbcontext.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.OrderName.Value.Contains(request.Name))
                .OrderBy(o => o.OrderName)
                .ToListAsync(cancellationToken);

            return new GetOrdersByNameResult(orders.ToOrderDtos());
        }
    }
}
