using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Proyecto_I.Controllers.Ingreso
{
    public class IngresoController : Controller
    {
        [BindProperty]
        public Models.Ingreso.asociar_ingreso Registro_registro { get; set; }
        Ingreso_Context context = new Ingreso_Context();

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Redireccionar()
        {
            //Console.WriteLine("----"+Registro_registro.codigo_profesional);
            var resultados = context.Registros_ingreso.ToList();
            bool encontrado=false;
            foreach (Models.Ingreso.asociar_ingreso valor in resultados)
            {
                if (valor.codigo_profesional == Registro_registro.codigo_profesional)
                {
                    encontrado = true;
                    break;
                }
            }
            if (encontrado == true)
            {
                return RedirectToAction("Index", "NuevaEnfermedad");
            }

            return RedirectToAction("Puerta", "Home");
        }


    }
}
