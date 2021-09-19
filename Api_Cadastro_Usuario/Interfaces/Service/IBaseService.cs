using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public T GetOne(Guid codigo);
        public IEnumerable<T> GetAll();
        public T Delet(Guid model);
    }
}
