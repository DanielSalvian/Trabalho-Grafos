using System;
using biblioteca;

class Program
{
    static void Main(string[] args)
    {
        /*
        int V = 5; 
      
        var arestas = new (int, int)[] { (0, 1), (0, 2), (1, 3), (3, 4) };

        MatrizAdj(V, arestas);
        */

        // testeGrafo();

/*
           GrafoNaoDirecionado grafo = new GrafoNaoDirecionado();

       
        var vertices = new List<(string, string)>
        {
            ("A", "10"),
            ("B", "20"),
            ("C", "15")
        };

        var arestas = new List<(string, string, string, string)>
        {
            ("AB", "5", "A", "B"),
            ("BC", "7", "B", "C")
        };

       
        grafo.gerarGrafo(3, vertices, arestas);

        */
    
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

        Console.Clear();
        teste.imprimirDados();
    }
}
