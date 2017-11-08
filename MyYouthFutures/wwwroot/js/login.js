var modal = document.getElementById('loginScn');
var btn = document.getElementById('cncl');

btn.onclick = function (event) {
        modal.style.display = 'none'
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = 'none';
    }
}

function w3_open() {
    document.getElementById("sidebar").style.display = "block";
}
function w3_close() {
    document.getElementById("sidebar").style.display = "none";
}