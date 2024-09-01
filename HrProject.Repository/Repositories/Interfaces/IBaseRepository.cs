using HrProject.Domain.Entities.Base;
using System.Linq.Expressions;

namespace HrProject.Repository.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity Insert(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);
        public TEntity GetById(int id);
        public IEnumerable<TEntity> Where(Func<TEntity, bool> filter);
        public IEnumerable<TEntity> GetAll();
        public bool ExistsByProperty<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, TProperty value);
    }
}
