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

    static void ChamadaFuncoesDirecionado(int opcao) 
    {
        int aux = opcao;
        string aux1, aux2, aux3, aux4, nomeDaAresta, nomeDoVertice;
        string[] resultadoListaDeAdjacencia;

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
            Console.WriteLine("Aresta adiocionada."); 
            break;

            case 2:
            Console.WriteLine("===== REMOVER ARESTA =====");
            Console.Write("Nome da aresta");
            aux1 = Console.ReadLine();

            grafoD.RemoverAresta(aux1);
            Console.WriteLine("Aresta removida.");
            break;

            case 3:
            Console.WriteLine("===== ADICIONAR VÉRTICE =====");
            Console.Write("Nome do vértice: ");
            aux1 = Console.ReadLine();
            Console.Write("Valor do vértice: ");
            aux2 = Console.ReadLine();

            grafoD.adicionarVertice(aux1, aux2);
            Console.WriteLine("Vértice adicionado.");
            break;

            case 4:
            Console.WriteLine("===== REMOVER VÉRTICE =====");
            Console.Write("Nome do vértice: ");
            aux1 = Console.ReadLine();

            grafoD.removerVertice(aux1);
            Console.WriteLine("Vértice removido.");
            break;

            case 5:
            Console.WriteLine("==== ADJACÊNCIA ENTRE VÉRTICES =====");
            Console.Write("Nome do primeiro vértice: ");
            aux1 = Console.ReadLine();
            Console.Write("Nome do segundo vértice: ");
            aux2 = Console.ReadLine();

            Console.WriteLine($"Existe adjâcencia entre os vértices? {grafoD.adjacenciaEntreVertices(aux1, aux2)}");
            break;

            case 6:
            Console.WriteLine("==== ADJACÊNCIA ENTRE ARESTAS =====");
            Console.Write("Nome da primeira arestas: ");
            aux1 = Console.ReadLine();
            Console.Write("Nome da segunda arestas: ");
            aux2 = Console.ReadLine();

            Console.WriteLine($"Existe adjâcencia entre as arestas? {grafoD.adjacenciaEntreArestas(aux1, aux2)}");
            break;

            case 7:

            Console.WriteLine("===== CHECAGEM DA EXISTENCIA DE ARESTAS =====");
            Console.Write("Nome da aresta: ");
            nomeDaAresta = Console.ReadLine();
            if(grafoD.verificarExistenciaDaAresta(nomeDaAresta))
            {
                Console.WriteLine("A aresta " + nomeDaAresta + " existe no grafo.");
            }
            else
            {
                Console.WriteLine("A aresta " + nomeDaAresta + " não existe no grafo.");
            }
            break;

            case 8:

            Console.WriteLine("===== CHECAGEM DE QUANTIDADE DE VERTICES =====");
            int qntDeVertices = grafoD.quantidadeDeVertices();
            Console.WriteLine("Esse grafo possui " + qntDeVertices + " vértices.");
            break;

            case 9:

            Console.WriteLine("===== CHECAGEM DE QUANTIDADE DE ARESTAS =====");
            int qntDeArestas = grafoD.quantidadeDeArestas();
            Console.WriteLine("Esse grafo possui " + qntDeArestas + " arestas.");
            break;

            case 10:

            Console.WriteLine("===== CHECAGEM DE GRAFO VAZIO =====");
            if(grafoD.GrafoVazio())
            {
                Console.WriteLine("Esse grafo é um grafo vazio.");
            }
            else
            {
                Console.WriteLine("Esse grafo não é um grafo vazio.");
            }
            break;

            case 11:

            Console.WriteLine("===== CHECAGEM DE GRAFO COMPLETO =====");
            if(grafoD.GrafoCompleto())
            {
                Console.WriteLine("Esse grafo é um grafo completo.");
            }
            else
            {
                Console.WriteLine("Esse grafo não é um grafo completo.");
            }
            break;

            case 12:

            Console.WriteLine("===== CHECAGEM DE COMPONENTES FORTEMENTE CONEXOS =====");
            int nmrDeComponentes = grafoD.kosaraju();
            Console.WriteLine("O número de componentes fortemente conexos desse grafo é de " + nmrDeComponentes);
            break;

            case 13:

            Console.WriteLine("===== CHECAGEM DE PONTE =====");
            var pontes = grafoD.encontrarPontes();
            Console.WriteLine("Pontes encontradas:");
            foreach (var ponte in pontes)
            {
                Console.WriteLine($"{ponte.origem.nome} -> {ponte.destino.nome}");
            }
            break;

            case 14:

            var articulacoes = grafoD.encontrarArticulacoes();
            Console.WriteLine("===== CHECAGEM DE ARTICULAÇÕES =====");
            Console.WriteLine("Articulações encontradas:");
            foreach (var articulacao in articulacoes)
            {
                Console.WriteLine(articulacao.nome);
            }
            break;

            case 15:
            break;

            case 16:
            Console.WriteLine("===== MATRIZ DE INCIDÊNCIA =====");
            break;

            case 17:

            Console.WriteLine("===== LISTA DE ADJACÊNCIA =====");
            Console.Write("Nome do vértice: ");
            nomeDoVertice = Console.ReadLine();
            resultadoListaDeAdjacencia = grafoD.listaDeAdjacencia(grafoD.encontrarVertice(nomeDoVertice));
            for (int i = 0; i < resultadoListaDeAdjacencia.Length; i++)
            {
                Console.WriteLine(resultadoListaDeAdjacencia[i]);
            }
            break;

            case 18:

            Console.WriteLine("===== SIMPLESMENTE CONEXO =====");
            if(grafoD.simpconexo()) {
                Console.WriteLine("Esse grafo é simplesmente conexo");
            }
            else {
                Console.WriteLine("Esse grafo não é simplesmemnte conexo");
            }
            break;

            case 19:

            Console.WriteLine("===== SEMI FORTEMENTE CONEXO =====");
            if(grafoD.semifortConexo()) {
                Console.WriteLine("Esse grafo é semi fortemente conexo");
            }
            else {
                Console.WriteLine("Esse grafo não é semi fortemente conexo");
            }
            break;

            case 20:

            Console.WriteLine("===== FORTEMENTE CONEXO =====");
            if(grafoD.fortementeConexo()) {
                Console.WriteLine("Esse grafo é fortemente conexo");
            }
            else {
                Console.WriteLine("Esse grafo não é fortemente conexo");
            }
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
                ChamadaFuncoesDirecionado(aux);

                if (aux == 0)
                    break;
            }

            while (tipo == 1 && (aux < 0 || aux > 20))
            {
                aux = ExibicaoMenu();
                ChamadaFuncoesNãoDirecionado();

                if (aux == 0)
                    break;
            }
        }
    }
}