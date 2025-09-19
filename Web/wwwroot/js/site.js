// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('.document-mask').mask('000.000.000-00');     // CPF
    $('.cellPhone-mask').mask('(00) 00000-0000');   // Celular
    $('.zipCode-mask').mask('00000-000');           // CEP
});