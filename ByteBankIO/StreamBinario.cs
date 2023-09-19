partial class Program
{
    static void EscritaBinaria()
    {
        using (var fs = new FileStream("contaCorrente.txt", FileMode.Create))
        using (var escritor = new BinaryWriter(fs))
        {
            escritor.Write(456);  //número da Agência
            escritor.Write(546544); //Número da conta
            escritor.Write(4000.50);  //Saldo
            escritor.Write("Mariana Maria");
        }
    }

    static void LeituraBinaria()
    {
        using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
        using (var leitor = new BinaryReader(fs))
        {
            var agencia = leitor.ReadInt32();
            var conta = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();
            Console.WriteLine($"{agencia}/{conta}\nSaldo: {saldo}\nTitular: {titular}");
        }
    }
}
