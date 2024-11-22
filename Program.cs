using System;
using biblioteca;

class Program
{

    static void T_MatrizAdj_ND()
    {
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

    }

    static void T_MatrizAdj_D()
    {
        int V = 5;

        (int, int)[] arestasAdj =
        {
            (0, 1),
            (1, 0),
            (2, 3),
            (3, 2),
            (2, 4),
            (2, 1)
        };

        MatrizdeAdj_Direcionado.MatrizAdj(V, arestasAdj);
    }

    static void T_MatrizInc_ND()
    {
        int V = 5;
        (int, int)[] arestasInc =
        {
            (0, 1),
            (1, 0),
            (2, 3),
            (3, 2),
            (2, 4),
        };


        MatrizdeInc.MatrizInc(V, arestasInc);
    }

    static void T_MatrizInc_D()
    {
        int V = 5;
        (int, int)[] arestasInc =
        {
            (0, 1),
            (1, 0),
            (2, 3),
            (3, 2),
            (2, 4),
        };

        MatrizdeInc_Direcionado.MatrizInc(V, arestasInc);
    }
    static void Main(string[] args)
    {
        T_MatrizInc_D();

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


                };


        MatrizdeInc.MatrizInc(V, arestasInc);

        GrafoNaoDirecionado grafoNaoDir = new GrafoNaoDirecionado();
        grafoNaoDir.adicionarVertice("A", "1");
        grafoNaoDir.adicionarVertice("B", "2");
        grafoNaoDir.adicionarVertice("C", "3");
        grafoNaoDir.adicionarAresta("AB", "1", grafoNaoDir.encontrarVertice("A"), grafoNaoDir.encontrarVertice("B"));
        grafoNaoDir.adicionarAresta("BC", "1", grafoNaoDir.encontrarVertice("B"), grafoNaoDir.encontrarVertice("C"));


        GrafoDirecionado grafoDir = new GrafoDirecionado();
        grafoDir.adicionarVertice("A", "1");
        grafoDir.adicionarVertice("B", "2");
        grafoDir.adicionarVertice("C", "4");
        grafoDir.adicionarAresta("AB", "1", grafoDir.encontrarVertice("A"), grafoDir.encontrarVertice("B"));
        grafoDir.adicionarAresta("BC", "1", grafoDir.encontrarVertice("B"), grafoDir.encontrarVertice("C"));



        int numVertices = 10;
        int numArestas = 9;

//teste direc com grafo aleatorio e não aleatorio
        GrafoDirecionado grafo = new GrafoDirecionado();

        List<Aresta> arestasaleat = new List<Aresta>();

        arestasaleat = grafo.gerarGrafo(numVertices, numArestas);

        grafo.CSV(arestasaleat);

//teste nao direc com grafo aleatorio e não aleatorio
         GrafoNaoDirecionado grafon = new GrafoNaoDirecionado();

        List<Aresta> arestasaleats = new List<Aresta>();

        arestasaleats = grafo.gerarGrafo(numVertices, numArestas);

        grafon.CSV(arestasaleats);



        //testeConexao();
    }


    public static void testeGrafo()
    {
        GrafoNaoDirecionado teste = new GrafoNaoDirecionado();
        Console.Clear();
        teste.adicionarVertice("VerticeA", "1");
        teste.adicionarVertice("VerticeB", "2");
        teste.adicionarVertice("VerticeC", "3");

        teste.adicionarAresta("ArestaAC", "1", teste.encontrarVertice("VerticeA"), teste.encontrarVertice("VerticeC"));
        teste.adicionarAresta("ArestaAB", "2", teste.encontrarVertice("VerticeA"), teste.encontrarVertice("VerticeB"));
        teste.adicionarAresta("ArestaAA", "2", teste.encontrarVertice("VerticeC"), teste.encontrarVertice("VerticeA"));

        Console.Clear();
        //teste.imprimirDados();

        string[] resultado = teste.listaDeAdjacencia(teste.encontrarVertice("VerticeA"));

        Console.Write(resultado[0] + "|");
        for (int i = 1; i < resultado.Length; i++)
        {
            Console.Write(resultado[i] + ", ");
        }
        Console.WriteLine("");

        GrafoDirecionado testeD = new GrafoDirecionado();
        testeD.adicionarVertice("VerticeA", "1");
        testeD.adicionarVertice("VerticeB", "2");
        testeD.adicionarVertice("VerticeC", "3");

        testeD.adicionarAresta("ArestaAC", "1", testeD.encontrarVertice("VerticeA"), testeD.encontrarVertice("VerticeC"));
        testeD.adicionarAresta("ArestaAB", "2", testeD.encontrarVertice("VerticeA"), testeD.encontrarVertice("VerticeB"));
        testeD.adicionarAresta("ArestaAA", "2", testeD.encontrarVertice("VerticeC"), testeD.encontrarVertice("VerticeA"));

        resultado = testeD.listaDeAdjacencia(testeD.encontrarVertice("VerticeA"));

        Console.Write(resultado[0] + "|");
        for (int i = 1; i < resultado.Length; i++)
        {
            Console.Write(resultado[i] + ", ");
        }
        Console.WriteLine("");
    }

    public static void testeConexao()
    {
        GrafoDirecionado grafo2 = new GrafoDirecionado();
        Vertice v3 = new Vertice("C", "3");
        Vertice v4 = new Vertice("D", "4");
        Vertice v5 = new Vertice("E", "5");
        grafo2.adicionarVertice(v3.nome, v3.valor);
        grafo2.adicionarVertice(v4.nome, v4.valor);
        grafo2.adicionarVertice(v5.nome, v5.valor);
        grafo2.adicionarAresta("Aresta3", "3", grafo2.encontrarVertice("C"), grafo2.encontrarVertice("D"));
        grafo2.adicionarAresta("Aresta4", "4", grafo2.encontrarVertice("D"), grafo2.encontrarVertice("E"));
        grafo2.adicionarAresta("Aresta5", "5", grafo2.encontrarVertice("E"), grafo2.encontrarVertice("C"));
        grafo2.imprimirDados();
        Console.WriteLine(grafo2.fortementeConexo()); // Saída esperada: true
    }
}
