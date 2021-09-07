using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public T GetOne(Guid id);
        public IEnumerable<T> GetAll();
        public T GetByEmail(string email);
        public T Create(T model);
        public T Delet(T model);
    }
}
