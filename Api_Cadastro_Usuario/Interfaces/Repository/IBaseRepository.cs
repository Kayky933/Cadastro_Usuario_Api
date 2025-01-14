﻿using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        public T GetOne(Guid codigo);
        public IEnumerable<T> GetAll();
        public void Delet(T model);
    }
}
