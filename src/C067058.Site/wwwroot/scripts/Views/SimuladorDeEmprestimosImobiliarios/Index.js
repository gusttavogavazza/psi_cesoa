/*  
 * O validation-unobtrusive estava atrapalhando a UX que eu queria dar ao site. Portanto, eu o desliguei e fiz uma validação pelo JS.
 */

function SimuladorDeEmprestimosImobiliarios_Index() {

    var meuEscopo = $('#index-container');

    var campoValor = meuEscopo.find('input#Valor');
    var campoTaxaDeJuros = meuEscopo.find('input#TaxaDeJuros');
    var campoPeriodo = meuEscopo.find('input#Periodo');

    var resultadoContainer = meuEscopo.find('div#resultado-container');

    var botaoCalcular = meuEscopo.find('button#calcular');

    $(document).ready(function () {
        atribuirAcaoAoBotaoCalcular();
        atribuirComportamentoDeRemocaoDosAvisosDeErroAoReceberFoco();
    });

    function atribuirAcaoAoBotaoCalcular() {
        botaoCalcular.off('click').on('click', function () {
            var resultadoDaValidacao = formularioEstaValido();

            if (!resultadoDaValidacao.valido) {
                resetarResultadoContainer();
                return;
            }

            var valor = campoValor.val().replace(/R\$ /g, '').replace(/\./g, '').replace(/\,/g, '.');
            var taxaDeJuros = campoTaxaDeJuros.val().replace(/%/g, '').replace(/\./g, '').replace(/\,/g, '.');
            var periodo = campoPeriodo.val();

            calcular(valor, taxaDeJuros, periodo);
        });
    }

    function formularioEstaValido() {
        /*
         * Não foi atribuído mais validações (só pode número, é valor negativo etc) 
         * porque componente Mask do JQuery já impede a entrada desses dados nos campos
         */

        var resultadoDaValidacao = { valido: true, controlesComErro: [] };

        removerAvisosDeErro();

        var resultadoDaValidacao =
            validarCampoValor(resultadoDaValidacao)
            && validarCampoTaxaDeJuros(resultadoDaValidacao)
            && validarCampoPeriodo(resultadoDaValidacao);

        if (!resultadoDaValidacao.valido) {
            exibirAvisosDeErro(resultadoDaValidacao.controlesComErro);
            resultadoDaValidacao.controlesComErro[0].controle.focus();
        }

        return resultadoDaValidacao;
    }

    function exibirAvisosDeErro(controlesComErro) {
        $(controlesComErro).each(function (indice, controleComErro) {
            var avisoDeErro = $(`<span class="aviso-de-erro">${controleComErro.mensagemDeErro}</span>`);

            avisoDeErro.insertAfter(controleComErro.controle);

            avisoDeErro.css({
                left: $(controleComErro.controle).offset().left - avisoDeErro.offset().left + 8,
                top: $(controleComErro.controle).offset().top - avisoDeErro.offset().top + 40,
            });
        });
    }

    function removerAvisosDeErro() {
        $('span.aviso-de-erro').remove();
    }

    function validarCampoValor(resposta) {
        var controle = campoValor;

        if (controle.val() == "") {
            resposta.valido = false;
            resposta.controlesComErro.push({ controle: controle, mensagemDeErro: "Campo 'Valor' é obrigatório" });
        }

        return resposta;
    }

    function validarCampoTaxaDeJuros(resposta) {
        var controle = campoTaxaDeJuros;

        if (controle.val() == "") {
            resposta.valido = false;
            resposta.controlesComErro.push({ controle: controle, mensagemDeErro: "Campo 'Taxa de juros' é obrigatório" });
        }

        return resposta;
    }

    function validarCampoPeriodo(resposta) {
        var controle = campoPeriodo;

        if (controle.val() == "") {
            resposta.valido = false;
            resposta.controlesComErro.push({ controle: controle, mensagemDeErro: "Campo 'Período' é obrigatório" });
        }

        return resposta;
    }

    function calcular(valor, taxa, periodo) {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            cache: false,
            async: true,
            url: `/simulador-de-emprestimos-imobiliarios/${valor}/${taxa}/${periodo}/resultado`,
            success: function (result) { resultadoContainer.html(result); },
            error: function (xhr, exception) { }
        });
    }

    function resetarResultadoContainer() {
        resultadoContainer.html('');
    }

    function atribuirComportamentoDeRemocaoDosAvisosDeErroAoReceberFoco() {
        $('body').on('focus', 'input', function () {
            var componenteVizinho = $(this).next();

            if (!componenteVizinho.is('span.aviso-de-erro')) return;

            setInterval(function () { componenteVizinho.fadeOut().remove(); }, 700);            
        });
    }

    return { };
}

new SimuladorDeEmprestimosImobiliarios_Index();