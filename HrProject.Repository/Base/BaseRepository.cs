using Microsoft.EntityFrameworkCore;
using HrProject.Domain.Entities.Base;
using HrProject.Presentation.Data;
using HrProject.Repository.Repositories.Interfaces;
using System.Linq.Expressions;

namespace HrProject.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(DbContextOptions<ApplicationDbContext> options)
        {
            _context = new ApplicationDbContext(options);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            //_ = Discard variable
            _ = _context.Set<TEntity>().Add(entity);
            _ = _context.SaveChanges();
            // _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _ = _context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            TEntity? entity = _context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            _ = _context.Set<TEntity>().Remove(entity);
            _ = _context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> list = _context.Set<TEntity>().ToList();
            return list;
        }

        public virtual TEntity GetById(int id)
        {
            TEntity result = _context.Set<TEntity>().Find(id);
            return result;
        }

        public virtual IEnumerable<TEntity> Where(Func<TEntity, bool> filter)
        {
            IEnumerable<TEntity> list = _context.Set<TEntity>().Where(filter).ToList();
            return list;
        }

        public bool ExistsByProperty<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, TProperty value)
        {
            return _context.Set<TEntity>().Any(entity => propertySelector.Compile()(entity).Equals(value));
        }
    }
}
