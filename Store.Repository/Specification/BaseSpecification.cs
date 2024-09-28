using System.Linq.Expressions;

namespace Store.Repository.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrdeBy { get; private set; }

        public Expression<Func<T, object>> OrdeByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool ISPaginated { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
            => Includes.Add(includeExpression); 

        protected void AddOrderBy(Expression<Func<T, object>> ordeyByExpression)
            => OrdeBy = ordeyByExpression;
        protected void AddOrderByDescending(Expression<Func<T, object>> OrderByDescendingExpression)
            => OrdeBy = OrderByDescendingExpression;

        protected void ApplyPagination(int skip, int take) 
        {
            Take = take;
            Skip = skip;
            ISPaginated = true;
 
        }

    }
}
