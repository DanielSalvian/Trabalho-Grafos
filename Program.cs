using System;
using biblioteca;

class Program
{
    static void Main(string[] args)
    {
        int V = 4; 
        int[,] adjMatrix = new int[V, V];  

       
        MatrizdeAdj.iniciarMatriz(adjMatrix, V);

    
        MatrizdeAdj.adicionarAresta(adjMatrix, 0, 1);
        MatrizdeAdj.adicionarAresta(adjMatrix, 0, 2);
        MatrizdeAdj.adicionarAresta(adjMatrix, 1, 2);
        MatrizdeAdj.adicionarAresta(adjMatrix, 2, 2);
        MatrizdeAdj.adicionarAresta(adjMatrix, 2, 3);

      
        MatrizdeAdj.mostrarMatriz(adjMatrix, V);
    }
}
