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

/*open file dialogue; credit: Samuel Liew, stackOverflow*/
function performClick(elemId) {
    var elem = document.getElementById(elemId);
    if (elem && document.createEvent) {
        var evt = document.createEvent("MouseEvents");
        evt.initEvent("click", true, false);
        elem.dispatchEvent(evt);
    }
}

/*function w3_open() {
    document.getElementById("sidebar").style.display = "block";
}
function w3_close() {
    document.getElementById("sidebar").style.display = "none";
}*/
