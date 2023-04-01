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
using WebApplication_Proyecto_I.Controllers.Paciente;
using WebApplication_Proyecto_I.Controllers.Inyecciones;
using WebApplication_Proyecto_I.Controllers.Sintoma;
using WebApplication_Proyecto_I.Models;

namespace WebApplication_Proyecto_I.Controllers.NuevaEnfermedad
{
    public class NuevaEnfermedadController : Controller
    {
        List<Models.numero_unico> lista_codigos = new List<Models.numero_unico> { };
        string correo_quien_envia = "";
        string contrasena_correo_enviador = "";
        string host_enviador = "";
        int puerto_enviador = 587;

        [BindProperty]
        public Controllers.Referencia_Interna_Modelos Registro_registro { get; set; }
        DatosProfesional_Context context_profesional = new DatosProfesional_Context();
        Clinica_Context context_clinica = new Clinica_Context();
        Paciente_Context context_paciente = new Paciente_Context();
        Inyecciones_Context context_inyecciones = new Inyecciones_Context();
        Sintomas_Context context_sintomas = new Sintomas_Context();
        public IActionResult Index(int id, int cedula, int codigounico)
        {
            Console.WriteLine("INDEX--->" + codigounico);
            switch (id)
            {
                case 1:
                    TempData["numero_pantalla"] = 1;
                    TempData["contador_de_record"] = "2,5";
                    TempData["Codigo_Unico"] = codigounico;
                    break;

                case 2:
                    TempData["numero_pantalla"] = 2;
                    TempData["contador_de_record"] = "3,5";
                    TempData["Codigo_Unico"] = codigounico;
                    break;

                case 3:
                    TempData["numero_pantalla"] = 3;
                    TempData["contador_de_record"] = "4,5";
                    TempData["Cedula_Paciente"] = cedula;
                    TempData["Codigo_Unico"] = codigounico;
                    break;

                case 4:
                    TempData["numero_pantalla"] = 4;
                    TempData["contador_de_record"] = "5,5";
                    TempData["Cedula_Paciente"] = cedula;
                    TempData["Codigo_Unico"] = codigounico;
                    break;

                default:
                    TempData["numero_pantalla"] = 0;
                    TempData["contador_de_record"] = "1,5";
                    //TempData["Cedula_Paciente"] = cedula;
                    break;
            }
            return View();
        }
        public string ConsultaInmediataProfesional(int menu, int id, int codigo, int codigounico)
        {
            Console.WriteLine("Consulta--->"+ codigounico);
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
                        "'Estado_Provincia_Residencia_Profesional':'" + esqueleto.Estado_Provincia_Residencia_Profesional + "'," +
                        "'Numero_Registro_Unico':'" + esqueleto.Numero_Registro_Unico + "'" +
                        "}";
                    string_retorno = string_retorno.Replace("'", "?");
                    string_retorno = string_retorno.Replace('?', '"');
                    //TempData["Codigo_Unico"] = esqueleto.Numero_Registro_Unico;
                }
            }
            return (string_retorno);
        }
        public string ConsultaInmediataClinica(int menu, int id, string nombre, int codigounico) {

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
                        "'Nombre_Clinica':'" + esqueleto.Nombre_Clinica + "'," +
                        "'Telefono_Administracion_Clinica':'" + esqueleto.Telefono_Administracion_Clinica + "'," +
                        "'Correo_Electronico_Administracion':'" + esqueleto.Correo_Electronico_Administracion + "'," +
                        "'Pais_Clinica':'" + esqueleto.Pais_Clinica + "'," +
                        "'Estado_Provincia_Clinica':'" + esqueleto.Estado_Provincia_Clinica + "'," +
                        "'Distrito_Clinica':'" + esqueleto.Distrito_Clinica + "'," +
                        "'Sitio_Web':'" + esqueleto.Sitio_Web + "'" +
                        "}";

                    string_retorno = string_retorno.Replace("'", "?");
                    string_retorno = string_retorno.Replace('?', '"');
                    TempData["Codigo_Unico"] = codigounico;
                }
            }
            return (string_retorno);
        }
        public string ConsultaInmediataPaciente(int menu, int id, int codigounico)
        {

            //Console.WriteLine("1->:" + menu + "|" + id);

            var string_retorno = "null";
            Models.Paciente.asociar_paciente esqueleto = new Models.Paciente.asociar_paciente();
            var resultados = context_paciente.Registros_Paciente.ToList();

            if (resultados != null)
            {
                bool encontrado = false;

                foreach (Models.Paciente.asociar_paciente valor in resultados)
                {
                    //Console.WriteLine("1->:" + valor.Cedula_Juridica_Clinica +"|"+id+"|" + valor.Nombre_Clinica+"|"+ nombre+"|");
                    if (valor.Identificacion_Paciente == id)
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
                        "'Identificacion_Paciente':'" + esqueleto.Identificacion_Paciente + "'," +
                        "'Nombre_Paciente':'" + esqueleto.Nombre_Paciente + "'," +
                        "'Primer_Apellido_Paciente':'" + esqueleto.Primer_Apellido_Paciente + "'," +
                        "'Segundo_Apellido_Paciente':'" + esqueleto.Segundo_Apellido_Paciente + "'," +
                        "'Fecha_Nacimiento_Paciente':'" + esqueleto.Fecha_Nacimiento_Paciente + "'," +
                        "'Telefono_Contacto_Paciente':'" + esqueleto.Telefono_Contacto_Paciente + "'," +
                        "'Correo_Electronico_Paciente':'" + esqueleto.Correo_Electronico_Paciente + "'," +
                        "'Fecha_Registro':'" + esqueleto.Fecha_Registro + "'," +
                        "'Ocupacion_Paciente':'" + esqueleto.Ocupacion_Paciente + "'," +
                        "'Pais_Paciente':'" + esqueleto.Pais_Paciente + "'," +
                        "'Estado_Provincia_Paciente':'" + esqueleto.Estado_Provincia_Paciente + "'," +
                        "'Distrito_Paciente':'" + esqueleto.Distrito_Paciente + "'," +
                        "'Genero_Paciente':'" + esqueleto.Genero_Paciente + "'," +
                        "'Estado_Civil_Paciente':'" + esqueleto.Estado_Civil_Paciente + "'" +
                        "}";

                    string_retorno = string_retorno.Replace("'", "?");
                    string_retorno = string_retorno.Replace('?', '"');
                    TempData["Codigo_Unico"] = codigounico;
                }
            }
            return (string_retorno);
        }
        [HttpPost]
        public void Enviar_Email(string correo_quien_envia, string correo_quien_recibe, string subject, string message, string contrasena, string a_host, int puerto)
        {
            try
            {
                var senderEmail = new MailAddress(correo_quien_envia, "NAME");
                var receiverEmail = new MailAddress(correo_quien_recibe, "NAME");
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
                Console.WriteLine("Error enviando email, Razon: " + e);
            }
        }
        public IActionResult Registro_Medio(int id, int codigounico)
        {
            int cedula = 0;
            switch (id)
            {
                case 1:
                    try
                    {
                        if (codigounico == 0)
                        {
                            Models.numero_unico numero_registrar = new Models.numero_unico();
                            Registro_registro.registro_profesional.Numero_Registro_Unico = Generar_Numero_Registro();
                            numero_registrar.codigo_unico = Registro_registro.registro_profesional.Numero_Registro_Unico;
                            numero_registrar.correo_unico_profesional = Registro_registro.registro_profesional.Correo_Electronico_Profesional;
                            codigounico = Registro_registro.registro_profesional.Numero_Registro_Unico;
                            lista_codigos.Add(numero_registrar);
                        }else
                        {
                            Registro_registro.registro_profesional.Numero_Registro_Unico = codigounico;
                            foreach (Models.numero_unico numero_registrado in lista_codigos)
                            {
                                if (numero_registrado.codigo_unico == codigounico)
                                {
                                    numero_registrado.correo_unico_administracion = Registro_registro.registro_profesional.Correo_Electronico_Profesional;
                                    break;
                                }
                            }
                        }      

                        string correo_quien_recibe = Registro_registro.registro_profesional.Correo_Electronico_Profesional;
                        string subject = "Registro de datos de Profesional";
                        string message = "Se han guardado exitosamente los datos del profesional:" + Registro_registro.registro_profesional.Identificacion_Profesional+" , Codigo Unico registro: "+ codigounico;

                        var resultados = context_profesional.Registros_Profesional.Find(Registro_registro.registro_profesional.Identificacion_Profesional);
                        if (resultados != null)
                        {
                            context_profesional.Registros_Profesional.Remove(resultados);
                            context_profesional.SaveChanges();
                        }
                        context_profesional.Registros_Profesional.Add(Registro_registro.registro_profesional);
                        context_profesional.SaveChanges();

                        Enviar_Email(correo_quien_envia, correo_quien_recibe, subject, message, contrasena_correo_enviador, host_enviador, puerto_enviador);

                    }catch (Exception e) { Console.WriteLine("Exception: " + e); id = 0; }
                    break;

                case 2:
                    try
                    {
                        string correo_quien_recibe = Registro_registro.registro_clinica.Correo_Electronico_Administracion;
                        string subject = "Registro de datos de Clinica";
                        string message = "Se han guardado exitosamente los datos de la clinica:" + Registro_registro.registro_clinica.Cedula_Juridica_Clinica;

                        foreach (Models.numero_unico numero_registrado in lista_codigos)
                        {
                            if (numero_registrado.codigo_unico == codigounico)
                            {
                                numero_registrado.correo_unico_administracion= correo_quien_recibe;
                                break;
                            }
                        }

                        var resultados = context_clinica.Registros_Clinica.Find(Registro_registro.registro_clinica.Cedula_Juridica_Clinica);
                        if (resultados != null)
                        {
                            context_clinica.Registros_Clinica.Remove(resultados);
                            context_clinica.SaveChanges();
                        }
                        context_clinica.Registros_Clinica.Add(Registro_registro.registro_clinica);
                        context_clinica.SaveChanges();

                        Enviar_Email(correo_quien_envia, correo_quien_recibe, subject, message, contrasena_correo_enviador, host_enviador, puerto_enviador);

                    }catch (Exception e) { Console.WriteLine("Exception: " + e); id = 1; }
                    break;

                case 3:
                    try
                    {
                        cedula = Registro_registro.registro_paciente.Identificacion_Paciente;
                        string correo_quien_recibe = Registro_registro.registro_paciente.Correo_Electronico_Paciente;
                        string subject = "Registro de datos de Paciente";
                        string message = "Se han guardado exitosamente los datos del paciente:" + Registro_registro.registro_paciente.Identificacion_Paciente;


                        foreach (Models.numero_unico numero_registrado in lista_codigos)
                        {
                            if (numero_registrado.codigo_unico == codigounico)
                            {
                                numero_registrado.cedula_unico_paciente = Registro_registro.registro_paciente.Identificacion_Paciente;
                                numero_registrado.correo_unico_paciente = correo_quien_recibe;
                                break;
                            }
                        }

                        var resultados = context_paciente.Registros_Paciente.Find(Registro_registro.registro_paciente.Identificacion_Paciente);
                        if (resultados != null)
                        {
                            context_paciente.Registros_Paciente.Remove(resultados);
                            context_paciente.SaveChanges();
                        }
                        context_paciente.Registros_Paciente.Add(Registro_registro.registro_paciente);
                        context_paciente.SaveChanges();

                        Enviar_Email(correo_quien_envia, correo_quien_recibe, subject, message, contrasena_correo_enviador, host_enviador, puerto_enviador);

                    }catch (Exception e) { Console.WriteLine("Exception: " + e); id = 2; }
                    break;

                case 4:
                    try
                    {
                        cedula = Registro_registro.registro_inyecciones.Identificacion_Paciente;

                        var resultados = context_inyecciones.Registros_inyecciones.Find(Registro_registro.registro_inyecciones.Identificacion_Paciente);
                        if (resultados != null)
                        {
                            context_inyecciones.Registros_inyecciones.Remove(resultados);
                            context_inyecciones.SaveChanges();
                        }
                        context_inyecciones.Registros_inyecciones.Add(Registro_registro.registro_inyecciones);
                        context_inyecciones.SaveChanges();
                    }catch (Exception e) { Console.WriteLine("Exception: " + e); id = 3; }
                    break;
                case 5:
                    try
                    {
                        string correo_quien_recibe_paciente = "";
                        string correo_quien_recibe_profesional = "";
                        string subject = "Se han guardado exitosamente los datos de los sintomas, para paciente: ";
                        string message = "Se han guardado exitosamente los datos de los sintomas, para paciente:";

                        foreach (Models.numero_unico numero_registrado in lista_codigos)
                        {
                            if (numero_registrado.codigo_unico == codigounico)
                            {
                                subject += numero_registrado.cedula_unico_paciente;
                                correo_quien_recibe_paciente = numero_registrado.correo_unico_paciente;
                                correo_quien_recibe_profesional = numero_registrado.correo_unico_profesional;
                                break;
                            }
                        }

                        var resultados = context_sintomas.Registros_Sintomas.Find(Registro_registro.registro_sintomas.Identificacion_Paciente);
                        if (resultados != null)
                        {
                            context_sintomas.Registros_Sintomas.Remove(resultados);
                            context_sintomas.SaveChanges();
                        }
                        context_sintomas.Registros_Sintomas.Add(Registro_registro.registro_sintomas);
                        context_sintomas.SaveChanges();

                        Enviar_Email(correo_quien_envia, correo_quien_recibe_paciente, subject, message, contrasena_correo_enviador, host_enviador, puerto_enviador);
                        Enviar_Email(correo_quien_envia, correo_quien_recibe_profesional, subject, message, contrasena_correo_enviador, host_enviador, puerto_enviador);

                    }catch (Exception e) { Console.WriteLine("Exception: " + e); id = 4; }
                    break;
            }

            return RedirectToAction("Index", "NuevaEnfermedad", new { id = id, cedula = cedula, codigounico = codigounico });

        }
        public int Generar_Numero_Registro()
        {
            int min = 1;
            int max = 999998;
            bool salir = true;
            Random rnd = new Random();
            int numero_random = rnd.Next(min, max + 1);
            var resultados = context_profesional.Registros_Profesional.ToList();
            do
            {
                if (resultados != null)
                {
                    foreach (Models.Profesional.asociar_profesional valor in resultados)
                    {
                        if (valor.Numero_Registro_Unico == numero_random)
                        {
                            numero_random = rnd.Next(min, max + 1);
                            salir = false;
                            break;
                        }
                    }
                }
                else
                {
                    salir = true;
                }
            } while (salir == false);

            return numero_random;
        }

    }
}
