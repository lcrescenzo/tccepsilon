// Movimentacao

//Mudança da cor do campo quando o somatório tiver ultrapassando o total permitido.
function ValidarQuantidade(txtQuantidade, valorTranportado, valorPermitido, percentualCritico)
{
    var valorDigitado = parseFloat(txtQuantidade.value);
    var valorTotal = valorDigitado + valorTranportado;
    var percentualTransportado = (valorTotal / valorPermitido);
    if((percentualTransportado > (percentualCritico - 0.1)) && (percentualTransportado < percentualCritico))
    {
        txtQuantidade.style.backgroundColor = "#EEEE77";//Amarelo Claro
    }
    else if (percentualTransportado >= percentualCritico)// Acima do critico
    {
        txtQuantidade.style.backgroundColor = "#FFAAAA";// Vermelho claro
    }
    else
    {
        txtQuantidade.style.backgroundColor = "#FFFFFF";//Branco
    }
}

function ValidarKeyPressNumeric(inputNumeric, separador, casasDecimais)
{
    var ev = event || e;
    
    
    var caracterDigitado;
    var code = ev.keyCode || ev.which;
    caracterDigitado = String.fromCharCode(code);
 
    if(ev.ctrlKey && caracterDigitado == "v")
        return false;
    if(inputNumeric.value.indexOf(separador) != -1)
    {
        var depoisSeparador = inputNumeric.value.substring(inputNumeric.value.indexOf(separador), inputNumeric.value.length - 1);
        if((depoisSeparador.length) >= casasDecimais)
            return false;
    }
       
    var validaNumero = /\d/;
    if(!validaNumero.test(caracterDigitado))
        return (separador == caracterDigitado && inputNumeric.value.indexOf(separador) < 0);
    else
        return true;
}

function ValidarKeyPressInteger(inputNumeric, casas)
{
    var ev = event || e;
    
    
    var caracterDigitado;
    var code = ev.keyCode || ev.which;
    caracterDigitado = String.fromCharCode(code);
 
    if(ev.ctrlKey && caracterDigitado == "v")
        return false;
    
    var validaNumero = /\d/;
    if (inputNumeric.value.length > casas)
        return false;
    
    return (validaNumero.test(caracterDigitado));
}

