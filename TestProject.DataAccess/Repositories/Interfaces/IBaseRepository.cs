using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
        Task<List<T>> GetAll();
        Task Create(T item);
        Task Update(T item);
        Task Delete(T item);
    }
}
