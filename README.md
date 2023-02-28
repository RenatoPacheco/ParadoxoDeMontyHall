# Paradoxo de Monty Hall

Rodando o jogo com 5 cenários:

```shell
dotnet run ParadoxoDeMontyHall.csproj
```

Aqui, um exemplo dos resultados:

```shel
A - Escolher uma porta e não trocar mais

Total 20000 (100%)
Total de acertos 4025 (20,125%)
Total de erros 15975 (79,875%)

B - Escolher uma porta e trocar só no final

Total 20000 (100%)
Total de acertos 16046 (80,23%)
Total de erros 3954 (19,77%)

C - Escolha aleatória de portas

Total 20000 (100%)
Total de acertos 10052 (50,26%)
Total de erros 9948 (49,74%)

D - Escolher sempre uma porta que ainda não escolheu

Total 20000 (100%)
Total de acertos 9245 (46,225%)
Total de erros 10755 (53,775%)

E - Sempre escolher uma porta diferente da atual

Total 20000 (100%)
Total de acertos 12656 (63,28%)
Total de erros 7344 (36,72%)
```