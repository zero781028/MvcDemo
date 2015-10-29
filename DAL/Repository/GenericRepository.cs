using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces;
using Domain;
using System.Data;

namespace DAL.Repository
{
    public class GenericRepository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        internal XINEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            context = new XINEntities();
            dbSet = context.Set<TEntity>();
            
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                return orderBy(query);
            else
                return query;
        }

        public TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(object id)
        {
            TEntity entityDelete = dbSet.Find(id);
            Delete(entityDelete);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == System.Data.Entity.EntityState.Detached)
                dbSet.Attach(entity);
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }
    }
}
