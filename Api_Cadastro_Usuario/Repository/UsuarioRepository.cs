using Api_Cadastro_Usuario.Data;
using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public IEnumerable<object> GetAllTasks(Guid id)
        {
            CultureInfo idioma = new CultureInfo("pt-BR");
            return _context.TasksToDo.Where(x => x.Id_Usuario == id).OrderBy(x => x.Horario_Post).Select(x => new { x.Task, x.Horario_Post, x.Horario_Agendado }).ToList();
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
            var senha = SecurityService.Criptografar(usuario.Senha);
            return _context.UsuarioModel.Where(a => a.Email == usuario.Email && a.Senha == senha).FirstOrDefault();
        }

        public void Create(UsuarioModel usuario)
        {
            usuario.Senha = SecurityService.Criptografar(usuario.Senha);
            _context.UsuarioModel.Add(usuario);
            SaveChangesDb();
        }
        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }

        public void Put(Guid id, UsuarioModel usuario)
        {
            usuario.Codigo = id;
            usuario.Senha = SecurityService.Criptografar(usuario.Senha);
            this.GetContext().Update(usuario).State = EntityState.Modified;
            SaveChangesDb();
        }

        public UsuarioModel GetByPassword(string senha)
        {
            string senhaCriptograf = SecurityService.Criptografar(senha);
            return _context.UsuarioModel.Where(a => a.Senha == senhaCriptograf).FirstOrDefault();
        }

    }
}
