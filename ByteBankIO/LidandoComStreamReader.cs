using ByteBankIO;

partial class Program
{
    static void LidandoComStreamReader(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);
            //var linha = leitor.ReadLine(); Lendo uma linha
            //var texto = leitor.ReadToEnd(); Carregando o arquivo de uma vez (Não recomendado para arquivos grandes)
            //var numero = leitor.Read(); Lendo o byte da primeira linha

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var msg = $"Titular: {contaCorrente.Titular.Nome}, Conta número: {contaCorrente.Numero}, agência: {contaCorrente.Agencia}, saldo: {contaCorrente.Saldo}";
                Console.WriteLine(msg);
                /*
                 * EndOfStream, é o final do arquivo. Realizando esse loop do while,
                 * ele irá carregar o arquivo, enquanto não chegar ao final
                 * Mais recomendado para leitura de arquivo
                 */
            }
        }
        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(',');
        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numerocomInt = int.Parse(numero);
        var saldoComDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComInt, numerocomInt);
        resultado.Depositar(saldoComDouble);
        resultado.Titular = titular;

        return resultado;
    }
}