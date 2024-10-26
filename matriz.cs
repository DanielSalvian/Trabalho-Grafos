using System;
using System.Reflection.Metadata.Ecma335;

namespace biblioteca{  

public class MatrizdeAdj
{

public static void MatrizAdj(int V, (int,int)[] arestas){

  int [,] matriz = new int[V,V];

  //Cria a matriz com o vetor acima.
  for (int i = 0; i < V; i++)
    for (int j = 0; j < V; j++)
      matriz[i, j] = 0;


  //Adiciona a aresta apontando pros dois lados (do vértice a pra b e b pra a)
     foreach (var (a, b) in arestas)
        {
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

public class MatrizdeInc{
  
}

public class ListadeInc{

}

