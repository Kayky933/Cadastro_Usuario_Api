using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api_Cadastro_Usuario.Controllers
{
    public class ControllerPai : Controller
    {
        internal object MostrarErros(ValidationResult res)
        {
            return res.Errors.Select(a => a.ErrorMessage).ToList();
        }
    }
}
