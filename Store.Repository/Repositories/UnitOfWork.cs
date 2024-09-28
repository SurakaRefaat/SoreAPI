using Store.Data.Contexts;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using System.Collections;


namespace Store.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable _repositoriesl;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        
            => await _context.SaveChangesAsync();

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntitiy<TKey>
         {
            if(_repositoriesl is null)
                _repositoriesl = new Hashtable();

                var entityKey = typeof(TEntity).Name;

            if (!_repositoriesl.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<,>);
                
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _context); // gave instance frome generic repo

                _repositoriesl.Add(entityKey, repositoryInstance);
            }
            return (IGenericRepository<TEntity, TKey>)_repositoriesl[entityKey];
         }
     }
}
