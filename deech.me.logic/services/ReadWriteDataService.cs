using Microsoft.EntityFrameworkCore;

using deech.me.data.abstractions;
using deech.me.data.context;
using deech.me.logic.abstractions;

namespace deech.me.logic.services
{
    public class ReadWriteDataService<TEntity> : ReadDataService<TEntity>, IWriteDataService<TEntity> where TEntity : class, IWriteEntity
    {
        public ReadWriteDataService(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public TEntity Add(TEntity entity)
        {
            using var context = new DeechMeDataContext(this.dbContextOptions);

            context.Set<TEntity>().Attach(entity);
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();

            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            using var context = new DeechMeDataContext(this.dbContextOptions);

            context.Set<TEntity>().Attach(entity);
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            using var context = new DeechMeDataContext(this.dbContextOptions);

            context.Set<TEntity>().Attach(entity);
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();

            return entity;
        }
    }
}