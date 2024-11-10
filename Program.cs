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

        
   GrafoNaoDirecionado grafo = new GrafoNaoDirecionado();

        
        grafo.adicionarVertice("A", "1");
        grafo.adicionarVertice("B", "2");
        grafo.adicionarVertice("C", "3");
        grafo.adicionarVertice("D", "4");

      
        Vertice A = grafo.encontrarVertice("A");
        Vertice B = grafo.encontrarVertice("B");
        Vertice C = grafo.encontrarVertice("C");
        Vertice D = grafo.encontrarVertice("D");

       
        grafo.adicionarAresta("AB", "3", A, B);
        grafo.adicionarAresta("BC", "6", B, C);
        grafo.adicionarAresta("CD", "7", C, D);
         grafo.adicionarAresta("BD", "7", C, D);
       

 
        List<Aresta> pontes = grafo.ponte(grafo);

        
        Console.WriteLine("Arestas de Ponte:");
        foreach (var aresta in pontes)
        {
            Console.WriteLine($"Aresta: {aresta.nome} - Vértices: {aresta.origem.nome} - {aresta.destino.nome}");
        }
           
            

            
        GrafoDirecionado grafo = new GrafoDirecionado();

        
        List<(string nome, string valor)> vertices = new List<(string nome, string valor)>
        {
            ("A", "Vértice A"),
            ("B", "Vértice B"),
            ("C", "Vértice C")
        };

     
        List<(string nome, string valor, string origem, string destino)> arestas = new List<(string nome, string valor, string origem, string destino)>
        {
            
        };

        
        grafo.gerarGrafodirec(3, vertices, arestas);

       
        Aresta arestaBuscada = grafo.buscarAresta("A1", grafo.ultimoVerticeAdicionado);
        if (arestaBuscada != null)
        {
            Console.WriteLine($"Aresta encontrada: {arestaBuscada.nome} de {arestaBuscada.origem.nome} para {arestaBuscada.destino.nome}");
        }
        else
        {
            Console.WriteLine("Aresta não encontrada.");
        }

       
        bool adjacenteArestas = grafo.adjacenciaEntreArestas("A1", "A2");
        Console.WriteLine($"{adjacenteArestas}");

        
        bool adjacenteVertices = grafo.adjacenciaEntreVertices("A", "B");
        Console.WriteLine($"{adjacenteVertices}");

      
        bool isGrafoVazio = grafo.GrafoVazio();
        Console.WriteLine($"{isGrafoVazio}");

        
        bool isGrafoCompleto = grafo.GrafoCompleto();
        Console.WriteLine($"{isGrafoCompleto}");

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
