using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;
using System;

namespace Api_Cadastro_Usuario.ClassConvert
{
    public static class ExtensionMethods
    {
        public static UsuarioModel ViewModelToUsuario(this UsuarioViewModel viewModel)
        {
            UsuarioModel usuario = new();
            usuario.Nome = viewModel.Nome;
            usuario.Email = viewModel.Email;
            usuario.Data_Nascimento = viewModel.Data_Nascimento;
            usuario.Senha = viewModel.Senha;
            return usuario;
        }
        public static UsuarioViewModel UsuarioModelToView(this UsuarioModel usuario)
        {
            UsuarioViewModel view = new();
            view.Nome = usuario.Nome;
            view.Senha = usuario.Senha;
            view.Email = usuario.Email;
            view.Data_Nascimento = usuario.Data_Nascimento;
            return view;
        }

        public static TasksViewModel PostTasksViewModelToTasksViewModel(this TasksPostViewModel viewModel, Guid id)
        {
            TasksViewModel tasks = new();
            tasks.Task = viewModel.Task;
            tasks.Horario_Agendado = viewModel.Horario_Agendado;
            tasks.Id_Usuario = id;
            return tasks;
        }
        public static TasksToDoModel ViewModelToTasks(this TasksPostViewModel viewModel, Guid id)
        {
            TasksToDoModel tasks = new();
            tasks.Task = viewModel.Task;
            tasks.Horario_Agendado = viewModel.Horario_Agendado;
            tasks.Id_Usuario = id;
            return tasks;
        }
        public static UsuarioModel LoginModelToUsuario(this UsuarioLogin usuario)
        {
            UsuarioModel user = new();
            user.Email = usuario.Email;
            user.Senha = usuario.Senha;
            return user;
        }
    }
}
