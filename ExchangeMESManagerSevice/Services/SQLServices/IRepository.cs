using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeMESManagerSevice.Services.SQLServices
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByNId(string NId);
        int Create(T obj);
        int Update(T obj);
        int Delete(string NId);
    }
}
