//let valores_titulo = ["Codigo"];
//let valores_temp = ["codigo"];
function check_Empty() {
    let array_inputs = document.getElementsByTagName("input");
    color_border(array_inputs, "1px solid #F5524C", "1px solid black")
    columnas_esconder()
}
function color_border(array, colorSi, colorNo) {

    var event = new Event('input', {bubbles: true,cancelable: true,});
    let problema = false;
    for (let flag = 0; flag < array.length; flag++) {

        if (array[flag].type != "submit") {
            array[flag].defaultValue = array[flag].value;
            array[flag].dispatchEvent(event);
            let clean = array[flag].value;
            clean = clean.replace(" ", "");
            if (clean == "") {
                array[flag].style.border = colorSi;
                problema = true;
            } else {
                array[flag].style.border = colorNo;
            }
        }
    }

    let element = document.getElementById("button-form");
    if (element != null)
    {
        if (problema == true) {
            element.style.backgroundColor = "rgba(156, 156, 156, 0.17)";
            element.disabled = true;
        }else if (problema == false) {
            element.style.backgroundColor = "black";
            element.disabled = false;
        }
    }
    
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
let flag_columna = 0;
let array_columnas = 0;
function columnas_esconder()
{
    array_columnas = document.getElementsByClassName("contenedor-columna");
    for (let flag = 0; flag < array_columnas.length; flag++) {
        array_columnas[flag].style.display = "none";
    }
    array_columnas[flag_columna].style.display = "block";
    let inicio = flag_columna + 1;
    let final = array_columnas.length; //+ 1;
    document.getElementsByClassName("leyenda-flechas")[0].textContent = "Paso " + inicio + " de " + final;
}

function a_la_izquierda()
{
    --flag_columna;
    if (flag_columna < 0)
    {
        flag_columna = array_columnas.length-1;
    }
    columnas_esconder()
    //alert("here" + flag_columna);
}

function a_la_derecha()
{
    ++flag_columna;
    if (flag_columna ==array_columnas.length) {
        flag_columna = 0;
    }
    columnas_esconder()
    //alert("here2" + flag_columna);
}