using System;

namespace biblioteca{  

public class MatrizdeAdj
{
 public static void iniciarMatriz(int [,]arr,int V) {
  int i, j;
  for (i = 0; i < V; i++)
    for (j = 0; j < V; j++)
      arr[i, j] = 0;
}
public static void adicionarAresta(int [,] arr, int i, int j) {
  arr[i, j] = 1;
  arr[j, i] = 1;
}


public static void mostrarMatriz(int [,] arr, int V) {


 for (int i = 0; i < V; i++)
        {
            Console.Write($"{i}: ");
            for (int j = 0; j < V; j++)
            {
                Console.Write($"{arr[i, j]} ");
            }
            Console.WriteLine();
        }
}
}

public class MatrizdeInc{
  
}

public class ListadeInc{

}

}