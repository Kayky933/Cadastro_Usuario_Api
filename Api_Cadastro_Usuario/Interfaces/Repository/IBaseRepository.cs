using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Cadastro_Usuario.Interfaces.Repository
{
    public interface IBaseRepository<T>where T:class
    {
        public T GetOne(Guid id);
        public IEnumerable<T> GetAll();
        public T GetByEmail(string email);
        public void Create(T model);
        public void Delet(T model);
    }
}
