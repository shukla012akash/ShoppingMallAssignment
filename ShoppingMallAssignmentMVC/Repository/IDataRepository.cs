using ShoppingMallAssignmentDB.Models;

namespace ShoppingMallAPI.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        void Add(ShoppingMallModel shoppingMall);
    }
}
