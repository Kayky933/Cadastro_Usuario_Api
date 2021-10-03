﻿using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;

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

        public static TasksToDoModel ViewModelToTasks(this TasksViewModel viewModel)
        {
            TasksToDoModel tasks = new();
            tasks.Task = viewModel.Task;
            tasks.Horario_Agendado = viewModel.Horario_Agendado;
            tasks.Id_Usuario = viewModel.Id_Usuario;
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
