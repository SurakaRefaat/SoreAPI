using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.Data.Entities;

namespace Store.Repository.Specification
{
    public class SpecificationEvaluator <TEntity , TKey> where TEntity : BaseEntitiy<TKey>
    {
        // IEnumerable Vs IQueryable
        public static IQueryable <TEntity> GetQuery(IQueryable<TEntity>inputQuery,ISpecification<TEntity> specs) 
        {
            var query = inputQuery;
            if (specs.Criteria != null)

                query.Where(specs.Criteria); //X => X.TypeId ==3

            if (specs.OrdeBy != null)
                query = query.OrderBy(specs.OrdeBy);

            if (specs.OrdeByDescending != null)
                query = query.OrderByDescending(specs.OrdeByDescending);

            if (specs.ISPaginated)
                query= query.Skip(specs.Skip).Take(specs.Take);


            query = specs.Includes.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));

            return query;
        }

    }
}
