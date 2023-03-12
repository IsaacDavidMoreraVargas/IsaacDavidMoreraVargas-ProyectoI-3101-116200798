//let valores_titulo = ["Codigo"];
//let valores_temp = ["codigo"];
function check_Empty() {
    let array_inputs = document.getElementsByTagName("input");
    color_border(array_inputs, "1px solid #F5524C", "1px solid black")
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