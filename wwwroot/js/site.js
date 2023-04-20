// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let contrastToggle = false;
function toggleContrast(){
    contrastToggle = !contrastToggle;
    if(contrastToggle) {
        document.body.classList += " dark-theme";
        console.log(contrastToggle);
    }
    else{
        document.body.classList.remove ("dark-theme");
        console.log(contrastToggle);
    }
}
