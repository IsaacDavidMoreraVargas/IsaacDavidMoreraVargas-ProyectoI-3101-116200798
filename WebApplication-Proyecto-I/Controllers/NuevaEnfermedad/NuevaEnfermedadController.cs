using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Net.Mail;
using System.Net;
using WebApplication_Proyecto_I.Controllers.Ingreso;
using WebApplication_Proyecto_I.Controllers.Profesional;
using WebApplication_Proyecto_I.Models.Profesional;
using System.Reflection;
using System.Xml.Linq;

namespace WebApplication_Proyecto_I.Controllers.NuevaEnfermedad
{
    public class NuevaEnfermedadController : Controller
    {
        string correo_enviador = "";
        string contrasena_correo_enviador = "";
        string host_enviador = "";
        int puerto_enviador =587;

        [BindProperty]
        public Models.Profesional.asociar_profesional Registro_registro { get; set; }
        DatosProfesional_Context context = new DatosProfesional_Context();

        public IActionResult Index(int id)
        {
            //Console.WriteLine("->"+id);
            switch (id)
            {
                case 1:
                    TempData["numero_pantalla"] = 1;
                    TempData["contador_de_record"] = "2,5";
                    break;

                case 2:
                    TempData["numero_pantalla"] = 2;
                    TempData["contador_de_record"] = "3,5";
                    break;

                case 3:
                    TempData["numero_pantalla"] = 3;
                    TempData["contador_de_record"] = "4,5";
                    break;

                case 4:
                    TempData["numero_pantalla"] = 4;
                    TempData["contador_de_record"] = "5,5";
                    break;

                default:
                    TempData["numero_pantalla"] = 0;
                    TempData["contador_de_record"] = "1,5";
                    break;
            }
            return View();
        }

        public string ConsultaInmediata(int menu, int id, int codigo)
        {
            Models.Profesional.asociar_profesional esqueleto = new Models.Profesional.asociar_profesional();
            var resultados = context.Registros_Profesional.ToList();
            var string_retorno = "null";
            if (resultados !=null)
            {
                bool encontrado = false;

                foreach (Models.Profesional.asociar_profesional valor in resultados)
                {
                    if (valor.Identificacion_Profesional == id && valor.Codigo_Profesional == codigo)
                    {
                        encontrado = true;
                        esqueleto = valor;
                        break;
                    }
                }
                //Console.WriteLine("1->:"+encontrado + " " + esqueleto.Identificacion_Profesional + "-" + esqueleto.Nombre_Completo_Profesional);
                if (encontrado == true)
                {
                    string_retorno = "{"+
                        "'Identificacion_Profesional':'"+ esqueleto.Identificacion_Profesional + "',"+
                        "'Codigo_Profesional':'"+ esqueleto.Codigo_Profesional + "'," +
                        "'Nombre_Completo_Profesional':'" + esqueleto.Nombre_Completo_Profesional + "'," +
                        "'Correo_Electronico_Profesional':'" + esqueleto.Correo_Electronico_Profesional + "'," +
                        "'Pais_Residencia_Profesional':'" + esqueleto.Pais_Residencia_Profesional + "'," +
                        "'Estado_Provincia_Residencia_Profesional':'" + esqueleto.Estado_Provincia_Residencia_Profesional + "'"+
                        "}";
                    string_retorno = string_retorno.Replace("'","?");
                    string_retorno = string_retorno.Replace('?', '"');
                }
            }
            return (string_retorno);
        }

        [HttpPost]
        public void Enviar_Email(string sender,string contrasena,string a_host,int puerto, string receiver, string subject, string message)
        {
                try
                {
                        var senderEmail = new MailAddress(sender, sender);
                        //var receiverEmail = new MailAddress(receiver, "Receiver"); 
                        var receiverEmail = new MailAddress(receiver, receiver);
                        var password = contrasena;
                        var sub = subject;
                        var body = message;
                        var smtp = new SmtpClient
                        {
                            //Host = "smtp.gmail.com",
                                Host = a_host,
                            //Port = 587,
                                Port = puerto,
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(senderEmail.Address, password)
                        };
                        using (var mess = new MailMessage(senderEmail, receiverEmail)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(mess);
                        }
                }
                catch (Exception e)
                {
                     Console.WriteLine("Error enviando email: "+e);
                }
        }
        public IActionResult Registro_Medio()
        {
            var resultados = context.Registros_Profesional.Find(Registro_registro.Identificacion_Profesional);
            if (resultados != null)
            {
                context.Registros_Profesional.Remove(resultados);
                context.SaveChanges();
            }
            context.Registros_Profesional.Add(Registro_registro);
            context.SaveChanges();
            Enviar_Email(correo_enviador, contrasena_correo_enviador, host_enviador, puerto_enviador, Registro_registro.Correo_Electronico_Profesional, "Registro de datos de Profesional", "Se han guardado exitosamente los datos del profesional:"+ Registro_registro.Identificacion_Profesional);
            return RedirectToAction("Index", "NuevaEnfermedad");
        }
    }
}
