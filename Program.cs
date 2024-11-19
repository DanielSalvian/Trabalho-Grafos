using System;
using biblioteca;

class Program
{
    static void Main(string[] args)
    {

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


        int V = 5;
        
        (int, int)[] arestasAdj =
        {
                (0, 1),
                (0, 2),
                (1, 2),
                (1, 3),
                (2, 4)
        };


        MatrizdeAdj.MatrizAdj(V, arestasAdj);


        (int, int)[] arestasInc =
        {
                (0, 1),
                (0, 2),
                (1, 2),
                (1, 3),
                (2, 4)
        };


        MatrizdeInc.MatrizInc(V, arestasInc);

        GrafoNaoDirecionado grafoNaoDir = new GrafoNaoDirecionado();
        grafoNaoDir.adicionarVertice("A", "1");
        grafoNaoDir.adicionarVertice("B", "2");
        grafoNaoDir.adicionarVertice("C", "3");
        grafoNaoDir.adicionarAresta("AB", "1", grafoNaoDir.encontrarVertice("A"), grafoNaoDir.encontrarVertice("B"));
        grafoNaoDir.adicionarAresta("BC", "1", grafoNaoDir.encontrarVertice("B"), grafoNaoDir.encontrarVertice("C"));


        grafoNaoDir.CSV();


        GrafoDirecionado grafoDir = new GrafoDirecionado();
        grafoDir.adicionarVertice("A", "1");
        grafoDir.adicionarVertice("B", "2");
        grafoDir.adicionarVertice("C", "3");
        grafoDir.adicionarAresta("AB", "1", grafoDir.encontrarVertice("A"), grafoDir.encontrarVertice("B"));
        grafoDir.adicionarAresta("BC", "1", grafoDir.encontrarVertice("B"), grafoDir.encontrarVertice("C"));


        grafoDir.CSV();

      
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
