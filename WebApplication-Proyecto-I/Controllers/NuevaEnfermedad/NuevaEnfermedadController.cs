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
using WebApplication_Proyecto_I.Controllers.Clinica;
using System.Drawing;

namespace WebApplication_Proyecto_I.Controllers.NuevaEnfermedad
{
    public class NuevaEnfermedadController : Controller
    {
        string correo_enviador = "";
        string contrasena_correo_enviador = "";
        string host_enviador = "";
        int puerto_enviador =587;

        [BindProperty]
        public Controllers.Referencia_Interna_Modelos Registro_registro { get; set; }
        DatosProfesional_Context context_profesional = new DatosProfesional_Context();
        Clinica_Context context_clinica = new Clinica_Context();
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

        public string ConsultaInmediataProfesional(int menu, int id, int codigo)
        {
            var string_retorno = "null";
            Models.Profesional.asociar_profesional esqueleto = new Models.Profesional.asociar_profesional();
            var resultados = context_profesional.Registros_Profesional.ToList();

            if (resultados != null)
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
                        
                if (encontrado == true)
                {
                    //Console.WriteLine("1->:" + encontrado + " " + esqueleto.Identificacion_Profesional + "-" + esqueleto.Nombre_Completo_Profesional);
                    string_retorno = "{" +
                        "'Identificacion_Profesional':'" + esqueleto.Identificacion_Profesional + "'," +
                        "'Codigo_Profesional':'" + esqueleto.Codigo_Profesional + "'," +
                        "'Nombre_Completo_Profesional':'" + esqueleto.Nombre_Completo_Profesional + "'," +
                        "'Correo_Electronico_Profesional':'" + esqueleto.Correo_Electronico_Profesional + "'," +
                        "'Pais_Residencia_Profesional':'" + esqueleto.Pais_Residencia_Profesional + "'," +
                        "'Estado_Provincia_Residencia_Profesional':'" + esqueleto.Estado_Provincia_Residencia_Profesional + "'" +
                        "}";
                    string_retorno = string_retorno.Replace("'", "?");
                    string_retorno = string_retorno.Replace('?', '"');
                }
            }
            return (string_retorno);
        }
        public string ConsultaInmediataClinica(int menu, int id, string nombre){

            //Console.WriteLine("1->:" + menu + "|" + id + "|"+ nombre + "|");

            var string_retorno = "null";
            Models.Clinica.asociar_clinica esqueleto = new Models.Clinica.asociar_clinica();
            var resultados = context_clinica.Registros_Clinica.ToList();

            if (resultados != null)
            {
                bool encontrado = false;

                foreach (Models.Clinica.asociar_clinica valor in resultados)
                {
                    //Console.WriteLine("1->:" + valor.Cedula_Juridica_Clinica +"|"+id+"|" + valor.Nombre_Clinica+"|"+ nombre+"|");
                    if (valor.Cedula_Juridica_Clinica == id && valor.Nombre_Clinica == nombre)
                    {
                        encontrado = true;
                        esqueleto = valor;
                        break;
                    }
                }

                if (encontrado == true)
                {
                    //Console.WriteLine("1->:" + encontrado + " " + esqueleto.Cedula_Juridica_Clinica + "-" + esqueleto.Nombre_Clinica);
                            
                    string_retorno = "{" +
                        "'Cedula_Juridica_Clinica':'" + esqueleto.Cedula_Juridica_Clinica + "'," +
                        "'Nombre_Clinica':'" + esqueleto.Nombre_Clinica+ "'," +
                        "'Telefono_Administracion_Clinica':'" + esqueleto.Telefono_Administracion_Clinica + "'," +
                        "'Correo_Electronico_Administracion':'" + esqueleto.Correo_Electronico_Administracion + "'," +
                        "'Pais_Clinica':'" + esqueleto.Pais_Clinica + "'," +
                        "'Estado_Provincia_Clinica':'" + esqueleto.Estado_Provincia_Clinica + "'," +
                        "'Distrito_Clinica':'" + esqueleto.Distrito_Clinica+ "'" +
                        "}";
                            
                    string_retorno = string_retorno.Replace("'", "?");
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
        public IActionResult Registro_Medio(int id)
        {
            switch (id)
            {
                case 1:
                    try
                    {
                        var resultados = context_profesional.Registros_Profesional.Find(Registro_registro.registro_profesional.Identificacion_Profesional);
                        if (resultados != null)
                        {
                            context_profesional.Registros_Profesional.Remove(resultados);
                            context_profesional.SaveChanges();
                        }
                        context_profesional.Registros_Profesional.Add(Registro_registro.registro_profesional);
                        context_profesional.SaveChanges();
                        Enviar_Email(correo_enviador, contrasena_correo_enviador, host_enviador, puerto_enviador, Registro_registro.registro_profesional.Correo_Electronico_Profesional, "Registro de datos de Profesional", "Se han guardado exitosamente los datos del profesional:" + Registro_registro.registro_profesional.Identificacion_Profesional);

                    }catch (Exception e) { Console.WriteLine("Exception: " + e); id = 0; }
                    break;

                case 2:
                    try
                    {
                        var resultados = context_clinica.Registros_Clinica.Find(Registro_registro.registro_clinica.Cedula_Juridica_Clinica);
                        if (resultados != null)
                        {
                            context_clinica.Registros_Clinica.Remove(resultados);
                            context_clinica.SaveChanges();
                        }
                        context_clinica.Registros_Clinica.Add(Registro_registro.registro_clinica);
                        context_clinica.SaveChanges();
                        Enviar_Email(correo_enviador, contrasena_correo_enviador, host_enviador, puerto_enviador, Registro_registro.registro_clinica.Correo_Electronico_Administracion, "Registro de datos de Clinica", "Se han guardado exitosamente los datos de la clinica:" + Registro_registro.registro_clinica.Cedula_Juridica_Clinica);

                    }
                    catch (Exception e) { Console.WriteLine("Exception: " + e); id = 1; }

                    break;
            }

            return RedirectToAction("Index", new { id = id });
            
        }
    }
}
