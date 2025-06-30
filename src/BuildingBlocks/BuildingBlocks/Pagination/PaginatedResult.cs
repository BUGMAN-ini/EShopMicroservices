using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Pagination
{
    public class PaginatedResult<TEntity>
        (int pageIndex, int PageSize, long count, IEnumerable<TEntity> data) 
        where TEntity : class
    {
        public int PageIndex { get; } = pageIndex;
        public int PageSize { get; } = PageSize;
        public long Count { get; } = count;
        public IEnumerable<TEntity> Data { get; } = data;
        public int TotalPages => (int)Math.Ceiling(Count / (double)PageSize);
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}
