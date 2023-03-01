using ParadoxoDeMontyHall.Core;
using ParadoxoDeMontyHall.Core.Participantes;

List<Cenario> cenarios = new()
{
    new Cenario(new EscolhaUmETrocaSoNoFinalPart(), "A"),
    new Cenario(new EscolhaSemTrocaPart(), "B"),
    new Cenario(new EscolhaAleatoriaPart(), "C"),
    new Cenario(new EscolhaSempreDiferentePart(), "D"),
    new Cenario(new EscolhaSemRepetirAhAnteriorPart(), "E")
};
int quantidadeDeJogos = 20000;
int quantidadesDePortas = 5;
List<Porta> portas;

for (int i = 0; i < quantidadeDeJogos; i++)
{
    portas = Porta.PrepararPortas(quantidadesDePortas).ToList();

    foreach (Cenario item in cenarios)
    {
        Console.WriteLine(item.Executar(portas));
    }

    Console.WriteLine("---------------------------------------");
}

foreach (Cenario item in cenarios)
{
    Console.WriteLine(item.Analisar());
}

Console.ReadKey();