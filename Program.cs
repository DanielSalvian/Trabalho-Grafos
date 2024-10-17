using System;
using biblioteca;

class Program
{
    static void Main(string[] args)
    {
        /*
        int V = 4; 
        int[,] adjMatrix = new int[V, V];  

       
        MatrizdeAdj.iniciarMatriz(adjMatrix, V);

    
        MatrizdeAdj.adicionarAresta(adjMatrix, 0, 1);
        MatrizdeAdj.adicionarAresta(adjMatrix, 0, 2);
        MatrizdeAdj.adicionarAresta(adjMatrix, 1, 2);
        MatrizdeAdj.adicionarAresta(adjMatrix, 2, 2);
        MatrizdeAdj.adicionarAresta(adjMatrix, 2, 3);

      
        MatrizdeAdj.mostrarMatriz(adjMatrix, V);
        */
        testeGrafo();
    }

    public static void testeGrafo()
    {
        GrafoNaoDirecionado teste = new GrafoNaoDirecionado();
        Console.Clear();
        teste.adicionarVertice("VA", "1");
        teste.adicionarVertice("VB", "2");
        teste.adicionarVertice("VC", "3");

        teste.adicionarAresta("AA", "1", teste.encontrarVertice("VA"), teste.encontrarVertice("VC"));
        teste.adicionarAresta("AB", "2", teste.encontrarVertice("VA"), teste.encontrarVertice("VB"));

        teste.imprimirDados();
    }
}
