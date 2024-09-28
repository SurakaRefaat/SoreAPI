using Store.Data.Entities;


namespace Store.Repository.Specification.ProductSpecs
{
    public class productWithCountSpecification : BaseSpecification<Product>
    {
        public productWithCountSpecification(ProductSpecification specs)
           : base(Product => 
                 (!specs.BrandId.HasValue || Product.BrandId == specs.BrandId.Value)
                                                      &&
                 (!specs.TypeId.HasValue || Product.TypeId == specs.TypeId.Value)
                                                      &&
                 (string.IsNullOrEmpty(specs.Searech) || Product.Name.Trim().ToLower().Contains(specs.Searech))

                  )
                                                            
        {
        
        }
    }
}
