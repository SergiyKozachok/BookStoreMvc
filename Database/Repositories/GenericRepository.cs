using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Database.Models;

namespace Database.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DatabaseContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(DatabaseContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAllQueryable(
            IEnumerable<Expression<Func<TEntity, bool>>> filters,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null
                ? orderBy(query)
                : query;
        }

        public virtual IQueryable<TEntity> GetAllQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            return GetAllQueryable(filter == null ? null : new[] { filter }, orderBy, includeProperties);
        }

        public virtual IEnumerable<TEntity> GetAll(
            IEnumerable<Expression<Func<TEntity, bool>>> filters,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return (orderBy?.Invoke(query) ?? query).ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            return GetAll(filter == null ? null : new[] { filter }, orderBy, includeProperties);
        }


        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return Count(filter == null ? null : new[] { filter });
        }

        public virtual int Count(IEnumerable<Expression<Func<TEntity, bool>>> filters = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }
            return query.Count();
        }

        public virtual TEntity GetById(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            var query = DbSet.Where(filter);
            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault();
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IEnumerable<TResult> SelectAll<TResult>(
            Expression<Func<TEntity, TResult>> select,
            IEnumerable<Expression<Func<TEntity, bool>>> filters,
            Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null,
            bool doDistinct = false,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var result = query.Select(select);

            if (orderBy != null)
            {
                result = orderBy(result);
            }

            if (doDistinct)
            {
                result = result.Distinct();
            }
            return result.ToList();
        }

        public virtual IEnumerable<TResult> SelectAll<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null,
            bool doDistinct = false,
            string includeProperties = "")
        {
            return SelectAll(select, filter == null ? null : new[] { filter }, orderBy, doDistinct, includeProperties);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }
    }
}