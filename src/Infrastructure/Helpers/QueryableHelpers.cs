using Infrastructure.Commons.Bases;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Helpers
{
    public static class QueryableHelpers
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, BasePaginationRequest request)
        {
            return queryable.Skip((request.NumPage - 1) * request.Records).Take(request.Records);
        }
    }
}
