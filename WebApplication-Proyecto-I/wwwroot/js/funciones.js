//let valores_titulo = ["Codigo"];
//let valores_temp = ["codigo"];

let flag_columna = 0;
let array_columnas = 0;
let lista_paises = ["Afganistan?Kabul", "Albania?Tirana", "Alemania?Berlín", "Andorra?Andorra La Vella", "Angola?Luanda", "Antigua y Barbuda?Saint John’s", "Arabia Saudí?Riad", "Argelia?Argel", "Argentina?Buenos Aires", "Armenia?Erveán", "Australia?Camberra", "Austria?Viena", "Azerbaiyán?Bakú", "Bahamas?Násau", "Bangladés?Daca", "Barbados?Bridgetown", "Baréin?Manama", "Bélgica?Bruselas", "Belice?Belmopán", "Bielorrusia?Minsk", "Benín?Porto Novo", "Birmania / Myanmar?Naipyidó", "Bolivia?Sucre", "Bosnia y Herzegovina?Sarajevo", "Botsuana?Navorone", "Brasil?Brasilia", "Brunei?Bandar Seri Begawan", "Bulgaria?Sofia", "Burkina Faso?Uagadugú", "Burundi?Guitega", "Bután?Timbu", "Cabo Verde?Praia", "Camboya?Nom Pen", "Camerún?Yaundé", "Canadá?Ottawa", "Catar?Doha", "República Centroafricana?BAngui", "Chad?Yamena", "República Checa / Chequia?Praga", "Chile?Santiago de Chile", "China?Pekín", "Chipre?Nicosia", "Colombia?Bogotá", "Comoras?Moroni", "República del Congo?Brazzaville", "República Democrática del Congo?Kinsasa", "Corea del Norte?Pionyang", "Corea del Sur?Seul", "Costa de Marfil?Yamusukro", "Costa Rica?San José", "Croacia?Zagreb", "Cuba?La Habana", "Dinamarca?Copenhague", "Dominica?Roseau", "República Dominicana?Santo Domingo", "Ecuador?Quito", "Egipto?El Cairo", "El Salvador?San Salvador", "Emiratos Árabes Unidos?Abu Dabi", "Eritrea?Asmara", "Eslovaquia?Bratislava", "Eslovenia?Liubliana", "España?Madrid", "Estados Unidos?Washington D.C.", "Estonia?Tallinn", "Etiopía?Adís Abeba", "Filipinas?Manila", "Finlandia?Helsinki", "Fiyi?Suva", "Francia?París", "Gabón?Libreville", "Gambia?Banjul", "Georgia?Tiflis", "Ghana?Accra", "Granada?Saint George", "Grecia?Atenas", "Guatemala?Ciudad de Guatemala", "Guinea?Conakri", "Guinea - Bisáu?Bisáu", "Guinea Ecuatorial?Malabo", "Guyana?Georgetown", "Haití?Puerto Príncipe", "Honduras?Tegucigalpa y Comayagüela(*)", "Hungría?Budapest", "India?Nueva Delhi", "Indonesia?Yakarta", "Irak?Bagdad", "Irán?Teherán", "Irlanda?Dublín", "Islandia?Reikiavik", "Israel?Tel Aviv", "Italia?Roma", "Jamaica?Kingston", "Japón?Tokio", "Jordania?Amán", "Kazajistán?Nursultán", "Kenia?Nairobi", "Kirguistán?Biskek", "Kiribati?Tarawa", "Kuwait?Kuwait", "Laos?Vientián", "Lesoto?Maseru", "Letonia?Riga", "Líbano?Beirut", "Liberia?Monrovia", "Libia?Trípoli", "Liechtenstein?Vaduz", "Lituania?Vilna", "Luxemburgo?Luxemburgo", "Macedonia del Norte?Skopie", "Madagascar?Antananarivo", "Malasia?Kuala Lumpur", "Malaui?Lilongüe", "Maldivas?Malé", "Mali?Bamako", "Malta?La Valetta", "Marruecos?Rabat", "Islas Marshall?Majuro", "Mauricio?Port Louis", "Mauritania?Nuakchot", "México?Ciudad de México(*)", "Micronesia?Palikir", "Moldavia?Chisináu", "Mónaco?Mónaco", "Mongolia?Ulán Bator", "Montenegro?Podgorica", "Mozambique?Maputo", "Namibia?Windhoek", "Nauru?Yaren", "Nepal?Katmandú", "Nicaragua?Managua", "Níger?Niamey", "Nigeria?Abuya", "Noruega?Oslo", "Nueva Zelanda?Wellington", "Omán?Mascate", "Países Bajos?Ámsterdam", "Pakistán?Islamabad", "Palaos?Melekeok", "Palestina?Jerusalén Este / Ramala", "Panamá?Panamá", "Papúa Nueva Guinea?Puerto Moresby", "Paraguay?Asunción", "Perú?Lima", "Polonia?Varsovia", "Portugal?Lisboa", "Reino Unido?Londres", "Ruanda?Kigali", "Rumanía?Bucarest", "Rusia?Moscú", "Islas Salomón?Honiara", "Samoa?Apia", "San Cristóbal y Nieves?Basseterre", "San Marino?San Marino", "San Vicente y las Granadinas?Kingstown", "Santa Lucía?Castries", "Santo Tomé y Príncipe?Santo Tomé", "Senegal?Dakar", "Serbia?Belgrado", "Seychelles?Victoria", "Sierra Leona?Freetown", "Singapur?Singapur", "Siria?Damasco", "Somalia?Mogadiscio", "Sri Lanka?Sri Jayewardenepura y Colombo(*)", "Suazilandia?Babane y Lobamba", "Sudáfrica?Pretoria, Bloemfontein y Ciudad del Cabo", "Sudán?Jartum", "Sudán del Sur?Yuba", "Suecia?Estocolmo", "Suiza?Berna", "Surinam?Paramaribo", "Tailandia?Bangkok", "Tanzania?Dodoma", "Tayikistán?Dusambé.", "Timor Oriental?Dili", "Togo?Lomé", "Tonga?Nukualofa", "Trinidad y Tobago?Puerto España", "Túnez?Túnez", "Turkmenistán?Asjabad", "Turquía?Ankara", "Tuvalu?Fongafale", "Ucrania?Kiev", "Uganda?Kampala", "Uruguay?Montevideo", "Uzbekistán?Taskent", "Vanuatu?Port Vila", "Ciudad del Vaticano?Ciudad del Vaticano", "Venezuela?Caracas", "Vietnam?Hanói", "Yemen?Saná", "Yibuti?Yibuti", "Zambia?Lusaka", "Zimbabue?Harare"];
let event = new Event('input', { bubbles: true, cancelable: true, });

function primera_vez()
{
    
    check_Empty()
    apagar_botones()
    
    try { apagar_varios() } catch (e) { }
    try { llenar_paises() } catch (e) { }
    try { llenar_fechas() } catch (e) { }
    try { } catch (e) { }
    try { } catch (e) { }
    
    actualizar_leyenda()
}
function apagar_varios()
{
    let elemento1 = document.getElementsByClassName("input-valor border-hijo si")[0];
    if (elemento1 != null)
    {
        elemento1.disabled = true;
    }
    let elemento2 = document.getElementsByClassName("input-valor border-hijo no")[0];
    if (elemento2 != null)
    {
        elemento2.disabled = true;
    }
}

function apagar_botones()
{
    let element = document.getElementsByClassName("button-to-submit");
    if (element != null) {
        for (let flag = 0; flag < element.length; flag++) {
            element[flag].style.backgroundColor = "rgba(156, 156, 156, 0.17)";
            element[flag].disabled = true;
        }
    }
}

function llenar_paises() {
    let array_select = document.getElementsByClassName("tag-select color-select paises");

    for (let flag = 0; flag < array_select.length; flag++) {
        for (let flag2 = 0; flag2 < lista_paises.length; flag2++) {
            
            let valor = lista_paises[flag2].split("?");

            let opt = document.createElement("option");
            opt.value = valor[0];
            opt.text = valor[0];
            array_select[flag].appendChild(opt);
        }
    }
}

function llenar_fechas()
{
    const date = new Date();
    let mes = date.getMonth() + 1;
    let dato_fecha = "";
    if (mes < 10) {
        dato_fecha = date.getFullYear() + "-" + "0"+mes + "-" + date.getDate();
    } else
    {
        dato_fecha = date.getFullYear() + "-" + mes + "-" + date.getDate();
    }
   
    //alert(dato_fecha);
    document.getElementsByClassName("input-date border-hijo")[1].value = dato_fecha;
    document.getElementsByClassName("input-date-date border-hijo")[1].value = dato_fecha;
}

function check_Empty() {

    columnas_esconder()
    let array = document.getElementsByClassName("contenedor-columna");
    let array_Visible;
    for (let flag = 0; flag < array.length; flag++) {
        if (array[flag].style.display == "block")
        {
            array_Visible = array[flag];
        }
    }
    let array_inputs = array_Visible.getElementsByClassName("contenedor-datos");
    color_border(array_inputs, "1px solid #F5524C", "1px solid black")
    //alert("jere");
}

function color_border(array, colorSi, colorNo) {
    let array_inputs_select=[];
    let array_input="";
   
    let problema = false;

    if (array != null)
    {
        for (let flag = 0; flag < array.length; flag++)
        {
            array_input = array[flag].getElementsByTagName("input");
            if (array_input != null)
            {
                for (let flag2 = 0; flag2 < array_input.length; flag2++) {
                    if (array_input[flag2].type == "checkbox")
                    {
                        if (array_input[flag2].checked) {
                            //array_input[flag2].style.outline = "1px solid transparent";
                            problema = true;
                        } else
                        {
                            //array_input[flag2].style.outline = colorSi;
                        }
                    } else if (array_input[flag2].type == "email")
                    {
                        let respuesta = validarEmail(array_input[flag2].value)
                        if (respuesta == true) {
                            array_input[flag2].style.border = colorNo;
                        } else if (respuesta == false)
                        {
                            problema = true;
                            array_input[flag2].style.border = colorSi;
                        }
                    }
                    else
                    {
                        let clean = array_input[flag2].value;
                        clean = clean.replace(" ", "");
                        if (clean == "" && array_input[flag2].required) {
                            array_input[flag2].style.border = colorSi;
                            problema = true;
                        } else
                        {
                            array_input[flag2].style.border = colorNo;
                        }

                    }
                }
            }
            
            array_inputs_select = array[flag].getElementsByTagName("select");
            if (array_inputs_select != null)
            {
                for (let flag2 = 0; flag2 < array_inputs_select.length; flag2++)
                {
                    //array_inputs_select[flag2].defaultValue = array_inputs_select[flag2].value;
                    array_inputs_select[flag2].dispatchEvent(event);
                    if ((array_inputs_select[flag2].value == "" || array_inputs_select[flag2].value == "---") && array_inputs_select[flag2].required)
                    {
                        array_inputs_select[flag2].style.border = colorSi;
                        problema = true;
                    } else
                    {
                        array_inputs_select[flag2].style.border = colorNo;
                    }
                }
            }
        }
       
    }

    let element = document.getElementsByClassName("button-to-submit")[flag_columna];
    if (element != null)
    {
        if (problema == false) {
            element.style.backgroundColor = "black";
            element.disabled = false;
        }
    }
    //alert(problema);
    /*
    if (problema == true) {
        switch (flag_columna) {
            case 0:
                esconder_flecha(true, true);
                break;

            default:
                esconder_flecha(true, true);
                break;
        }
    } else {
        switch (flag_columna) {
            case 0:
                esconder_flecha(false, true);
                break;
            default:
                esconder_flecha(false, false);
                break;
        }
    }
    */
}

function show_ul_options(id_element)
{
    if (document.getElementById(id_element).getElementsByTagName("ul")[0].style.display == "block")
    {
        document.getElementById(id_element).getElementsByTagName("ul")[0].style.display = "none";
    } else {
        document.getElementById(id_element).getElementsByTagName("ul")[0].style.display = "block";
    }

}

function actualizar_leyenda()
{
    let elemento = document.getElementsByClassName("leyenda-flechas")[0];
    if (elemento != null)
    {
        let array = document.getElementsByClassName("contenedor-columna");
        for (let flag = 0; flag < array.length; flag++) {
            if (array[flag].style.display != "none") {
                let contador = array[flag].getElementsByClassName("contador_record")[0].value;
                contador = contador.split(",");
                elemento.textContent = "Paso " + contador[0] + " de " + contador[1];
                //alert("here");
                break;
            }
        }
    }
}

function columnas_esconder()
{
    array_columnas = document.getElementsByClassName("contenedor-columna");
    for (let flag = 0; flag < array_columnas.length; flag++) {
        array_columnas[flag].style.display = "none";
    }
    array_columnas[flag_columna].style.display = "block";
    /*
    let inicio = flag_columna + 1;
    let final = array_columnas.length; //+ 1;
    document.getElementsByClassName("leyenda-flechas")[0].textContent = "Paso " + inicio + " de " + final;
    */
}

function a_la_izquierda()
{
    --flag_columna;
    if (flag_columna < 0)
    {
        flag_columna = array_columnas.length-1;
    }
    check_Empty() 
    //alert("here" + flag_columna);
}

function a_la_derecha()
{
    ++flag_columna;
    if (flag_columna ==array_columnas.length) {
        flag_columna = 0;
    }
    check_Empty() 
    //alert("here2" + flag_columna);
}

function esconder_flecha(derecha, izquierda)
{
    
    let izquierda_iz = document.getElementsByClassName("contenedor-izquierda")[0];
    let derecha_de = document.getElementsByClassName("contenedor-derecha")[0];

    if (derecha_de == null)
    {
        derecha_de = document.getElementsByClassName("contenedor-derecha-apagado")[0];
    }
    if (izquierda_iz == null) {
        izquierda_iz = document.getElementsByClassName("contenedor-izquierda-apagado")[0];
    }

    if (derecha == true) {
        derecha_de.onclick = "";
        derecha_de.className = "contenedor-derecha-apagado";
    } else {
        derecha_de.onclick = function (){ a_la_derecha()};
        derecha_de.className = "contenedor-derecha";
    }

    if (izquierda == true) {
        izquierda_iz.onclick = "";
        izquierda_iz.className = "contenedor-izquierda-apagado";
    } else {
        izquierda_iz.onclick = function () { a_la_izquierda() };
        izquierda_iz.className = "contenedor-izquierda";
    }
    
    //derecha_de.disabled = true;
    //izquierda_iz.disabled = true;
    //alert("here");
}

function validarEmail(valor)
{
    var validEmail = /^\w+([.-_+]?\w+)*@\w+([.-]?\w+)*(\.\w{2,10})+$/;
    if (validEmail.test(valor))
    {
        return true;
    } else {
        return false;
    }
}

function actualizar_fecha(numero, meta, origen)
{
    document.getElementsByClassName(meta)[numero].value = document.getElementsByClassName(origen)[numero].value;
    check_Empty()
}

function llenar_provincia(number)
{
    let index = document.getElementsByClassName("tag-select color-select paises")[number].selectedIndex-1;
    let elemento = document.getElementsByClassName("tag-select color-select provincias")[number];
    let array_opciones = elemento.getElementsByTagName("option");
    for (let flag2 = 0; flag2 < array_opciones.length; flag2++)
    {
        array_opciones[flag2].remove();
    }

    let valor = lista_paises[index].split("?");
    let opt = document.createElement("option");
    opt.value = valor[1];
    opt.text = valor[1];
    elemento.appendChild(opt);
    elemento.selectedIndex = 0;
   //elemento.dispatchEvent(event);
   // let div_padre = element.parentNode;
}

function cambiar_requerido(elemento)
{
    let requerido1 = false;
    let requerido2 = false;
    switch (elemento.selectedIndex)
    {
        case 1:
            requerido1 = false;
            requerido2 = true;
            break;

        case 2:
            requerido1 = true;
            requerido2 = false;
            break;
    }

    let elemento1 = document.getElementsByClassName("input-valor border-hijo si")[0];
    let elemento2 = document.getElementsByClassName("input-valor border-hijo no")[0];
    elemento1.value = "";
    elemento2.value = "";
    elemento1.required = requerido2;
    elemento2.required = requerido1;
    elemento1.disabled = requerido1;
    elemento2.disabled = requerido2;
}