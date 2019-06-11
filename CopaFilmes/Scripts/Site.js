//Variaveis Globais
var campeao = '', vice = '';

//function que conta os checkbox selecionados
function contador(id) {

    var total = $('input[type=checkbox]:checked').length; //recebe valor de checkbox marcados

    if (total > 8) { //Se o total for maior que 8 retorna a mensagem e desmarca o checkbox marcado
        alert("Somente é permitido selecionar 8 filmes");

        $('#' + id).prop('checked', false);
    }
    else { //senao preenche o span com a quantidade
        $('#count').text(total);
    }
}

//function que verifica se o total de checkbox selecionados é 8
function verificaTotal(){

    if ($('input[type=checkbox]:checked').length != 8) { //Se quantidade for diferente de 8 exibe a mensagem e retorna false

        alert('É obrigatório selecionar 8 filmes');

        return false;
    }
    else { //senao retorna true
        return true;
    }
}

//function que atualiza a View e retorna com os ganhadores
function atualizaView() {

    if (verificaTotal()) { //Se o total de checkbox marcados é igual a 8

        //Altera o botão
        $('#btnGerar').text('Aguarde...');
        $('#btnGerar').prop('disabled', 'disabled');
        
        $.getJSON('Home/GetCampeao', $('#form1').serialize(), function (json) { //Retorna Json com os resultados e preenche as variaveis globais
            campeao = (json.Campeao + ' (' + json.CampeaoNota + ')');
            vice = (json.Vice + ' (' + json.ViceNota + ')');

            $.get("/Home/_CampeaoHead", null, function (data) { //atualiza o head da view
                $("#info").html(data);

                $.get("/Home/_CampeaoBody", null, function (view) { //atualiza o body da view
                    $("#resultado").html(view)

                    //preenche os ganhadores
                    $('#campeao').text(campeao);
                    $('#vice').text(vice);
                });

            });
        });
    }
}

//function que retorna para a View principal
function retornaInicio() {

    //altera o botão novo
    $('#btnNovo').text('Aguarde...');
    $('#btnNovo').prop('disabled', 'disabled');

    //atualiza a view principal
    $.get("/Home/Index", null, function (view) {
        $("#corpo").html(view);
    });
}