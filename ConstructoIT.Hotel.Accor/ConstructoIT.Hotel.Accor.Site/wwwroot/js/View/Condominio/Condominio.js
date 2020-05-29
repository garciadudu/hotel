var condominioScript = function () {
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
        Nome: '',
        Bairro: ''
    };

    return viewModel;
}

function recarregarListagem() {
    $.ajax({
        type: 'get',
        url: '/Condominio/Listar',
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

        var colunaBairro = novaLinha.append("<td>");
        colunaBairro.append("Bairro");

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

        var colunaBairro = novaLinha.append("<td>");
        colunaBairro.append(data[x].bairro);

        var colunaEditar = novaLinha.append("<td>");
        colunaEditar.append("<button id='botaoEditar' name='editar' class='btn btn-primary botaoEditar' data-Condominio='" + data[x].id + "' data-toggle='modal' data-target='#editar'>Editar</button>");

        var colunaExcluir = novaLinha.append("<td>");
        colunaEditar.append("<button id='botaoExcluir' name='excluir' class='btn btn-danger botaoExcluir' data-Condominio='" + data[x].id + "' data-toggle='modal' data-target='#excluir'>Excluir</button>");
    }

    $(".botaoEditar").on("click", function (event) {
        event.preventDefault();
        $("#editar").modal('show');

        $.ajax({
            type: 'get',
            url: '/Condominio/ObterId/'+$(this).attr("data-Condominio"),
            dataType: 'json',
            beforeSend: function () {
            }
        })
            .done(function (data) {

                if (data !== null) {
                    $("#Id").val(data.id);
                    $(".editarNome").val(data.nome);
                    $(".editarBairro").val(data.bairro);
                } 
            });


    });


    $(".botaoExcluir").on("click", function (event) {
        event.preventDefault();

        $("#excluir").modal('show');

        $.ajax({
            type: 'get',
            url: '/Condominio/ObterId/' + $(this).attr("data-Condominio"),
            dataType: 'json',
            beforeSend: function () {
            }
        })
            .done(function (data) {
                if (data !== null) {
                    $("#Id").val(data.id);
                    $(".excluirNome").val(data.nome);
                    $(".excluirBairro").val(data.bairro);
                } 
            });


    });
}


function cadastrar(event) {
    var viewModel = createVieModel();

    viewModel.Id = 0;
    viewModel.Nome = $(".cadastrarNome").val();
    viewModel.Bairro = $(".cadastrarBairro").val();

    var data = JSON.stringify(viewModel);

    $.ajax({
        type: 'post',
        url: '/Condominio/Cadastrar',
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
    viewModel.Bairro = $(".editarBairro").val();

    var data = JSON.stringify(viewModel);

    $.ajax({
        url: '/Condominio/Atualizar/',
        type: "PUT",
        data,
        contentType: 'application/json',
        success: function (data) {
                recarregarListagem();
                $("#editar").modal('hide');
l        },
        error: function (data) {

        }
    });
}



function excluir(event) {
    var id = parseInt($("#Id").val());

    $.ajax({
        type: 'post',
        url: '/Condominio/Remover/'+id,
        contentType: 'application/json',
        beforeSend: function () {

        }
    }).done(function (data) {
            recarregarListagem();
            $("#excluir").modal('hide');
    });
}