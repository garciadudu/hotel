var moradorScript = function () {
    return {
        init: function () {
            recarregarListagem();
            $("#cadastrar").on("click", function (event) {
                event.preventDefault();

                $("#cadastrar").modal('show');
            });

            var viewModel = createVieModel();

            $(".btn-Cadastrar").on("click", cadastrar);
            $(".btn-Editar").on("click", editar);
            $(".btn-Excluir").on("click", excluir);
        }
    }
}();


function createVieModel() {
    var viewModel = {
        Id: 0,
        Id_Familia: 0,
        Nome: '',
        QuantidadeBichosEstimacao: 0,
        Familia: '',
    };

    return viewModel;
}

function recarregarListagem() {
    $.ajax({
        type: 'get',
        url: '/Morador/ListarMorador',
        dataType: 'json',
        beforeSend: function () {
            $('.tabela').empty().append("Carregando...");
        }
    })
    .done(function (data) {
        $('.tab-content').empty().append(data);
        carregaTabela(data);
    })
}

function carregaTabela(data) {
    $('.tabela').empty();

    if (data.length > 0) {
        novaLinha = $('.tabela').append("<tr>");

        var colunaId = novaLinha.append("<td>");
        colunaId.append("Id");

        var colunaNome = novaLinha.append("<td>");
        colunaNome.append("Nome");

        var colunaIdCondominio = novaLinha.append("<td>");
        colunaIdCondominio.append("Id_Familia");

        var colunaCondominio = novaLinha.append("<td>");
        colunaCondominio.append("Familia");

        var colunaQuantidadeBichosEstimacao = novaLinha.append("<td>");
        colunaQuantidadeBichosEstimacao.append("Qtd. Bichos");

        var colunaTitulo = novaLinha.append("<td colspan='2'>");
        colunaTitulo.append("Ações");
    }


    for (var x = 0; x < data.length; x++) 
    {
        novaLinha = $('.tabela').append("<tr>");

        var colunaId = novaLinha.append("<td>");
        colunaId.append(data[x].id);

        var colunaNome = novaLinha.append("<td>");
        colunaNome.append(data[x].nome);

        var colunaIdFamilia = novaLinha.append("<td>");
        colunaIdFamilia.append(data[x].id_Familia);

        var colunaFamilia = novaLinha.append("<td>");
        colunaFamilia.append(data[x].familia);

        var colunaQuantidadeBichosEstimacao = novaLinha.append("<td>");
        colunaQuantidadeBichosEstimacao.append(data[x].quantidadeBichosEstimacao);

        var colunaEditar = novaLinha.append("<td>");
        colunaEditar.append("<button id='botaoEditar' name='editar' class='btn btn-primary botaoEditar' data-Familia='" + data[x].id + "' data-toggle='modal' data-target='#editar'>Editar</button>");

        var colunaExcluir = novaLinha.append("<td>");
        colunaEditar.append("<button id='botaoExcluir' name='excluir' class='btn btn-danger botaoExcluir' data-Familia='" + data[x].id + "' data-toggle='modal' data-target='#excluir'>Excluir</button>");
    }

    $(".botaoEditar").on("click", function (event) {
        event.preventDefault();
        $("#editar").modal('show');

        $.ajax({
            type: 'get',
            url: '/Morador/ObterMorador/' + $(this).attr("data-Familia"),
            dataType: 'json',
            beforeSend: function () {
            }
        })
            .done(function (data) {

                if (data !== null) {

                    $("#Id").val(data.id);
                    $(".editarNome").val(data.nome);
                    $("#Id_Familia").val(data.id_Familia);
                    $(".editarFamilia").val(data.familia);
                    $(".editarQuantidadeBichosEstimacao").val(data.quantidadeBichosEstimacao);

                } 
            });


    });


    $(".botaoExcluir").on("click", function (event) {
        event.preventDefault();

        $("#excluir").modal('show');

        $.ajax({
            type: 'get',
            url: '/Morador/ObterMorador/' + $(this).attr("data-Familia"),
            dataType: 'json',
            beforeSend: function () {
            }
        })
            .done(function (data) {
                if (data !== null) {
                    $("#Id").val(data.id);
                    $(".excluirNome").val(data.nome);
                    $("#Id_Familia").val(data.id_Familia);
                    $(".excluirFamilia").val(data.familia);
                    $(".excluirQuantidadeBichosEstimacao").val(data.quantidadeBichosEstimacao);
                } 
            });


    });
}


function cadastrar(event) {
    var viewModel = createVieModel();

    viewModel.Id = 0;
    viewModel.Nome = $(".cadastrarNome").val();
    viewModel.Id_Familia = parseInt($("#Id_Familia").val());
    viewModel.QuantidadeBichosEstimacao = parseInt($(".cadastrarQuantidadeBichosEstimacao").val());

    var data = JSON.stringify(viewModel);

    $.ajax({
        type: 'post',
        url: '/Morador/Cadastrar',
        data,
        contentType: 'application/json',
        beforeSend: function () {

        }
    }).done(function (data) {
        recarregarListagem();
        $("#cadastrar").modal('hide');
    });
}

function editar(event) {
    var viewModel = createVieModel();

    var id = parseInt($("#Id").val());
    viewModel.Id = isNaN(id) ? 0 : id;
    viewModel.Nome = $(".editarNome").val();
    viewModel.Id_Familia = parseInt($("#Id_Familia").val());
    viewModel.QuantidadeBichosEstimacao = parseInt($(".editarQuantidadeBichosEstimacao").val());

    var data = JSON.stringify(viewModel);

    $.ajax({
        url: '/Morador/Atualizar/',
        type: "PUT",
        data,
        contentType: 'application/json',
        success: function (data) {
            recarregarListagem();
            $("#editar").modal('hide');
        },
        error: function (data) {

        }
    });
}



function excluir(event) {
    var id = parseInt($("#Id").val());

    $.ajax({
        type: 'post',
        url: '/Morador/Remover/'+id,
        contentType: 'application/json',
        beforeSend: function () {

        }
    }).done(function (data) {
        recarregarListagem();
        $("#excluir").modal('hide');
    });
}