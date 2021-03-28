using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
        Task<List<T>> GetAll();
        Task<T> Create(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<T> GetById(int id);
    }
}
