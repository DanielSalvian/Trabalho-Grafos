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

    static void T_kosaraju_D()
    {
        GrafoDirecionado grafo = new GrafoDirecionado();
        grafo.adicionarVertice("B", "2");
        grafo.adicionarVertice("C", "3");
        grafo.adicionarVertice("D", "4");
        grafo.adicionarVertice("A", "1");

        // Adicionando arestas
        //grafo.adicionarAresta("A1", "10", grafo.encontrarVertice("A"), grafo.encontrarVertice("B"));
        grafo.adicionarAresta("A2", "20", grafo.encontrarVertice("B"), grafo.encontrarVertice("C"));
        grafo.adicionarAresta("A3", "30", grafo.encontrarVertice("C"), grafo.encontrarVertice("D"));
        grafo.adicionarAresta("A4", "40", grafo.encontrarVertice("D"), grafo.encontrarVertice("B"));

        Console.Clear();

        Console.WriteLine("Componentes: " + grafo.kosaraju());


    }

    static void T_kosaraju_ND()
    {
        GrafoNaoDirecionado gr = new GrafoNaoDirecionado();

        gr.adicionarVertice("A", "valorTeste");
        gr.adicionarVertice("B", "valorTeste");
        gr.adicionarVertice("C", "valorTeste");

        gr.adicionarAresta("AB", "valorTeste", gr.encontrarVertice("A"), gr.encontrarVertice("B"));
        gr.adicionarAresta("BC", "valorTeste", gr.encontrarVertice("B"), gr.encontrarVertice("C"));

        Console.Clear();
        Console.WriteLine("Componentes: " + gr.kosaraju());

    }
    static void Main(string[] args)
    {
        T_kosaraju_D();
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
