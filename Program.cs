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
        GrafoDirecionado gr = new GrafoDirecionado();
        gr.adicionarVertice("A", "valorTeste");
        gr.adicionarVertice("B", "valorTeste");
        gr.adicionarVertice("C", "valorTeste");
        gr.adicionarVertice("D", "valorTeste");
        gr.adicionarVertice("E", "valorTeste");
        gr.adicionarVertice("F", "valorTeste");
        gr.adicionarVertice("G", "valorTeste");
        gr.adicionarVertice("H", "valorTeste");

        gr.adicionarAresta("AC", "valorTeste", gr.encontrarVertice("A"), gr.encontrarVertice("C"));

        gr.adicionarAresta("CE", "valorTeste", gr.encontrarVertice("C"), gr.encontrarVertice("E"));
        gr.adicionarAresta("CD", "valorTeste", gr.encontrarVertice("C"), gr.encontrarVertice("D"));
        gr.adicionarAresta("CB", "valorTeste", gr.encontrarVertice("C"), gr.encontrarVertice("B"));

        gr.adicionarAresta("EG", "valorTeste", gr.encontrarVertice("E"), gr.encontrarVertice("G"));
        gr.adicionarAresta("EF", "valorTeste", gr.encontrarVertice("E"), gr.encontrarVertice("F"));

        gr.adicionarAresta("GH", "valorTeste", gr.encontrarVertice("G"), gr.encontrarVertice("H"));
        gr.adicionarAresta("GE", "valorTeste", gr.encontrarVertice("G"), gr.encontrarVertice("E"));

        gr.adicionarAresta("HF", "valorTeste", gr.encontrarVertice("H"), gr.encontrarVertice("F"));
        gr.adicionarAresta("HG", "valorTeste", gr.encontrarVertice("H"), gr.encontrarVertice("G"));

        gr.adicionarAresta("FD", "valorTeste", gr.encontrarVertice("F"), gr.encontrarVertice("D"));

        gr.adicionarAresta("DF", "valorTeste", gr.encontrarVertice("D"), gr.encontrarVertice("F"));

        gr.adicionarAresta("BD", "valorTeste", gr.encontrarVertice("B"), gr.encontrarVertice("D"));
        gr.adicionarAresta("BA", "valorTeste", gr.encontrarVertice("B"), gr.encontrarVertice("A"));

        Console.Clear();
        // Criar os vértices
        Vertice A = new Vertice("A", "valorTeste");
        Vertice B = new Vertice("B", "valorTeste");
        Vertice C = new Vertice("C", "valorTeste");
        Vertice D = new Vertice("D", "valorTeste");
        Vertice E = new Vertice("E", "valorTeste");

        // Adicionar arestas
        A.adicionarArestaAoVertice(new Aresta("AB", "valorTeste", A, B));
        B.adicionarArestaAoVertice(new Aresta("BC", "valorTeste", B, C));
        C.adicionarArestaAoVertice(new Aresta("CA", "valorTeste", C, A)); // Forma um ciclo com A -> B -> C -> A

        D.adicionarArestaAoVertice(new Aresta("DE", "valorTeste", D, E));
        E.adicionarArestaAoVertice(new Aresta("ED", "valorTeste", E, D)); // Forma um ciclo com D -> E -> D

        // Criar a lista de vértices para o grafo
        List<Vertice> grafo = new List<Vertice> { A, B, C, D, E };
        List<Vertice> stack = gr.PrimeiraEtapaKosaraju(grafo);

        // Imprime a pilha
        Console.WriteLine("Ordem de término (Pilha):");
        foreach (var vertice in stack)
        {
            Console.WriteLine(vertice.nome);
        }


    }

    static void Main(string[] args)
    {
        T_kosaraju_D();
    }
}