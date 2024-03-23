using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class // this will be generic class T and we will say where T will be class
    {
        IEnumerable<T> GetAll();
        T FirstOrDefault(Expression<Func<T,bool>> filter);
        void Add(T entity);
        //void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        bool Any(Expression<Func<T, bool>> filter);
    }
}
