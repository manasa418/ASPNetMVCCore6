using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulkybook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T- Category

        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string ? includeProperties = null);
        void Add(T entity);

        void Remove(T entity);

        //To remove more than one entity, use range
        void RemoveRange(IEnumerable<T> entity);

    }
}
