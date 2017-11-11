/*Get Data from objects in staff modal*/
function formValidation() {
    return true;
}
function getInfo() {
    if (formValidation()) {
        var img = ('#staff_file').valueOf;
        var name = ('#staffName').valueOf;
        var title = ('#staffTitle').valueOf;
        var email = ('#staffEmail').valueOf;
        var current = ('input[name=staffCurrent]:checked').value(val);

        alert("Image: {1}\nName: {2}\nTitle: {3}\nEmail: {4}\nCurrent: {5}", img, name, title, email, current);
    }
}

/*open file button click*/
//$('#staff_btn').click(function () { $('#staff_file').trigger('click');})

/*document.getElementById("#staff_btn").click(function () {
    $("#staff_file").trigger('click');
})*/

/*show image*/
/*document.getElementById('#staff_file').onchange = function (evnt) {
    var file = $("#staff_file").val();
    @{ val2 = file; }
}*/
/*document.getElementById('#staff_file').onchange = function (evnt) {
    var trgt = evnt.target || window.event.srcElement,
        files = trgt.files;

    // FileReader support
    if (FileReader && files && files.length) {
        var fr = new FileReader();
        fr.onload = function () {
            document.getElementById(outImage).src = fr.result;
        }
        fr.readAsDataURL(files[0]);
    }
}*/

/*function w3_open() {
    document.getElementById("sidebar").style.display = "block";
}
function w3_close() {
    document.getElementById("sidebar").style.display = "none";
}*/