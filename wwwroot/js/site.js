// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('submit','#Login', function (e){
    e.preventDefault();
    $.ajax({
        antedeenviar: function(){
            $('#Login input[type=submit]').prop('disable',true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function(data){
            
            alert("Login Exitoso");
            window.location.reload();
        },
        erro: function(xhr, status){
            alert(xhr.responseJson.Message);
        },
        despdeenviar: function(){
            $('#Login input[type=submit]').prop('disable',false);
        },
    });
});