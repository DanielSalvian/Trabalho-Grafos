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

    static void ChamadaFuncoesDirecionado() 
    {
        int aux = 0;
        string aux1, aux2, aux3, aux4;

        switch (aux) {
            case 1:

            Console.WriteLine("===== ADICIONAR ARESTA =====");
            Console.Write("Nome da aresta: ");
            aux1 = Console.ReadLine();
            Console.Write("Valor da aresta: ");
            aux2 = Console.ReadLine();
            Console.Write("Vértice de origem: ");
            aux3 = Console.ReadLine();
            Console.Write("Vértice de destino: ");
            aux4 = Console.ReadLine();
            
            grafoD.adicionarAresta(aux1, aux2, grafoD.encontrarVertice(aux3), grafoD.encontrarVertice(aux4)); 
            break;

            case 2:

            Console.WriteLine("===== REMOVER ARESTA =====");
            Console.Write("Nome da aresta");
            aux1 = Console.ReadLine();
            Console.Write("Vértice de origem: ");
            aux3 = Console.ReadLine();

            grafoD.removerAresta(aux1, grafoD.encontrarVertice(aux3));
            break;

            case 3:
            break;

            case 4:
            break;

            case 5:
            break;

            case 6:
            break;

            case 7:
            break;

            case 8:
            break;

            case 9:
            break;

            case 10:
            break;

            case 11:
            break;

            case 12:
            break;

            case 13:
            break;

            case 14:
            break;

            case 15:
            break;

            case 16:
            break;

            case 17:
            break;

            case 18:
            break;

            case 19:
            break;

            case 20:
            break;
        
        }
    }

    static void ChamadaFuncoesNãoDirecionado() 
    {
        int aux = 0;
        switch (aux) {
            case 1: 
            string aux1, aux2, aux3, aux4;

            Console.WriteLine("Nome da aresta: ");
            aux1 = Console.ReadLine();
            Console.WriteLine("Valor da aresta: ");
            aux2 = Console.ReadLine();
            Console.WriteLine("Vértice de origem: ");
            aux3 = Console.ReadLine();
            Console.WriteLine("Vértice de destino: ");
            aux4 = Console.ReadLine();
            
            grafoND.adicionarAresta(aux1, aux2, grafoND.encontrarVertice(aux3), grafoND.encontrarVertice(aux4)); 
            break;

        }
    }

    static int ExibicaoMenu()
    {
        int aux = -1;
        Console.WriteLine("");
        Console.WriteLine("===== MANIPULAÇÃO =====");
        Console.WriteLine("1 - Criar arestas");
        Console.WriteLine("2 - Remover arestas");
        Console.WriteLine("3 - Criar vértices");
        Console.WriteLine("4 - Remover vértices");
        Console.WriteLine("5 - Checagem de adjacência entre vértices");
        Console.WriteLine("6 - Checagem de adjacência entre arestas");
        Console.WriteLine("7 - Checagem da existência entre arestas");
        Console.WriteLine("8 - Checagem da quantidade de vértices");
        Console.WriteLine("9 - Checagem da quantidade de arestas");
        Console.WriteLine("10 - Checagem de grafo vazio");
        Console.WriteLine("11 - Checagem de grafo completo");
        Console.WriteLine("12 - Checagem de quantidade de componentes fortemente conexos com Kosaraju");
        Console.WriteLine("13 - Checagem de ponte");
        Console.WriteLine("14 - Checagem de articulação");
        Console.WriteLine("15 - Matriz de adjacência");
        Console.WriteLine("16 - Matriz de incidência");
        Console.WriteLine("17 - Lista de adjacência");
        Console.WriteLine("18 - Simplesmente conexo");
        Console.WriteLine("19 - Semi-fortemente conexo");
        Console.WriteLine("20 - Fortemente conexo");
        Console.WriteLine("0 - ENCERRAR PROGRAMA");
        Console.WriteLine("");
        aux = int.Parse(Console.ReadLine());

        return aux;
    }

    public static GrafoDirecionado grafoD;
    public static GrafoNaoDirecionado grafoND;

    static void Main(string[] args)
    {
        int tipo = -1, aux = -1, aux2 = -1, aux1 = -1;
        bool teste = true;

        while (tipo > 1 || tipo < 0)
        {
            Console.WriteLine("===== BIBLIOTECA DE GRAFOS  =====");
            Console.WriteLine("===== TIPO DE GRAFO =====");
            Console.WriteLine("0 - Grafo direcionado ");
            Console.WriteLine("1 - Grafo não direcionado ");
            tipo = int.Parse(Console.ReadLine());
        }

        if (tipo == 0)
            grafoD = new GrafoDirecionado();

        else
            grafoND = new GrafoNaoDirecionado();

        while (teste)
        {
            Console.WriteLine("===== CRIAR NOVO =====");
            Console.Write("Quantidade de vértices: ");
            aux1 = int.Parse(Console.ReadLine());
            Console.Write("Quantidade de arestas: ");
            aux2 = int.Parse(Console.ReadLine());

            if (aux2 < aux1 && aux2 > 0)
                teste = false;

            else
                Console.WriteLine("Grafo inválido! O número de arestas precisa ser (vértices - 1) e não pode ser negativo.");

        }

        if (tipo == 0)
        {
            grafoD.gerarGrafo(aux1, aux2);
        }

        else
        {
            grafoND.gerarGrafo(aux1, aux2);
        }

        aux = -1;
        while (aux != 0)
        {
            while (tipo == 0 && (aux < 0 || aux > 20))
            {
                aux = ExibicaoMenu();

                if (aux == 0)
                    break;
            }

            while (tipo == 1 && (aux < 0 || aux > 20))
            {
                aux = ExibicaoMenu();

                if (aux == 0)
                    break;
            }
        }
    }
}