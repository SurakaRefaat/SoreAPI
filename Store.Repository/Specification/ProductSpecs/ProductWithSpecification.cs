using Microsoft.IdentityModel.Tokens;
using Store.Data.Entities;


namespace Store.Repository.Specification.ProductSpecs
{
    public class ProductWithSpecification : BaseSpecification<Product>
    {
        public ProductWithSpecification(ProductSpecification specs) 
            :base (Product =>  
            (!specs.BrandId.HasValue ||Product.BrandId== specs.BrandId.Value) 
                                            &&
            (!specs.TypeId.HasValue ||Product.TypeId== specs.TypeId.Value)
                                            &&
            (string.IsNullOrEmpty(specs.Searech)|| Product.Name.Trim().ToLower().Contains(specs.Searech))
                  )


        {
            AddInclude(X => X.Brand);
            AddInclude(X => X.TypeId);
            AddOrderBy(X => X.Name);

            ApplyPagination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);

            if (!string.IsNullOrEmpty(specs.Sort))
            {
                switch (specs.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(X => X.Price);
                        break;

                    case "PriceDesc":
                        AddOrderByDescending(X => X.Price);
                        break;

                    default: AddOrderBy(X => X.Name); break;

                }
            }
        }

        public ProductWithSpecification(int? id) : base(Product =>Product.Id == id)
        {
            AddInclude(X => X.Brand);
            AddInclude(X => X.TypeId);
           
        }


    }
}
