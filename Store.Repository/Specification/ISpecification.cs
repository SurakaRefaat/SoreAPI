using System.Linq.Expressions;

namespace Store.Repository.Specification
{
    public interface ISpecification <T>
    {
        Expression<Func<T, bool>> Criteria { get; } // Criteria .where(X => X.Id == Id)
        List<Expression<Func<T,object>>> Includes { get; } // Includes

        Expression<Func<T, object>> OrdeBy { get; }
        Expression<Func<T, object>> OrdeByDescending { get; }

        int Take { get; }

        int Skip { get; }
        bool ISPaginated { get; }

    }
}
