using Api_Cadastro_Usuario.Data;
using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api_Cadastro_Usuario.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Api_Cadastro_UsuarioContext _context;
        public UsuarioRepository(Api_Cadastro_UsuarioContext context)
        {
            _context = context;
        }

        public void Delet(UsuarioModel model)
        {
            _context.UsuarioModel.Remove(model);
            SaveChangesDb();
        }
        public IEnumerable<TasksToDoModel> GetAllTasks(Guid id)
        {
            return _context.TasksToDo.Where(x => x.Id_Usuario == id).OrderBy(x=>x.Horario_Post).ToList();
        }
        public DbSet<UsuarioModel> GetContext()
        {
            return _context.UsuarioModel;
        }
        public IEnumerable<UsuarioModel> GetAll()
        {
            return _context.UsuarioModel.ToList();
        }

        public UsuarioModel GetByEmail(string email)
        {
            return _context.UsuarioModel.Where(e => e.Email == email).FirstOrDefault();
        }

        public UsuarioModel GetOne(Guid codigo)
        {
            return _context.UsuarioModel.Where(e => e.Codigo == codigo).FirstOrDefault();
        }

        public UsuarioModel Login(UsuarioModel usuario)
        {
            return _context.UsuarioModel.Where(a => a.Email == usuario.Email && a.Senha == usuario.Senha).FirstOrDefault();
        }

        public void Create(UsuarioModel usuario)
        {
            _context.UsuarioModel.Add(usuario);
            SaveChangesDb();
        }
        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }

        public UsuarioModel Put(Guid id, UsuarioModel usuario)
        {

            if (id != usuario.Codigo)
                return null;

            try
            {
                SaveChangesDb();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.GetOne(id) == null)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return usuario;
        }

        public UsuarioModel GetByPassword(string senha)
        {
            return _context.UsuarioModel.Where(a => a.Senha == senha).FirstOrDefault();
        }
    }
}
