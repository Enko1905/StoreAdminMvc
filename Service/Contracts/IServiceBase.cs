using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceBase<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetOne(int id);
        Task<bool> CreateOne(T entity);
        Task<bool> UpdateOne(int id, T entity);
        Task<bool> DeleteOne(int id);

    }
}
