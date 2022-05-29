using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
                 
        public void Add(TEntity model)
        {
            using (TContext context=new TContext())
            {
                EntityEntry<TEntity> addedEntity =  context.Set<TEntity>().Add(model);                              
                 addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity model)
        {
            using (TContext context=new TContext()) 
            {
                EntityEntry<TEntity> deletedEntity = context.Set<TEntity>().Remove(model);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context=new TContext())
            {
                return filter == null 
                    ? context.Set<TEntity>().ToList() 
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity model)
        {
            using (TContext context = new TContext())
            {
                EntityEntry<TEntity> updetedEntity= context.Set<TEntity>().Update(model);
                updetedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
