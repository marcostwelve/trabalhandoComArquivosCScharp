using ByteBankIO;
using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente()
    {
        //Armazenado o endereço do arquivo, que está na mesma pasta do executável
        var enderecoDoArquivo = "contas.txt";
        // Utilizando o using, para tratar exceções
        // Verificando se o arquivo é nulo      (Lendo os bytes do arquivo com filestream)
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            //variável para armazenar os números de bytes
            var numeroDeBytesLidos = -1;

            var buffer = new byte[1024]; //1KB

            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                EscreverBuffer(buffer, numeroDeBytesLidos);
            }

            //Liberando o arquivo, após o uso pelo sistema.
            fluxoDoArquivo.Close();
            Console.ReadLine();
        }
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        // Decodificando os bytes em Encoding UTF
        var utf8 = new UTF8Encoding();

        
        var texto = utf8.GetString(buffer, 0, bytesLidos);

        Console.Write(texto);
        #region
        /*
        foreach(var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }
        */
        #endregion
    }
}

// public override int Read(byte[] array, int offset, int count); Como o read do fileStream funciona

//public virtual string GetString(byte[] bytes, int index, int count); Como o GetString funciona

//Partial, permite realizar divisão da classe, ou deixando a mesma classe em arquivos diferentes