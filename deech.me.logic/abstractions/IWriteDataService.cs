using deech.me.data.abstractions;

namespace deech.me.logic.abstractions
{
    public interface IWriteDataService<TEntity> where TEntity : IWriteEntity
    {
         TEntity Add(TEntity entity);
         TEntity Update(TEntity entity);
         TEntity Delete(TEntity entity);
    }
}