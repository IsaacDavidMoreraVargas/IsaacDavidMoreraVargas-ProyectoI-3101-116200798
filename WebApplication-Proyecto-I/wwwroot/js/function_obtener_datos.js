var color_error = "1px solid #F5524C";
var color_correcto = "1px solid black";

function consulta_Obtener(number_menu)
{
    let array_elementos = document.getElementsByClassName("input-valor border-hijo");
    switch (number_menu)
    {
        case 0:

            var url = "/NuevaEnfermedad/ConsultaInmediataProfesional/" + "?menu=" + number_menu + "&id=" + array_elementos[0].value + "&codigo=" + array_elementos[1].value + "&codigounico=" + document.getElementsByClassName("contador_codigo")[0].value;
            //alert(url);
            var request = new XMLHttpRequest();
            request.responseType = 'text';

            request.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    //console.log(this.responseText);
                    //alert(this.responseText);
                    if (this.responseText != "null") {
                        let convertido = JSON.parse(this.responseText);
                        let array_columnas = document.getElementsByClassName("contenedor-columna");
                        let columna_encontrada;
                        for (let flag = 0; flag < array_columnas.length; flag++)
                        {
                            if (array_columnas[flag].style.display == "block")
                            {
                                columna_encontrada = array_columnas[flag];
                            }
                        }
                        let array_elementos = columna_encontrada.getElementsByClassName("input-valor border-hijo");
                        array_elementos[0].value = convertido.Identificacion_Profesional;
                        array_elementos[1].value = convertido.Codigo_Profesional;
                        array_elementos[2].value = convertido.Nombre_Completo_Profesional;
                        array_elementos[3].value = convertido.Correo_Electronico_Profesional;
                        document.getElementsByTagName("form")[0].action ="/NuevaEnfermedad/Registro_Medio/1?codigounico="+convertido.Numero_Registro_Unico;
                        array_elementos = columna_encontrada.getElementsByClassName("tag-select color-select paises");
                        array_elementos[0].value = convertido.Pais_Residencia_Profesional;
                        //array_elementos = columna_encontrada.getElementsByClassName("tag-select color-select provincias");
                        //array_elementos[0].value = convertido.Estado_Provincia_Residencia_Profesional;
                        llenar_provincia(0);
                        check_Empty();
                    }
                }
            };

            request.open('GET', url, true);
            request.send();
            break;

        case 1:

            var url = "/NuevaEnfermedad/ConsultaInmediataClinica/" + "?menu=" + number_menu + "&id=" + array_elementos[0].value + "&nombre=" + array_elementos[1].value + "&codigounico=" + document.getElementsByClassName("contador_codigo")[0].value;
            //alert(url);
            var request = new XMLHttpRequest();
            request.responseType = 'text';

            request.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    
                    if (this.responseText != "null") {
                        //alert(this.responseText);
                        let convertido = JSON.parse(this.responseText);
                        let array_columnas = document.getElementsByClassName("contenedor-columna");
                        let columna_encontrada;
                        for (let flag = 0; flag < array_columnas.length; flag++) {
                            if (array_columnas[flag].style.display == "block") {
                                columna_encontrada = array_columnas[flag];
                            }
                        }
                        let array_elementos = columna_encontrada.getElementsByClassName("input-valor border-hijo");
                        array_elementos[0].value = convertido.Cedula_Juridica_Clinica;
                        array_elementos[1].value = convertido.Nombre_Clinica;
                        array_elementos[2].value = convertido.Telefono_Administracion_Clinica;
                        array_elementos[3].value = convertido.Correo_Electronico_Administracion;
                        array_elementos[4].value = convertido.Sitio_Web;
                        array_elementos = columna_encontrada.getElementsByClassName("tag-select color-select paises");
                        array_elementos[0].value = convertido.Pais_Clinica;
                        document.getElementsByClassName("tag-select color-select distrito")[0].value = convertido.Distrito_Clinica;
                        //array_elementos = columna_encontrada.getElementsByClassName("tag-select color-select provincias");
                        //array_elementos[0].value = convertido.Estado_Provincia_Residencia_Profesional;
                        llenar_provincia(0);
                        check_Empty();
                    }
                }
            };

            request.open('GET', url, true);
            request.send();
            break;

        case 2:

            var url = "/NuevaEnfermedad/ConsultaInmediataPaciente/" + "?menu=" + number_menu + "&id=" + array_elementos[0].value + "&codigounico=" + document.getElementsByClassName("contador_codigo")[0].value;
            //alert(url);
            var request = new XMLHttpRequest();
            request.responseType = 'text';

            request.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {

                    if (this.responseText != "null") {
                        //alert(this.responseText);
                        let convertido = JSON.parse(this.responseText);
                        let array_columnas = document.getElementsByClassName("contenedor-columna");
                        let columna_encontrada;
                        for (let flag = 0; flag < array_columnas.length; flag++) {
                            if (array_columnas[flag].style.display == "block") {
                                columna_encontrada = array_columnas[flag];
                            }
                        }
                        let array_elementos = columna_encontrada.getElementsByClassName("input-valor border-hijo");
                        let array_date = columna_encontrada.getElementsByClassName("input-date border-hijo");
                        let array_date_input = columna_encontrada.getElementsByClassName("input-date-date border-hijo");
                        let array_tag = columna_encontrada.getElementsByClassName("tag-select color-select");
                        
                        array_elementos[0].value = convertido.Identificacion_Paciente;
                        array_elementos[1].value = convertido.Nombre_Paciente;
                        array_elementos[2].value = convertido.Primer_Apellido_Paciente;
                        array_elementos[3].value = convertido.Segundo_Apellido_Paciente;

                        array_date[0].value = convertido.Fecha_Nacimiento_Paciente;
                        array_date_input[0].value = convertido.Fecha_Nacimiento_Paciente;

                        array_elementos[4].value = convertido.Telefono_Contacto_Paciente;
                        array_elementos[5].value = convertido.Correo_Electronico_Paciente;

                        array_date[1].value = convertido.Fecha_Registro;
                        array_date_input[1].value = convertido.Fecha_Registro;

                        array_elementos[6].value = convertido.Ocupacion_Paciente;

                        array_elementos = columna_encontrada.getElementsByClassName("tag-select color-select paises");
                        array_elementos[0].value = convertido.Pais_Paciente;
                        columna_encontrada.getElementsByClassName("tag-select color-select distrito")[0].value = convertido.Distrito_Paciente;

                        array_tag[3].value = convertido.Genero_Paciente;
                        array_tag[4].value = convertido.Estado_Civil_Paciente;
                        llenar_provincia(0);
                        check_Empty();
                    }
                }
            };

            request.open('GET', url, true);
            request.send();
            break;
        default:
            break;
    }
    
}

function checkear_si_pagina_esta_online()
{
    /*
    let elemento = document.getElementsByClassName("input-valor border-hijo Web")[0];
    var valido = /^((ftp|http|https):\/\/)?(www.)?(?!.*(ftp|http|https|www.))[a-zA-Z0-9_-]+(\.[a-zA-Z]+)+((\/)[\w#]+)*(\/\w+\?[a-zA-Z0-9_]+=\w+(&[a-zA-Z0-9_]+=\w+)*)?\/?$/gm;
    if (valido.test(elemento.value)) {
        elemento.style.border = color_correcto;
    } else {
        elemento.style.border = color_error;
    }
    */
}
