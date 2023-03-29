function consulta_Obtener(number_menu)
{
    let array_elementos = document.getElementsByClassName("input-valor border-hijo");
    switch (number_menu)
    {
        case 0:

            var url = "/NuevaEnfermedad/ConsultaInmediataProfesional/" + "?menu=" + number_menu + "&id=" + array_elementos[0].value + "&codigo=" + array_elementos[1].value;
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

            var url = "/NuevaEnfermedad/ConsultaInmediataClinica/" + "?menu=" + number_menu + "&id=" + array_elementos[0].value + "&nombre=" + array_elementos[1].value;
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

        default:
            break;
    }
    
}
