using System;
using System.Data.Entity;
using WebApiExample.Server.DataAccessLayer;

namespace WebApiExample.Server.PersistenceLayer
{
    public class AbstractRepository<TEntity> where TEntity : class
    {
        #region Private Variables
        internal DataContext _context;
        internal DbSet<TEntity> _dbset;
        #endregion

        #region Constructors
        public AbstractRepository(DataContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Please supply a context");
            }
            _context = context;
            _dbset = context.Set<TEntity>();
        }
        #endregion

        #region Queries
        /// <summary>
        /// Finds a single entity based on a unique id for the entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            return _dbset.Find(id);
        }
        #endregion

        #region CRUD
        public virtual void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Delete(int id)
        {
            var e = GetById(id);
            if (e != null)
            {
                _dbset.Remove(e);
            }
        }

        public virtual void Update(TEntity entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}