using System;
using biblioteca;

namespace biblioteca
{

    //Grafo não direcionado
    public class GrafoNaoDirecionado
    {
        private int numArestas;
        private int numVertices;

        public Vertice ultimoVerticeAdicionado;

        public GrafoNaoDirecionado()
        {
            numArestas = 0;
            numVertices = 0;
            ultimoVerticeAdicionado = null;
        }

        public void adicionarVertice(string _nome, string _valor)
        {
            Vertice novoVertice = new Vertice(_nome, _valor);

            if (ultimoVerticeAdicionado == null)
            {
                ultimoVerticeAdicionado = novoVertice;
            }
            else
            {
                ultimoVerticeAdicionado.proximo = novoVertice;
                novoVertice.anterior = ultimoVerticeAdicionado;
                ultimoVerticeAdicionado = novoVertice;
            }

            numVertices++;
        }

        public void adicionarAresta(string _nome, string _valor, Vertice _origem, Vertice _destino)
        {
            Aresta novaAresta = new Aresta(_nome, _valor, _origem, _destino);

            _origem.adicionarArestaAoVertice(novaAresta);

            numArestas++;
        }

        //Função para chamar a busca de um vertice a partir do nome
        public Vertice encontrarVertice(string _nome)
        {
            return buscarVertice(_nome, ultimoVerticeAdicionado);
        }

        //Função recursiva que faz a busca do vertice no grafo
        public Vertice buscarVertice(string _nome, Vertice vertice)
        {

            if (vertice.nome == _nome)
            {
                return vertice;
            }
            if (vertice.anterior != null)
            {
                return buscarVertice(_nome, vertice.anterior);
            }
            else
            {
                return null;
            }

        }

        //Busca uma Aresta pelo nome e a partir de uma aresta
        public Aresta buscarAresta(string _nome, Aresta aresta)
        {
            if (aresta.nome == _nome)
            {
                return aresta;
            }
            if (aresta.anterior != null)
            {
                return buscarAresta(_nome, aresta.anterior);
            }
            else
            {
                return null;
            }
        }

        //Busca uma Aresta pelo nome e em todos os vertices
        public Aresta buscarAresta(string _nome, Vertice _ultimoVerticeAdicionado)
        {
            Aresta retorno = null;
            Vertice emAnalise = _ultimoVerticeAdicionado;

            while (emAnalise != null && retorno == null)
            {
                if (emAnalise.arestas != null)
                {
                    retorno = buscarAresta(_nome, emAnalise.arestas);
                }

                if (emAnalise.anterior != null)
                {
                    emAnalise = emAnalise.anterior;
                }
                else
                {
                    break;
                }
            }
            return retorno;
        }

        public void removerVertice(string _nome)
        {
            Vertice alvo = buscarVertice(_nome, ultimoVerticeAdicionado);
            if (alvo != null)
            {
                while (alvo.arestas != null)
                {
                    //Console.WriteLine("removido " + alvo.arestas.nome);
                    removerAresta(alvo.arestas.nome, alvo);
                }

                if (alvo.proximo != null)
                {
                    alvo.proximo.anterior = alvo.anterior;
                }
                if (alvo.anterior != null)
                {
                    alvo.anterior.proximo = alvo.proximo;
                }
                if (alvo.anterior == null && alvo.proximo == null)
                {
                    ultimoVerticeAdicionado = null;
                }

                alvo.proximo = null;
                alvo.anterior = null;

                numVertices--;
            }
        }

        public void removerAresta(string _nome, Vertice _origem)
        {
            if (_origem.arestas != null)
            {
                Aresta alvo = buscarAresta(_nome, _origem.arestas);

                if (alvo != null)
                {
                    if (alvo.proxima != null)
                    {
                        alvo.proxima.anterior = alvo.anterior;
                    }
                    if (alvo.anterior != null)
                    {
                        alvo.anterior.proxima = alvo.proxima;
                    }
                    if (alvo.anterior == null && alvo.proxima == null)
                    {
                        _origem.arestas = null;
                    }
                    if (_origem.arestas == alvo)
                    {
                        if (alvo.anterior != null)
                        {
                            _origem.arestas = alvo.anterior;
                        }
                        else
                        {
                            _origem.arestas = null;
                        }
                    }
                    alvo.anterior = null;
                    alvo.proxima = null;

                    if (alvo.proximoNoDestino != null)
                    {
                        alvo.proximoNoDestino.anteriorNoDestino = alvo.anteriorNoDestino;
                    }
                    if (alvo.anteriorNoDestino != null)
                    {
                        alvo.anteriorNoDestino.proximoNoDestino = alvo.proximoNoDestino;
                    }
                    if (alvo.anteriorNoDestino == null && alvo.proximoNoDestino == null)
                    {
                        alvo.destino.arestasQueChegam = null;
                    }
                    if (alvo.destino.arestasQueChegam == alvo)
                    {
                        if (alvo.anteriorNoDestino != null)
                        {
                            alvo.destino.arestasQueChegam = alvo.anteriorNoDestino;
                        }
                        else
                        {
                            alvo.destino.arestasQueChegam = null;
                        }
                    }
                    alvo.anteriorNoDestino = null;
                    alvo.proximoNoDestino = null;

                    numArestas--;
                }

            }


        }


        //Faz a verificação do A para o B e do B para o A também (A: origem B:Destino)
        public bool adjacenciaEntreVertices(string nomeVerticeA, string nomeVerticeB)
        {
            Vertice origem = buscarVertice(nomeVerticeA, ultimoVerticeAdicionado);
            Vertice destino = buscarVertice(nomeVerticeB, ultimoVerticeAdicionado);

            if (origem != null && destino != null)
            {

                Aresta arestaEmAnalise = origem.arestas;
                Aresta referenciaDestino = destino.arestas;

                while (arestaEmAnalise != null)
                {
                    if ((arestaEmAnalise.origem.nome == nomeVerticeA || arestaEmAnalise.origem.nome == nomeVerticeB) && (arestaEmAnalise.destino.nome == nomeVerticeA || arestaEmAnalise.destino.nome == nomeVerticeB))
                    {
                        return true;
                    }

                    arestaEmAnalise = arestaEmAnalise.anterior;
                }

                while (referenciaDestino != null)
                {
                    if ((referenciaDestino.origem.nome == nomeVerticeA || referenciaDestino.origem.nome == nomeVerticeB) && (referenciaDestino.destino.nome == nomeVerticeA || referenciaDestino.destino.nome == nomeVerticeB))
                    {
                        return true;
                    }
                    referenciaDestino = referenciaDestino.anterior;
                }

                return false;
            }


            return false;
        }

        public bool adjacenciaEntreArestas(string nomeArestaA, string nomeArestaB)
        {
            Aresta arestaA = buscarAresta(nomeArestaA, ultimoVerticeAdicionado);
            Aresta arestaB = buscarAresta(nomeArestaB, ultimoVerticeAdicionado);

            if (arestaA != null && arestaB != null)
            {
                if (arestaA.origem == arestaB.origem || arestaA.origem == arestaB.destino)
                {
                    return true;
                }
                else if (arestaA.destino == arestaB.origem || arestaA.destino == arestaB.destino)
                {
                    return true;
                }
            }

            return false;
        }

        //Retorna a lista de adjacencia de um vertice especifico
        public ListaAdjacenciaVertice listaDeAdjacencia(Vertice verticeRaizDaLista)
        {
            ListaAdjacenciaVertice lista = new ListaAdjacenciaVertice(verticeRaizDaLista);

            if (verticeRaizDaLista.arestas != null)
            {
                Aresta arestaAtual = verticeRaizDaLista.arestas;
                while (arestaAtual != null)
                {
                    lista.adicionarVertice(arestaAtual.destino);
                    arestaAtual = arestaAtual.proxima;
                }
            }

            return lista;
        }

        //Quantidade de vertices do grafo
        public int quantidadeDeVertices()
        {
            return this.numVertices;
        }

        //Quantidade de arestas do grafo (falta direcionado)
        public int quantidadeDeArestas()
        {
            int count = 0;

            if (this.ultimoVerticeAdicionado != null)
            {
                Vertice vertice = ultimoVerticeAdicionado;
                do
                {
                    Aresta arestaAtual = vertice.arestas;

                    while (arestaAtual != null)
                    {
                        count++;
                        arestaAtual = arestaAtual.proxima;
                    }

                    vertice = vertice.proximo;
                }
                while (vertice.proximo != null);

            }

            return count;
        }

        public bool estaVazio()
        {
            return ultimoVerticeAdicionado == null;
        }

        //Verificação de completo, olhando desde o último vértice até o primeiro, se passar a adjacencia por todos, retorna true
        public bool completo()
        {


            if (numVertices < 2)
            {
                return false;
            }

            Vertice VerticeAtual = ultimoVerticeAdicionado;

            while (VerticeAtual != null)
            {

                Vertice verticeComparacao = VerticeAtual.anterior;

                while (verticeComparacao != null)
                {

                    if (!adjacenciaEntreVertices(VerticeAtual.nome, verticeComparacao.nome))
                    {

                        return false;
                    }
                    verticeComparacao = verticeComparacao.anterior;
                }
                VerticeAtual = VerticeAtual.anterior;
            }

            return true;

        }

        // A partir do último vértice, realiza a busca em profundidade, se o num de vértices for o mesmo número de visitados, é porque passou por todos
        public bool simpconexo()
        {
            if (numVertices <= 1)
            {
                return true;
            }
            List<Vertice> visitados = new List<Vertice>();
            Vertice verticeInicial = ultimoVerticeAdicionado;

            buscaEmProfundidade(verticeInicial, visitados);

            // O grafo é conexo se for igual o numero
            return visitados.Count == numVertices;
        }

        // Realiza busca em profundidade e marca os vértices visitados
        private void buscaEmProfundidade(Vertice vertice, List<Vertice> visitados)
        {
            if (vertice == null || visitados.Contains(vertice))
            {
                return;
            }


            visitados.Add(vertice);

            Aresta arestaAtual = vertice.arestas;
            while (arestaAtual != null)
            {
                buscaEmProfundidade(arestaAtual.destino, visitados);
                arestaAtual = arestaAtual.proxima;
            }
        }
        // Faz a busca em profundidade vendo se é possível ter um caminho de A para B, a partir do último vértice, após isso realiza do B para o A. Fazendo isso para todo par de vértices no grafo
        public bool semifortConexo()
        {

            Vertice verticeA = ultimoVerticeAdicionado;

            while (verticeA != null)
            {
                Vertice verticeB = verticeA.anterior;

                while (verticeB != null)
                {
                    List<Vertice> AB = new List<Vertice>();
                    buscaEmProfundidade(verticeA, AB);
                    bool caminhoAB = AB.Contains(verticeB);

                    List<Vertice> BA = new List<Vertice>();
                    buscaEmProfundidade(verticeB, BA);
                    bool caminhoBA = BA.Contains(verticeA);

                    if (!caminhoAB || !caminhoBA)
                    {
                        return false;
                    }

                    verticeB = verticeB.anterior;
                }

                verticeA = verticeA.anterior;
            }

            return true;
        }

        // A partir do último vértice adicionado, realiza a busca em profundidade, se não forem alcançáveis retorna false, e ve se todos os vértices alcançam todos os vértices, se não for, retorna false
        public bool fortementConexo()
        {
            if (numVertices == 0)
            {
                return true;
            }


            Vertice verticeInicial = ultimoVerticeAdicionado;


            List<Vertice> visitados = new List<Vertice>();
            buscaEmProfundidade(verticeInicial, visitados);


            if (visitados.Count != numVertices)
            {
                return false;
            }


            Vertice verticeAtual = ultimoVerticeAdicionado;
            while (verticeAtual != null)
            {
                List<Vertice> proximosVertices = new List<Vertice>();
                buscaEmProfundidade(verticeAtual, proximosVertices);


                if (proximosVertices.Count != numVertices)
                {
                    return false;
                }

                verticeAtual = verticeAtual.anterior;
            }

            return true;
        }




        //Refazer o de ponte

        //É informado o número de vértices, e duas listas (uma de vertices e uma de arestas), será passado um for pela lista de vertices adicionando cada vértice, e um foreach pra cada aresta, olhando vertice de origem e destino, caso true pros 2 adiciona a aresta.
        public void gerarGrafo(
            int numVertices,
            List<(string nome, string valor)> vertices,
            List<(string nome, string valor, string origem, string destino)> arestas
        )
        {
            if (numVertices >= 2)
            {
                for (int i = 0; i < vertices.Count && i < numVertices; i++)
                {
                    var (nome, valor) = vertices[i];
                    adicionarVertice(nome, valor);
                }
            }

            //Adiciona uma aresta indo da origem para o destino, e uma indo do destino para origem (fazendo assim um grafo não direcionado)
            foreach (var (nome, valor, origemNome, destinoNome) in arestas)
            {
                var origem = encontrarVertice(origemNome);
                var destino = encontrarVertice(destinoNome);

                if (origem != null && destino != null)
                {
                    adicionarAresta(nome, valor, origem, destino);
                    adicionarAresta(nome, valor, destino, origem);
                }
                else
                {
                    Console.WriteLine($" Origem '{origemNome}' ou destino '{destinoNome}' não encontrado.");
                }
            }
        }

        //Funções de teste para saber se tudo foi adicionado corretamente
        public void imprimirDados()
        {
            Console.WriteLine($"Arestas: {numArestas}");
            Console.WriteLine($"Vertices: {numVertices}");
            Console.WriteLine("##############");

            log(ultimoVerticeAdicionado);
        }

        public void log(Vertice vertice)
        {
            Console.WriteLine($"Nome: {vertice.nome} / Valor: {vertice.valor}");
            Console.WriteLine("--------------------");
            if (vertice.arestas != null)
            {
                mostrarAresta(vertice.arestas);
            }
            Console.WriteLine("---");
            if (vertice.arestasQueChegam != null)
            {
                mostrarArestaQueChega(vertice.arestasQueChegam);
            }
            Console.WriteLine("##############\n");

            if (vertice.anterior != null)
            {
                log(vertice.anterior);
            }
        }

        public void mostrarAresta(Aresta aresta)
        {
            Console.WriteLine($"Nome: {aresta.nome} ### Valor: {aresta.valor} ### {aresta.origem.nome}->{aresta.destino.nome}");

            if (aresta.anterior != null)
            {
                mostrarAresta(aresta.anterior);
            }
        }

        public void mostrarArestaQueChega(Aresta aresta)
        {
            Console.WriteLine($"Nome: {aresta.nome} ### Valor: {aresta.valor} ### {aresta.origem.nome}->{aresta.destino.nome}");

            if (aresta.anteriorNoDestino != null)
            {
                mostrarAresta(aresta.anteriorNoDestino);
            }
        }

        public void CSV()
        {
            string caminhoVertices = "grafos_nao_direcionadovertice.csv";
            string caminhoArestas = "grafos_nao_direcionadoaresta.csv";

            using (StreamWriter Vertices = new StreamWriter(caminhoVertices))
            {


                Vertices.WriteLine("id,value");

                Vertice verticeAtual = ultimoVerticeAdicionado;
                while (verticeAtual != null)
                {
                    Vertices.WriteLine($"{verticeAtual.nome},{verticeAtual.valor}");
                    verticeAtual = verticeAtual.anterior;
                }

            }

            using (StreamWriter Arestas = new StreamWriter(caminhoArestas))
            {
                Arestas.WriteLine("source,target,weight");

                Vertice verticeAtual = ultimoVerticeAdicionado;
                while (verticeAtual != null)
                {
                    Aresta arestaAtual = verticeAtual.arestas;
                    while (arestaAtual != null)
                    {
                        Arestas.WriteLine($"{arestaAtual.origem.nome},{arestaAtual.destino.nome},{arestaAtual.valor}");
                        Arestas.WriteLine($"{arestaAtual.destino.nome},{arestaAtual.origem.nome},{arestaAtual.valor}");
                        arestaAtual = arestaAtual.proxima;
                    }
                    verticeAtual = verticeAtual.anterior;
                }
            }


        }
    }
}

public class Vertice
{
    public string nome;
    public string valor;

    public Aresta arestas;

    public Vertice proximo;
    public Vertice anterior;

    public Aresta arestasQueChegam;

    public Vertice(string _nome, string _valor)
    {
        nome = _nome;
        valor = _valor;
        arestas = null;
        proximo = null;
        anterior = null;
    }

    public void adicionarArestaAoVertice(Aresta novaAresta)
    {
        if (arestas == null)
        {
            arestas = novaAresta;
        }
        else
        {
            arestas.proxima = novaAresta;
            novaAresta.anterior = arestas;
            arestas = novaAresta;
        }

        novaAresta.destino.adicionarArestaQueChega(novaAresta);
    }

    public void adicionarArestaQueChega(Aresta novaAresta)
    {
        if (arestasQueChegam == null)
        {
            arestasQueChegam = novaAresta;
        }
        else
        {
            arestasQueChegam.proxima = novaAresta;
            novaAresta.anteriorNoDestino = arestasQueChegam;
            arestasQueChegam = novaAresta;
        }
    }

}

public class Aresta
{
    public string nome;
    public string valor;

    public Vertice origem;
    public Vertice destino;

    public Aresta proxima;
    public Aresta anterior;

    //Serve para permitir o vertice de destino poder acessar a aresta
    public Aresta anteriorNoDestino;
    public Aresta proximoNoDestino;

    public Aresta(string _nome, string _valor, Vertice _origem, Vertice _destino)
    {
        nome = _nome;
        valor = _valor;
        origem = _origem;
        destino = _destino;
        proxima = null;
        anterior = null;
        anteriorNoDestino = null;
    }
}

public class ListaAdjacenciaVertice
{
    Vertice verticeRaiz;
    VerticeAdjacente verticeAdjacente;

    public class VerticeAdjacente
    {
        Vertice vertice;

        public VerticeAdjacente proximoVerticeAdjacente;

        public VerticeAdjacente(Vertice _vertice)
        {
            this.vertice = _vertice;
            this.proximoVerticeAdjacente = null;
        }
    }

    public ListaAdjacenciaVertice(Vertice _verticeRaiz)
    {
        verticeRaiz = _verticeRaiz;
        verticeAdjacente = null;
    }

    public void adicionarVertice(Vertice novoVertice)
    {

        VerticeAdjacente novoAdjacente = new VerticeAdjacente(novoVertice);
        if (verticeAdjacente == null)
        {
            verticeAdjacente = novoAdjacente;
        }
        else
        {
            VerticeAdjacente verticeAtual = verticeAdjacente;
            while (verticeAtual.proximoVerticeAdjacente != null)
            {
                verticeAtual = verticeAtual.proximoVerticeAdjacente;
            }
            verticeAtual.proximoVerticeAdjacente = novoAdjacente;
        }

    }

}

//Grafo direcionado // até o momento é igual ao não direcionado, mas no futuro é para ter as funções especificas
public class GrafoDirecionado
{
    private int numArestas;
    private int numVertices;

    public Vertice ultimoVerticeAdicionado;

    public GrafoDirecionado()
    {
        numArestas = 0;
        numVertices = 0;
        ultimoVerticeAdicionado = null;
    }

    public void adicionarVertice(string _nome, string _valor)
    {
        Vertice novoVertice = new Vertice(_nome, _valor);

        if (ultimoVerticeAdicionado == null)
        {
            ultimoVerticeAdicionado = novoVertice;
        }
        else
        {
            ultimoVerticeAdicionado.proximo = novoVertice;
            novoVertice.anterior = ultimoVerticeAdicionado;
            ultimoVerticeAdicionado = novoVertice;
        }

        numVertices++;
    }

    public void adicionarAresta(string _nome, string _valor, Vertice _origem, Vertice _destino)
    {
        Aresta novaAresta = new Aresta(_nome, _valor, _origem, _destino);

        _origem.adicionarArestaAoVertice(novaAresta);

        numArestas++;
    }

    public void removerAresta(string _nome, Vertice _origem)
    {
        if (_origem.arestas != null)
        {
            Aresta alvo = buscarAresta(_nome, _origem);

            if (alvo != null)
            {
                if (alvo.proxima != null)
                {
                    alvo.proxima.anterior = alvo.anterior;
                }

                if (alvo.anterior != null)
                {
                    alvo.anterior.proxima = alvo.proxima;
                }

                if (_origem.arestas == alvo)
                {
                    _origem.arestas = alvo.proxima;
                }

                alvo.anterior = null;
                alvo.proxima = null;

                numArestas--;
            }
        }
    }

    public Vertice encontrarVertice(string _nome)
    {
        return buscarVertice(_nome, ultimoVerticeAdicionado);
    }

    public Vertice buscarVertice(string _nome, Vertice vertice)
    {

        if (vertice.nome == _nome)
        {
            return vertice;
        }
        if (vertice.anterior != null)
        {
            return buscarVertice(_nome, vertice.anterior);
        }
        else
        {
            return null;
        }

    }

    //Verifica a aresta a qual precisa ser buscada pelo vértice.
    public Aresta buscarAresta(string _nome, Vertice origem)
    {
        Aresta arestaAtual = origem.arestas;

        while (arestaAtual != null)
        {
            if (arestaAtual.nome == _nome)
            {
                return arestaAtual;
            }
            arestaAtual = arestaAtual.proxima;
        }

        return null;
    }

    //Verifica se a aresta passada como parâmetro existe em todo o grafo.
    public bool verificarExistenciaDaAresta(string _nomeAresta)
    {
        if (ultimoVerticeAdicionado == null)
        {
            return false;
        }

        Vertice verticeVerificado = ultimoVerticeAdicionado;
        for (int i = 0; i < numVertices; i++)
        {
            Aresta arestaExiste = buscarAresta(_nomeAresta, verticeVerificado);
            if (arestaExiste != null)
            {
                return true;
            }
            verticeVerificado = verticeVerificado.anterior;
        }
        return false;
    }

    public GrafoNaoDirecionado TransformarEmSubjacente()
    {
        GrafoNaoDirecionado grafoSubjacente = new GrafoNaoDirecionado();

        Vertice verticeAtual = ultimoVerticeAdicionado;
        while (verticeAtual != null)
        {
            grafoSubjacente.adicionarVertice(verticeAtual.nome, verticeAtual.valor);

            Aresta arestaAtual = verticeAtual.arestas;
            while (arestaAtual != null)
            {
                // Para cada aresta no grafo direcionado, adicionar a aresta bidirecional no grafo não direcionado
                Vertice origem = arestaAtual.origem;
                Vertice destino = arestaAtual.destino;

                grafoSubjacente.adicionarAresta(arestaAtual.nome, arestaAtual.valor, origem, destino);

                grafoSubjacente.adicionarAresta(arestaAtual.nome, arestaAtual.valor, destino, origem);

                arestaAtual = arestaAtual.proxima;
            }

            verticeAtual = verticeAtual.anterior;
        }

        return grafoSubjacente;
    }

    public bool simpconexo()
    {
        if (numVertices <= 1)
        {
            return true;
        }

        GrafoNaoDirecionado grafoSubjacente = TransformarEmSubjacente();

        return grafoSubjacente.simpconexo();
    }

    public bool semifortConexo()
    {
        if (numVertices <= 1)
        {
            return true;
        }

        Vertice verticeInicial = ultimoVerticeAdicionado;

        List<Vertice> visitaOrigem = new List<Vertice>();
        buscaEmProfundidade(verticeInicial, visitaOrigem);

        if (visitaOrigem.Count != numVertices)
        {
            return false; // Se nem todos os vértices são acessíveis, não é semifortemente conexo
        }

        GrafoDirecionado grafoInvertido = InverterGrafo();
        List<Vertice> visitaDestino = new List<Vertice>();
        grafoInvertido.buscaEmProfundidade(verticeInicial, visitaDestino);

        if (visitaDestino.Count != numVertices)
        {
            return false; // Se nem todos os vértices são acessíveis no grafo invertido, não é semifortemente conexo
        }

        return true; // Se ambos os testes forem bem-sucedidos, o grafo é semifortemente conexo
    }

    public bool fortementeConexo()
    {
        if (numVertices <= 1)
        {
            return true;
        }

        Vertice verticeInicial = ultimoVerticeAdicionado;

        List<Vertice> visitaOrigem = new List<Vertice>();
        buscaEmProfundidade(verticeInicial, visitaOrigem);

        if (visitaOrigem.Count != numVertices)
        {
            return false;
        }

        GrafoDirecionado grafoInvertido = InverterGrafo();

        List<Vertice> visitaDestino = new List<Vertice>();
        grafoInvertido.buscaEmProfundidade(verticeInicial, visitaDestino);

        // Se todos os vértices foram visitados no grafo original e no grafo invertido, o grafo é fortemente conexo
        return visitaDestino.Count == numVertices;
    }

    private void buscaEmProfundidade(Vertice vertice, List<Vertice> visitados)
    {
        if (vertice == null || visitados.Contains(vertice))
        {
            return;
        }

        visitados.Add(vertice);

        Aresta arestaAtual = vertice.arestas;

        while (arestaAtual != null)
        {
            buscaEmProfundidade(arestaAtual.destino, visitados);
            arestaAtual = arestaAtual.proxima;
        }
    }

    public GrafoDirecionado InverterGrafo()
    {
        GrafoDirecionado grafoInvertido = new GrafoDirecionado();

        Vertice verticeAtual = ultimoVerticeAdicionado;
        while (verticeAtual != null)
        {
            grafoInvertido.adicionarVertice(verticeAtual.nome, verticeAtual.valor);

            Aresta arestaAtual = verticeAtual.arestas;
            while (arestaAtual != null)
            {
                // Para cada aresta no grafo original, adicionar a aresta invertida no grafo invertido
                // A aresta original é de origem -> destino, então a aresta invertida será de destino -> origem
                grafoInvertido.adicionarAresta(arestaAtual.nome, arestaAtual.valor, arestaAtual.destino, arestaAtual.origem);

                arestaAtual = arestaAtual.proxima;
            }

            verticeAtual = verticeAtual.anterior;
        }

        return grafoInvertido;
    }

    // Verifica a adjacencia entre arestas pela origem de um vertice e destino do outro (direcionado)
    public bool adjacenciaEntreArestas(string nomeArestaA, string nomeArestaB)
    {
        Aresta arestaA = buscarAresta(nomeArestaA, ultimoVerticeAdicionado);
        Aresta arestaB = buscarAresta(nomeArestaB, ultimoVerticeAdicionado);

        if (arestaA != null && arestaB != null)
        {
            // Verifica se o destino de arestaA é a origem de arestaB
            if (arestaA.destino == arestaB.origem)
            {
                return true;
            }
        }

        return false;
    }

    // Verifica a adjacencia entre vertices pela origem de um vertice e destino do outro pelas arestas (direcionado)
    public bool adjacenciaEntreVertices(string nomeVerticeA, string nomeVerticeB)
    {
        Vertice origem = buscarVertice(nomeVerticeA, ultimoVerticeAdicionado);
        Vertice destino = buscarVertice(nomeVerticeB, ultimoVerticeAdicionado);

        if (origem != null && destino != null)
        {

            Aresta arestaEmAnalise = origem.arestas;

            while (arestaEmAnalise != null)
            {
                // Verifica se há uma aresta saindo de origem para destino
                if (arestaEmAnalise.origem.nome == nomeVerticeA && arestaEmAnalise.destino.nome == nomeVerticeB)
                {
                    return true;
                }

                arestaEmAnalise = arestaEmAnalise.proxima;
            }
        }


        return false;
    }


    public bool GrafoVazio()
    {
        return numArestas == 0;
    }

    // Se tiver uma aresta entre cada par de vértices é completo
    public bool GrafoCompleto()
    {

        int numeroDeArestasEsperado = numVertices * (numVertices - 1);

        return numArestas == numeroDeArestasEsperado;
    }

    public int quantidadeDeVertices()
    {
        return this.numVertices;
    }

    public int quantidadeDeArestas()
    {
        return this.numArestas;
    }


    //É informado o número de vértices, e duas listas (uma de vertices e uma de arestas), será passado um for pela lista de vertices adicionando cada vértice, e um foreach pra cada aresta, olhando vertice de origem e destino, caso true pros 2 adiciona a aresta.
    public void gerarGrafodirec(
        int numVertices,
        List<(string nome, string valor)> vertices,
        List<(string nome, string valor, string origem, string destino)> arestas
    )
    {
        if (numVertices >= 2)
        {
            for (int i = 0; i < vertices.Count && i < numVertices; i++)
            {
                var (nome, valor) = vertices[i];
                adicionarVertice(nome, valor);
            }
        }

        //Adiciona uma aresta indo da origem para o destino somente
        foreach (var (nome, valor, origemNome, destinoNome) in arestas)
        {
            var origem = encontrarVertice(origemNome);
            var destino = encontrarVertice(destinoNome);

            if (origem != null && destino != null)
            {
                adicionarAresta(nome, valor, origem, destino);
            }
            else
            {
                Console.WriteLine($" Origem '{origemNome}' ou destino '{destinoNome}' não encontrado.");
            }
        }
    }

    //Função de teste para saber se tudo foi adicionado corretamente
    public void imprimirDados()
    {
        Console.WriteLine($"Arestas: {numArestas}");
        Console.WriteLine($"Vertices: {numVertices}");
        Console.WriteLine("##############");

        log(ultimoVerticeAdicionado);
    }

    public void log(Vertice vertice)
    {
        Console.WriteLine($"Nome: {vertice.nome}");
        Console.WriteLine($"Valor: {vertice.valor}");
        Console.WriteLine("--------------------");
        if (vertice.arestas != null)
        {
            mostrarAresta(vertice.arestas);
        }
        Console.WriteLine("##############");

        if (vertice.anterior != null)
        {
            log(vertice.anterior);
        }
    }

    public void mostrarAresta(Aresta aresta)
    {
        Console.WriteLine($"Nome: {aresta.nome} ### Valor: {aresta.valor} ### {aresta.origem.nome}->{aresta.destino.nome}");

        if (aresta.anterior != null)
        {
            mostrarAresta(aresta.anterior);
        }
    }

    public void CSV()
    {
        string caminhoVertices = "grafos_direcionadovertice.csv";
        string caminhoArestas = "grafos_direcionadoaresta.csv";

        using (StreamWriter Vertices = new StreamWriter(caminhoVertices))
        {


            Vertices.WriteLine("id,value");

            Vertice verticeAtual = ultimoVerticeAdicionado;
            while (verticeAtual != null)
            {
                Vertices.WriteLine($"{verticeAtual.nome},{verticeAtual.valor}");
                verticeAtual = verticeAtual.anterior;
            }

        }

        using (StreamWriter Arestas = new StreamWriter(caminhoArestas))
        {
            Arestas.WriteLine("source,target,weight");

            Vertice verticeAtual = ultimoVerticeAdicionado;
            while (verticeAtual != null)
            {
                Aresta arestaAtual = verticeAtual.arestas;
                while (arestaAtual != null)
                {
                    Arestas.WriteLine($"{arestaAtual.origem.nome},{arestaAtual.destino.nome},{arestaAtual.valor}");
                    arestaAtual = arestaAtual.proxima;
                }
                verticeAtual = verticeAtual.anterior;
            }
        }


    }
}

