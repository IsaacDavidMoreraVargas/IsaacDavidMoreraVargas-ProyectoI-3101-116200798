var color_error = "1px solid #F5524C";
var color_correcto = "1px solid black";
function check_simple() {

    let array_Visible = document.getElementsByClassName("contenedor-columna")[0];
    let array_inputs = array_Visible.getElementsByClassName("contenedor-datos");
    //color_border(array_inputs, color_error, color_correcto)
    //alert("jere");
}

function color_border(array, colorSi, colorNo) {
    let array_inputs_select = [];
    let array_input = "";

    let problema = false;

    if (array != null) {
        for (let flag = 0; flag < array.length; flag++) {
            array_input = array[flag].getElementsByTagName("input");
            if (array_input != null) {
                for (let flag2 = 0; flag2 < array_input.length; flag2++) {
                    if (array_input[flag2].type == "checkbox") {
                        if (array_input[flag2].checked) {
                            //array_input[flag2].style.outline = "1px solid transparent";
                            problema = true;
                        } else {
                            //array_input[flag2].style.outline = colorSi;
                        }
                    } else if (array_input[flag2].type == "email") {
                        let respuesta = validarEmail(array_input[flag2].value)
                        if (respuesta == true) {
                            array_input[flag2].style.border = colorNo;
                        } else if (respuesta == false) {
                            problema = true;
                            array_input[flag2].style.border = colorSi;
                        }
                    }
                    else {
                        let clean = array_input[flag2].value;
                        clean = clean.replace(" ", "");
                        if (clean == "" && array_input[flag2].required) {
                            array_input[flag2].style.border = colorSi;
                            problema = true;
                        } else {
                            array_input[flag2].style.border = colorNo;
                        }

                    }
                }
            }

            array_inputs_select = array[flag].getElementsByTagName("select");
            if (array_inputs_select != null) {
                for (let flag2 = 0; flag2 < array_inputs_select.length; flag2++) {
                    //array_inputs_select[flag2].defaultValue = array_inputs_select[flag2].value;
                    array_inputs_select[flag2].dispatchEvent(event);
                    if ((array_inputs_select[flag2].value == "" || array_inputs_select[flag2].value == "---") && array_inputs_select[flag2].required) {
                        array_inputs_select[flag2].style.border = colorSi;
                        problema = true;
                    } else {
                        array_inputs_select[flag2].style.border = colorNo;
                    }
                }
            }
        }

    }

    let element = document.getElementById("button-form");
    if (element != null) {
        if (problema == false) {
            element.style.backgroundColor = "black";
        } else if (problema == true)
        {
            element.style.backgroundColor = "rgba(156, 156, 156, 0.17)";
        }
        element.disabled = problema;
    }

    //alert("here");
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

function recortar(elemento,numero_maximo) 
{
    let valor_momentaneo = elemento.value;
    valor_momentaneo = valor_momentaneo.toString();
    //alert(valor_momentaneo.length + "-" + (numero_maximo - 1));
    
    //let valor_momentaneo = elemento.value;
    //valor_momentaneo = valor_momentaneo.toString();
    if (valor_momentaneo.length > numero_maximo)
    {
        alert(valor_momentaneo.length + "-" + (numero_maximo));
        let salvar = "";
        for (let bandera = 0; bandera < numero_maximo; bandera++)
        {
            salvar += valor_momentaneo[bandera];
        }
        elemento.value = Number(salvar);
        check_Empty()
    }
    
}