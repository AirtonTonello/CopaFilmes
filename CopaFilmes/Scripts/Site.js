function contador(id) {
    
    if ($('input[type=checkbox]:checked').length > 8) {
        alert("Somente é permitido selecionar 8 filmes");

        $('#' + id).prop('checked', false);
    }
    else {
        $('#count').text(total);
    }
}

function verificaTotal(){

    if ($('input[type=checkbox]:checked').length != 8) {

        alert('É obrigatório selecionar 8 filmes');

        return false;
    }
    else {
        return true;
    }
}

function atualizaView() {

    if (verificaTotal()) {
        atualizaDivs();
        getCampeao();
    }
}

function atualizaDivs() {
    $.get("/Home/_CampeaoHead", null, function (data) {
        $("#info").html(data);
    });

    $.get("/Home/_CampeaoBody", null, function (view) {
        $("#resultado").html(view)
    });
}

function getCampeao() {

    $.getJSON('Home/GetCampeao', $('#form1').serialize(), function (json) {
        $('#campeao').text(json.Campeao + ' (' + json.CampeaoNota + ')');
        $('#vice').text(json.Vice + ' (' + json.ViceNota + ')');
    });
}

function retornaInicio() {
    $.get("/Home/Index", null, function (view) {
        $("#corpo").html(view);
    });
}