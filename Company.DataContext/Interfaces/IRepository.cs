using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataContext.Interfaces
{
    public interface IRepository<T> where T : class
    {
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T Get(Predicate<T> filter);
        List<T> GetAll(Predicate<T> filter =null);
       
    }
}
