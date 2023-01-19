﻿using System;
using ParadoxoDeMontyHall.Core;
using System.Collections.Generic;
using ParadoxoDeMontyHall.Core.Participantes;

namespace ParadoxoDeMontyHall
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<Cenario> cenarios = new List<Cenario>
            {
                new Cenario(new EscolhaSemTrocaPart(), "A"),
                new Cenario(new EscolhaUmETrocaSoNoFinalPart(), "B"),
                new Cenario(new EscolhaAleatoriaPart(), "C"),
                new Cenario(new EscolhaSempreDiferentePart(), "D"),
                new Cenario(new EscolhaSemRepetirAhAnteriorPart(), "E")
            };
            int quantidadeDeTentativas = 20000;
            int quantidadesDePortas = 3;
            List<Porta> portas;


            for (int i = 0; i < quantidadeDeTentativas; i++)
            {
                portas = Porta.PrepararPortas(quantidadesDePortas);

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
        }
    }
}
