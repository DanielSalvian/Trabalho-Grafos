using System;
using System.Reflection.Metadata.Ecma335;

namespace biblioteca
{

    public class MatrizdeAdj
    {

        public static void MatrizAdj(int V, (int, int)[] arestas)
        {

            int[,] matriz = new int[V, V];

            //Cria a matriz com o vetor acima. (array de arestas) e com a quantidade total de vértices
            for (int i = 0; i < V; i++)
                for (int j = 0; j < V; j++)
                    matriz[i, j] = 0;


            //Adiciona a aresta apontando pros dois lados (do vértice a pra b e b pra a)
            for (int i = 0; i < arestas.Length; i++)
            {
                var (a, b) = arestas[i];
                matriz[a, b] = 1;
                matriz[b, a] = 1;
            }


            //Mostra a matriz criada anteriormente com 2 for

            for (int i = 0; i < V; i++)
            {
                Console.Write($"{i}: ");
                for (int j = 0; j < V; j++)
                {
                    Console.Write($"{matriz[i, j]} ");
                }
                Console.WriteLine();
            }


        }
    }

}

public class MatrizdeInc
{
    public static void MatrizInc(int V, (int, int)[] arestas)
    {
        int qtdArestas = arestas.Length;
        int[,] matriz = new int[qtdArestas, V];
        int[] grauNo = new int[V];

        //Cria a matriz com o vetor acima. (array de arestas)
        for (int i = 0; i < qtdArestas; i++)
        {
            for (int j = 0; j < V; j++)
            {
                matriz[i, j] = 0;
            }
        }

        //Adiciona a aresta apontando pros dois lados (do vértice a pra b e b pra a)
        for (int i = 0; i < qtdArestas; i++)
        {
            var (a, b) = arestas[i];
            matriz[i, a] = 1;
            matriz[i, b] = 1;
        }

        //Mostra a matriz criada anteriormente com 2 for
        //Mostra quais arestas conectam quais vértices (cada linha é uma aresta que conecta 2 ou mais vértices)
        for (int i = 0; i < qtdArestas; i++)
        {
            for (int j = 0; j < V; j++)
            {
                Console.Write($"{matriz[i, j]} ");
            }
            Console.WriteLine();
        }

        //Mostra o grau dos vértices da matriz criada anteriormente com 2 for (por vértice)
        
        for (int i = 0; i < V; i++)
        {
            grauNo[i] = 0;
            for (int j = 0; j < qtdArestas; j++)
            {
                grauNo[i] += matriz[j, i];
            }
            Console.WriteLine($"Grau nó {i + 1}: {grauNo[i]}");
        }
    }

}

public class ListadeInc
{

}

