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
        public static List<Models.numero_unico> lista_codigos = new List<Models.numero_unico>();
        string correo_quien_envia = "";
        string contrasena_correo_enviador = "";
        string host_enviador = "";
        int puerto_enviador = 587;

        string html_Correcto_cabeza = "<div class=?contenedor-alerta correcto-alerta?><div class=?contenedor-boton-alerta?><div class=?boton-alerta correcto-mensaje? onclick=?Cerrar_Alerta(this)?>&nbsp&nbspx&nbsp&nbsp</div></div><div class=?contenedor-mensaje-alerta?><label class=?mensaje-alerta correcto-mensaje?>";
        string html_Error_cabeza = "<div class=?contenedor-alerta error-alerta?><div class=?contenedor-boton-alerta?><div class=?boton-alerta error-mensaje? onclick=?Cerrar_Alerta(this)?>&nbsp&nbspx&nbsp&nbsp</div></div> <div class=?contenedor-mensaje-alerta?><label class=?mensaje-alerta error-mensaje?>";
        string html_final = "</label></div></div>";

        [BindProperty]
        public Controllers.Referencia_Interna_Modelos Registro_registro { get; set; }
        DatosProfesional_Context context_profesional = new DatosProfesional_Context();
        Clinica_Context context_clinica = new Clinica_Context();
        Paciente_Context context_paciente = new Paciente_Context();
        Inyecciones_Context context_inyecciones = new Inyecciones_Context();
        Sintomas_Context context_sintomas = new Sintomas_Context();
        public IActionResult Index(int id, int cedula, int codigounico, bool operacion, string reporte)
        {
            string error_alerta = html_Error_cabeza + "Operacion fallida" + html_final;
            string correcto_alerta = html_Correcto_cabeza;
            string alerta = "";
            
            if (id == 1)
            {
                correcto_alerta += "Operacion exitosa<br/>Codigo unico: " + codigounico + html_final;
            }
            else{
                correcto_alerta += "Operacion exitosa" + html_final;
            }
            

            if (operacion == true)
            {
                alerta = correcto_alerta;
            }
            else if (operacion == false)
            {
                alerta = error_alerta;
            }
            alerta = alerta.Replace('?', '"');

            switch (id)
            {
                case 1:
                    TempData["numero_pantalla"] = 1;
                    TempData["contador_de_record"] = "2,6";
                    TempData["Codigo_Unico"] = codigounico;
                    TempData["Alert-Alert"] = alerta;
                    break;

                case 2:
                    TempData["numero_pantalla"] = 2;
                    TempData["contador_de_record"] = "3,6";
                    TempData["Codigo_Unico"] = codigounico;
                    TempData["Alert-Alert"] = alerta;
                    break;

                case 3:
                    TempData["numero_pantalla"] = 3;
                    TempData["contador_de_record"] = "4,6";
                    TempData["Cedula_Paciente"] = cedula;
                    TempData["Codigo_Unico"] = codigounico;
                    TempData["Alert-Alert"] = alerta;
                    break;

                case 4:
                    TempData["numero_pantalla"] = 4;
                    TempData["contador_de_record"] = "5,6";
                    TempData["Cedula_Paciente"] = cedula;
                    TempData["Codigo_Unico"] = codigounico;
                    TempData["Alert-Alert"] = alerta;
                    break;

                case 5:
                    TempData["numero_pantalla"] = 5;
                    TempData["contador_de_record"] = "6,6";
                    reporte = reporte.Replace("\n", "<br/>");
                    ViewBag.reporte = reporte;
                    break;
                    
                default:
                    TempData["numero_pantalla"] = 0;
                    TempData["contador_de_record"] = "1,6";
                    //TempData["Cedula_Paciente"] = cedula;
                    break;
            }
            return View();
        }
        public string ConsultaInmediataProfesional(int menu, int id, int codigo, int codigounico)
        {
            //Console.WriteLine("Consulta--->"+ codigounico);
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
            bool operacion = true;
            string reporte = "";
            switch (id)
            {
                case 1:

                    string correo_quien_recibe = Registro_registro.registro_profesional.Correo_Electronico_Profesional;
                    string subject = "Registro de datos de Profesional";
                    string message = "Se han guardado exitosamente los datos del profesional:" + Registro_registro.registro_profesional.Identificacion_Profesional + " , Codigo Unico registro: " + codigounico;
                    
                    try
                    {
                        if (codigounico == 0)
                        {
                            codigounico = Generar_Numero_Registro();

                            Models.numero_unico numero_registrar = new Models.numero_unico();
                            numero_registrar.codigo_unico = codigounico;
                            numero_registrar.cedula_unico_profesional = Registro_registro.registro_profesional.Identificacion_Profesional;
                            numero_registrar.correo_unico_profesional = Registro_registro.registro_profesional.Correo_Electronico_Profesional;
                            lista_codigos.Add(numero_registrar);

                            Registro_registro.registro_profesional.Numero_Registro_Unico = codigounico;
                        }
                        else
                        {
                            bool encontrado = false;

                            Registro_registro.registro_profesional.Numero_Registro_Unico = codigounico;
                            for (int bandera = 0; bandera < lista_codigos.Count; bandera++)
                            {
                                if (lista_codigos[bandera].codigo_unico == codigounico)
                                {
                                    lista_codigos[bandera].cedula_unico_profesional = Registro_registro.registro_profesional.Identificacion_Profesional;
                                    lista_codigos[bandera].correo_unico_profesional = correo_quien_recibe;
                                    encontrado = true;
                                    break;
                                }
                            }
                            if (encontrado == false)
                            {
                                Models.numero_unico numero_registrar = new Models.numero_unico();
                                numero_registrar.codigo_unico = codigounico;
                                numero_registrar.cedula_unico_profesional = Registro_registro.registro_profesional.Identificacion_Profesional;
                                numero_registrar.correo_unico_profesional = Registro_registro.registro_profesional.Correo_Electronico_Profesional;
                                lista_codigos.Add(numero_registrar);
                            }
                        }

                       
                        var resultados = context_profesional.Registros_Profesional.Find(Registro_registro.registro_profesional.Identificacion_Profesional);
                        if (resultados != null)
                        {
                            context_profesional.Registros_Profesional.Remove(resultados);
                            context_profesional.SaveChanges();
                        }
                        context_profesional.Registros_Profesional.Add(Registro_registro.registro_profesional);
                        context_profesional.SaveChanges();
                    }catch (Exception e) { Console.WriteLine("Exception en paso 1: " + e); id = 0; operacion = false; }

                    if(operacion==true)
                    {
                        Enviar_Email(correo_quien_envia, correo_quien_recibe, subject, message, contrasena_correo_enviador, host_enviador, puerto_enviador);
                    }
                    
                    break;

                case 2:

                    correo_quien_recibe = Registro_registro.registro_clinica.Correo_Electronico_Administracion;
                    subject = "Registro de datos de Clinica";
                    message = "Se han guardado exitosamente los datos de la clinica:" + Registro_registro.registro_clinica.Cedula_Juridica_Clinica;

                    try
                    {
                        //Console.WriteLine("-> "+lista_codigos.Count);
                        foreach (Models.numero_unico numero_registrado in lista_codigos)
                        {
                            if (numero_registrado.codigo_unico == codigounico)
                            {
                                numero_registrado.cedula_unico_administracion = Registro_registro.registro_clinica.Cedula_Juridica_Clinica;
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

                    }catch (Exception e) { Console.WriteLine("Exception en paso 2: " + e); id = 1; operacion = false; }
                    
                    if (operacion == true)
                    {
                        Enviar_Email(correo_quien_envia, correo_quien_recibe, subject, message, contrasena_correo_enviador, host_enviador, puerto_enviador);
                    }
                    break;

                case 3:

                    correo_quien_recibe = Registro_registro.registro_paciente.Correo_Electronico_Paciente;
                    subject = "Registro de datos de Paciente";
                    message = "Se han guardado exitosamente los datos del paciente:" + Registro_registro.registro_paciente.Identificacion_Paciente;

                    try
                    {
                        cedula = Registro_registro.registro_paciente.Identificacion_Paciente;
                       
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

                    }catch (Exception e) { Console.WriteLine("Exception en paso 3: " + e); id = 2; operacion = false; }

                    if (operacion == true)
                    {
                        Enviar_Email(correo_quien_envia, correo_quien_recibe, subject, message, contrasena_correo_enviador, host_enviador, puerto_enviador);
                    }

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
                    }catch (Exception e) { Console.WriteLine("Exception en paso 4: " + e); id = 3; operacion = false; }
                    break;

                case 5:

                    string correo_quien_recibe_paciente = "";
                    string correo_quien_recibe_profesional = "";
                    subject = "Se han guardado exitosamente los datos de los sintomas, para paciente: ";
                    message = "Se han guardado exitosamente los datos de los sintomas, para paciente:";
                    try
                    {
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
                    }catch (Exception e) { Console.WriteLine("Errror encontrando: " + e); }

                    try
                    {
                        var resultados = context_sintomas.Registros_Sintomas.Find(Registro_registro.registro_sintomas.Identificacion_Paciente);
                        if (resultados != null)
                        {
                            context_sintomas.Registros_Sintomas.Remove(resultados);
                            context_sintomas.SaveChanges();
                        }
                        context_sintomas.Registros_Sintomas.Add(Registro_registro.registro_sintomas);
                        context_sintomas.SaveChanges();
                    }
                    catch (Exception e) { Console.WriteLine("Exception en paso 5: " + e); id = 4; operacion = false; }
                        
                    if (operacion == true)
                    {
                        reporte = Generar_Reporte(codigounico);
                        Enviar_Email(correo_quien_envia, correo_quien_recibe_paciente, subject, reporte, contrasena_correo_enviador, host_enviador, puerto_enviador);
                        Enviar_Email(correo_quien_envia, correo_quien_recibe_profesional, subject, reporte, contrasena_correo_enviador, host_enviador, puerto_enviador);
                    }

                    break;
            }

            return RedirectToAction("Index", "NuevaEnfermedad", new { id = id, cedula = cedula, codigounico = codigounico, operacion = operacion, reporte= reporte });

        }

        public string Generar_Reporte(int codigounico)
        {
            Models.numero_unico encontrado = new Models.numero_unico();

            string texto= "\nInformacion general:\n";
            texto += "Codigo Unico" + ": " +codigounico + "\n";
            foreach (Models.numero_unico numero_registrado in lista_codigos)
            {
                if (numero_registrado.codigo_unico == codigounico)
                {
                    encontrado = numero_registrado;
                    break;
                }
            }

            if (encontrado != null)
            {
                //Console.WriteLine("ENCONTRADO->>>> " +encontrado.cedula_unico_profesional+" - "+ encontrado.cedula_unico_administracion + " - " + encontrado.cedula_unico_paciente);
                string[] cabezas ={"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};
                string[] cabezas_profesional = { "Identificación", "Código profesional", "Nombre completo", "Correo electrónico", "País", "Estado/Provincia"};
                var resultados_profesional = context_profesional.Registros_Profesional.Find(encontrado.cedula_unico_profesional);
                if (resultados_profesional != null)
                {
                    try{
                        texto += "\nInformacion de profesional:\n";
                        texto += cabezas_profesional[0] + ": " + resultados_profesional.Identificacion_Profesional + "\n";
                        texto += cabezas_profesional[1] + ": " + resultados_profesional.Codigo_Profesional + "\n";
                        texto += cabezas_profesional[2] + ": " + resultados_profesional.Nombre_Completo_Profesional + "\n";
                        texto += cabezas_profesional[3] + ": " + resultados_profesional.Correo_Electronico_Profesional + "\n";
                        texto += cabezas_profesional[4] + ": " + resultados_profesional.Pais_Residencia_Profesional + "\n";
                        texto += cabezas_profesional[5] + ": " + resultados_profesional.Estado_Provincia_Residencia_Profesional + "\n";
                    }
                    catch (Exception e) { Console.WriteLine("Error generando reporte profesional: " + e); }
                }
                
                string[] cabezas_clinica = { "Nombre de la clínica", "Cédula jurídica", "País", "Provincia/estado", "Distrito (opcional)", "Teléfono de la administración", "Correo de la administración", "Sitio web de la clínica"};
                var resultados_clinica = context_clinica.Registros_Clinica.Find(encontrado.cedula_unico_administracion);
                if (resultados_clinica != null)
                {
                    try{
                        texto += "\n\nInformacion de clinica:\n";
                        texto += cabezas_clinica[0] + ": " + resultados_clinica.Nombre_Clinica+ "\n";
                        texto += cabezas_clinica[1] + ": " + resultados_clinica.Cedula_Juridica_Clinica + "\n";
                        texto += cabezas_clinica[2] + ": " + resultados_clinica.Pais_Clinica + "\n";
                        texto += cabezas_clinica[3] + ": " + resultados_clinica.Estado_Provincia_Clinica + "\n";
                        if (resultados_clinica.Distrito_Clinica == "---")
                        {
                            texto += cabezas_clinica[4] + ": " + "No" + "\n";
                        }
                        else {
                            texto += cabezas_clinica[4] + ": " + resultados_clinica.Distrito_Clinica + "\n";
                        }
                    
                        texto += cabezas_clinica[5] + ": " + resultados_clinica.Telefono_Administracion_Clinica + "\n";
                        texto += cabezas_clinica[6] + ": " + resultados_clinica.Correo_Electronico_Administracion + "\n";
                        texto += cabezas_clinica[7] + ": " + resultados_clinica.Sitio_Web + "\n";
                    }
                    catch (Exception e) { Console.WriteLine("Error generando reporte clinica: " + e); }
                }

                string[] cabezas_paciente = {"Identificación", "Nombre", "Primer apellido", "Segundo apellido", "Fecha de nacimiento", "Género", "País", "Provincia/estado", "Distrito (opcional)", "Estado civil", "Teléfono", "Correo electrónico", "Fecha de registro", "Ocupación"};
                var resultados_paciente = context_paciente.Registros_Paciente.Find(encontrado.cedula_unico_paciente);
                if (resultados_paciente != null)
                {
                    try{
                        texto += "\n\nInformacion de paciente:\n";
                        texto += cabezas_paciente[0] + ": " + resultados_paciente.Identificacion_Paciente + "\n";
                        texto += cabezas_paciente[1] + ": " + resultados_paciente.Nombre_Paciente + "\n";
                        texto += cabezas_paciente[2] + ": " + resultados_paciente.Primer_Apellido_Paciente + "\n";
                        texto += cabezas_paciente[3] + ": " + resultados_paciente.Segundo_Apellido_Paciente + "\n";
                        texto += cabezas_paciente[4] + ": " + resultados_paciente.Fecha_Nacimiento_Paciente + "\n";
                        texto += cabezas_paciente[5] + ": " + resultados_paciente.Genero_Paciente + "\n";
                        texto += cabezas_paciente[6] + ": " + resultados_paciente.Pais_Paciente + "\n";
                        texto += cabezas_paciente[7] + ": " + resultados_paciente.Estado_Provincia_Paciente + "\n";
                        
                        if (resultados_paciente.Distrito_Paciente == "---")
                        {
                            texto += cabezas_paciente[8] + ": " + "No" + "\n";
                        }
                        else
                        {
                            texto += cabezas_paciente[8] + ": " + resultados_paciente.Distrito_Paciente + "\n";
                        }
                        
                        texto += cabezas_paciente[9] + ": " + resultados_paciente.Estado_Civil_Paciente + "\n";
                        texto += cabezas_paciente[10] + ": " + resultados_paciente.Telefono_Contacto_Paciente + "\n";
                        texto += cabezas_paciente[11] + ": " + resultados_paciente.Correo_Electronico_Paciente + "\n";
                        texto += cabezas_paciente[12] + ": " + resultados_paciente.Fecha_Registro + "\n";
                        texto += cabezas_paciente[13] + ": " + resultados_paciente.Ocupacion_Paciente + "\n";
                    }
                    catch (Exception e) { Console.WriteLine("Error generando reporte paciente: " + e); }
                }

                string[] cabezas_inyecciones = { "¿Tiene la vacuna de Sarampión/ rubeola/ parotiditis?", "¿Tiene la vacuna del Tétano/Hepatitis A o B/ Influenza?", "¿Tiene la vacuna del Covid y cuántas dosis tiene?", "¿En caso de no tener vacuna del Covid, debe poder digitar la razón del paciente de NO inyectarse contra Covid?"};
                var resultados_inyecciones = context_inyecciones.Registros_inyecciones.Find(encontrado.cedula_unico_paciente);
                if (resultados_inyecciones != null)
                {
                    try{
                        texto += "\n\nInformacion de vacunas:\n";
                        texto += cabezas_inyecciones[0] + ": " + resultados_inyecciones.Sarampión_Rubeola_Parotiditis + "\n";
                        texto += cabezas_inyecciones[1] + ": " + resultados_inyecciones.Tetano_Hepatitis_A_B_Influenza + "\n";
                        if (resultados_inyecciones.Cuantas_Dosis != null)
                        {
                            texto += cabezas_inyecciones[2] + ": " + resultados_inyecciones.Cuantas_Dosis + "\n";
                        }
                        else
                        {
                            texto += cabezas_inyecciones[2] + ": " + "Sin registro" + "\n";
                        }
                        if (resultados_inyecciones.Razon_Covid != null)
                        {
                            texto += cabezas_inyecciones[3] + ": " + resultados_inyecciones.Razon_Covid + "\n";
                        }
                        else
                        {
                            texto += cabezas_inyecciones[3] + ": " + "Sin registro" + "\n";
                        }
                    }catch (Exception e) { Console.WriteLine("Error generando reporte vacunas: " + e); }
                }

                string[] cabezas_sintomas = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                string[] cabezas_sintomas1= { "Visita al médico o a la consulta de otro profesional de la salud", "Visita a la sala de emergencias o al centro de atención urgente", "Hospitalización", "Hospitalización prolongada", "Enfermedad que pone en peligro la vida", "Incapacidad o daño permanente", "Paciente fallecido", "Anomalía congénita o defecto de nacimiento", "Aborto espontáneo o nacimiento sin vida", "Ninguna de las anteriores", "¿Qué síntomas presenta?" };
                string[] cabezas_sintomas2 = { "Medicamentos","Polietilenglicol", "Alimentos", "Medio ambiente", "Otros"};
                string[] cabezas_sintomas3 = { "Enfermedad de Addison", "Alergias", "Arritmias", "Fibrilación auricular", "Vasculitis autoinmune", "Parálisis de Bell (parálisis facial)", "Bronquitis", "Cáncer", "Enfermedad celíaca (intolerancia al gluten)", "Enfermedad renal crónica", "Insuficiencia cardíaca congestiva", "Enfermedad de Crohn", "TVP (coágulos de sangre)", "Diabetes", "Encefalitis (inflamación cerebral/dolores de cabeza)", "Epilepsia (convulsiones)", "Enfermedades del corazón", "Herpes tipo 1", "Herpes tipo 2", "VIH", "Hipertensión (presión arterial alta)", "Enfermedad inflamatoria intestinal", "Enfermedad renal aguda", "Enfermedad hepática", "Lupus", "Aborto espontáneo", "Esclerosis múltiple", "Miastenia gravis", "Infarto de miocardio (ataque al corazón)", "Miocarditis", "Osteoartritis", "Pericarditis", "Anemia perniciosa", "Neumonía", "Parto prematuro", "Psoriasis", "Artritis psoriásica", "Embolia pulmonar", "Artritis reumatoide", "Herpes zóster", "Síndrome de Sjogren", "Nacimiento sin vida", "Accidente cerebrovascular", "Ataques isquémicos transitorios (AIT)", "Trastorno de la tiroides", "Colitis ulcerosa", "Especifique otras condiciones", "¿Si ha desarrollado un nuevo cáncer o la reaparición de un cáncer existente, especifique el tipo de cáncer?" };
                string[] cabezas_sintomas4 = { "Síntomas de COVID o Enfermedad de COVID", "Disminución del bienestar", "Disminución del estado de salud", "Fatiga extrema", "Incapacidad para participar en actividades rutinarias", "Pérdida de energía", "Dolor inexplicable", "Debilidad", "Fiebre inexplicable", "Sensaciones corporales inexplicables", "Sudores nocturnos", "Sofocos", "Intolerancia al frío", "Intolerancia al calor", "Sensibilidad a los cambios de temperatura", "Cambio en la capacidad de caminar", "Cambio en el pensamiento", "Ya no me siento como antes", "Aumento de peso inexplicable", "Pérdida de peso inexplicable", "Sueño fragmentado", "No puedo dormir", "Insomnio"};
                var resultados_sintomas = context_sintomas.Registros_Sintomas.Find(encontrado.cedula_unico_paciente);
                if (resultados_sintomas != null)
                {
                    try{
                        //de c0 hasta c9
                        texto += "\n\nInformacion de sintomas:\n";
                        texto += cabezas_sintomas1[0] + ": "; if (resultados_sintomas.C0 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas1[1] + ": "; if (resultados_sintomas.C1 == true) { texto += "Si"; } else { texto += "No"; }texto += "\n";
                        texto += cabezas_sintomas1[2] + ": "; if (resultados_sintomas.C2 == true) { texto += "Si"; } else { texto += "No"; }texto += "\n";
                        texto += cabezas_sintomas1[3] + ": "; if (resultados_sintomas.C3 == true) { texto += "Si"; } else { texto += "No"; }texto += "\n";
                        texto += cabezas_sintomas1[4] + ": "; if (resultados_sintomas.C4 == true) { texto += "Si"; } else { texto += "No"; }texto += "\n";
                        texto += cabezas_sintomas1[5] + ": "; if (resultados_sintomas.C5 == true) { texto += "Si"; } else { texto += "No"; }texto += "\n";
                        texto += cabezas_sintomas1[6] + ": "; if (resultados_sintomas.C6 == true) { texto += "Si"; } else { texto += "No"; }texto += "\n";
                        texto += cabezas_sintomas1[7] + ": "; if (resultados_sintomas.C7 == true) { texto += "Si"; } else { texto += "No"; }texto += "\n";
                        texto += cabezas_sintomas1[8] + ": "; if (resultados_sintomas.C8 == true) { texto += "Si"; } else { texto += "No"; }texto += "\n";
                        texto += cabezas_sintomas1[9] + ": "; if (resultados_sintomas.C9 == true) { texto += "Si"; } else { texto += "No"; }texto += "\n";
                        //de t0
                        if (resultados_sintomas.T0 == null)
                        {
                            texto += cabezas_sintomas1[10] + ": " + "Sin registro" + "\n";
                        }
                        else
                        {
                            texto += cabezas_sintomas1[10] + ": " + resultados_sintomas.T0 + "\n";
                        }
                        //de c10 hasta c13
                        texto += cabezas_sintomas2[0] + ": ";if (resultados_sintomas.C10 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas2[1] + ": ";if (resultados_sintomas.C11 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas2[2] + ": ";if (resultados_sintomas.C12 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas2[3] + ": ";if (resultados_sintomas.C13 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        //de t1
                        if (resultados_sintomas.T1 == null)
                        {
                            texto += cabezas_sintomas2[4] + ": " + "Ninguno" + "\n";
                        }
                        else
                        {
                            texto += cabezas_sintomas2[4] + ": " + resultados_sintomas.T1 + "\n";
                        }
                        //de c14 hasta c36
                        texto += cabezas_sintomas4[0] + ": ";if (resultados_sintomas.C14 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[1] + ": ";if (resultados_sintomas.C15 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[2] + ": ";if (resultados_sintomas.C16 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[3] + ": ";if (resultados_sintomas.C17 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[4] + ": ";if (resultados_sintomas.C18 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[5] + ": ";if (resultados_sintomas.C19 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[6] + ": ";if (resultados_sintomas.C20 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[7] + ": ";if (resultados_sintomas.C21 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[8] + ": ";if (resultados_sintomas.C22 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[9] + ": ";if (resultados_sintomas.C23 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[10] + ": ";if (resultados_sintomas.C24 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[11] + ": ";if (resultados_sintomas.C25 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[12] + ": ";if (resultados_sintomas.C26 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[13] + ": ";if (resultados_sintomas.C27 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[14] + ": ";if (resultados_sintomas.C28 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[15] + ": ";if (resultados_sintomas.C29 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[16] + ": ";if (resultados_sintomas.C30 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[17] + ": ";if (resultados_sintomas.C31 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[18] + ": ";if (resultados_sintomas.C32 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[19] + ": ";if (resultados_sintomas.C33 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[20] + ": ";if (resultados_sintomas.C34 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[21] + ": ";if (resultados_sintomas.C35 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas4[22] + ": ";if (resultados_sintomas.C36 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        //de c37 hasta c83
                        texto += cabezas_sintomas3[0] + ": ";if (resultados_sintomas.C37 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[1] + ": ";if (resultados_sintomas.C38 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[2] + ": ";if (resultados_sintomas.C39 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[3] + ": ";if (resultados_sintomas.C40 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[4] + ": ";if (resultados_sintomas.C41 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[5] + ": ";if (resultados_sintomas.C42 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[6] + ": ";if (resultados_sintomas.C43 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[7] + ": ";if (resultados_sintomas.C44 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[8] + ": ";if (resultados_sintomas.C45 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[9] + ": ";if (resultados_sintomas.C46 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[10] + ": ";if (resultados_sintomas.C47 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[11] + ": ";if (resultados_sintomas.C48 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[12] + ": ";if (resultados_sintomas.C49 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[13] + ": ";if (resultados_sintomas.C50 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[14] + ": ";if (resultados_sintomas.C51 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[15] + ": ";if (resultados_sintomas.C52 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[16] + ": ";if (resultados_sintomas.C53 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[17] + ": ";if (resultados_sintomas.C54 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[18] + ": ";if (resultados_sintomas.C55 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[19] + ": ";if (resultados_sintomas.C56 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[20] + ": ";if (resultados_sintomas.C57 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[21] + ": ";if (resultados_sintomas.C58 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[22] + ": ";if (resultados_sintomas.C59 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[23] + ": ";if (resultados_sintomas.C60 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[24] + ": ";if (resultados_sintomas.C61 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[25] + ": ";if (resultados_sintomas.C62 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[26] + ": ";if (resultados_sintomas.C63 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[27] + ": ";if (resultados_sintomas.C64 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[28] + ": ";if (resultados_sintomas.C65 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[29] + ": ";if (resultados_sintomas.C66 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[30] + ": ";if (resultados_sintomas.C67 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[31] + ": ";if (resultados_sintomas.C68 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[32] + ": ";if (resultados_sintomas.C69 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[33] + ": ";if (resultados_sintomas.C70 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[34] + ": ";if (resultados_sintomas.C71 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[35] + ": ";if (resultados_sintomas.C72 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[36] + ": ";if (resultados_sintomas.C73 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[37] + ": ";if (resultados_sintomas.C74 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[38] + ": ";if (resultados_sintomas.C75 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[39] + ": ";if (resultados_sintomas.C76 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[40] + ": ";if (resultados_sintomas.C77 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[41] + ": ";if (resultados_sintomas.C78 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[42] + ": ";if (resultados_sintomas.C79 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[43] + ": ";if (resultados_sintomas.C80 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[44] + ": ";if (resultados_sintomas.C81 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        texto += cabezas_sintomas3[45] + ": ";if (resultados_sintomas.C82 == true) { texto += "Si"; } else { texto += "No"; }texto +="\n";
                        if (resultados_sintomas.C83 == null)
                        {
                            texto += cabezas_sintomas3[46] + ": " + "Sin registro"+ "\n";
                        }else
                        {
                            texto += cabezas_sintomas3[46] + ": " + resultados_sintomas.C83.ToString() + "\n";
                        }

                        //de t2
                        if (resultados_sintomas.T2 == null)
                        {
                            texto += cabezas_sintomas3[47] + ": " + "Sin registro" + "\n";
                        }
                        else
                        {
                            texto += cabezas_sintomas3[47] + ": " + resultados_sintomas.T2 + "\n";
                        }

                    }
                    catch (Exception e) { Console.WriteLine("Error generando reporte sintomas: " + e); }

                }
            }

            return texto;
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
