using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public interface IRepository<T>
    {
        //Get
        IEnumerable<T> GetAll();
        T GetSingle(int id);
        //POST
        void Add(T Entity);
        //PUT
        void Update(T Entity);
        //Delete
        void Delete(int id);
        void Save();

        Task SaveAsync();
    }
}