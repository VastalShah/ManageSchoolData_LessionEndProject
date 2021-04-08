using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int? id);
        
        Task Insert(T entity);
        
        Task Update(T entity);
        
        Task Delete(int id);
    }
}
