using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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

                if (ultimoVerticeAdicionado == alvo)
                {
                    ultimoVerticeAdicionado = alvo.anterior;
                }

                //alvo.proximo = null;
                //alvo.anterior = null;

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
        public string[] listaDeAdjacencia(Vertice verticeRaizDaLista)
        {

            Aresta aresta = verticeRaizDaLista.arestas;
            Aresta arestaQueChega = verticeRaizDaLista.arestasQueChegam;
            int count = 0;
            while (aresta != null)
            {
                aresta = aresta.anterior;
                count++;
            }
            while (arestaQueChega != null)
            {
                arestaQueChega = arestaQueChega.anterior;
                count++;
            }

            string[] listaAdjacencia = new string[count + 1];
            count = 1;
            listaAdjacencia[0] = verticeRaizDaLista.nome;

            aresta = verticeRaizDaLista.arestas;
            arestaQueChega = verticeRaizDaLista.arestasQueChegam;

            while (aresta != null)
            {
                listaAdjacencia[count] = aresta.destino.nome;
                count++;
                aresta = aresta.anterior;
            }
            while (arestaQueChega != null)
            {
                listaAdjacencia[count] = arestaQueChega.origem.nome;
                count++;
                arestaQueChega = arestaQueChega.anterior;
            }

            return listaAdjacencia;
        }

        //Quantidade de vertices do grafo
        public int quantidadeDeVertices()
        {
            return this.numVertices;
        }

        //Quantidade de arestas do grafo (falta direcionado)
        public int quantidadeDeArestas()
        {
            // int count = 0;

            // if (this.ultimoVerticeAdicionado != null)
            // {
            //     Vertice vertice = ultimoVerticeAdicionado;
            //     do
            //     {
            //         Aresta arestaAtual = vertice.arestas;

            //         while (arestaAtual != null)
            //         {
            //             count++;
            //             arestaAtual = arestaAtual.anterior;
            //         }

            //         vertice = vertice.anterior;
            //     }
            //     while (vertice.anterior != null);

            // }

            // return count;

            return numArestas;
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
                if (!visitados.Contains(arestaAtual.destino)) 
                {
                    buscaEmProfundidade(arestaAtual.destino, visitados);
                }
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

        // A partir do último vértice adicionado, realiza a busca em profundidade, se todos os vértices não forem alcançáveis retorna false, e ve se todos os vértices alcançam todos os vértices, se não for, retorna false
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

        /* É informado o número de vértices, e duas listas (uma de vertices e uma de arestas), será passado um for pela lista de vertices adicionando
        cada vértice, e um foreach pra cada aresta, olhando vertice de origem e destino, caso true pros 2 adiciona a aresta. */
        public List<Aresta> gerarGrafo(int numVertices, int numArestas)
        {


            Vertice[] vertices = new Vertice[numVertices];
            for (int i = 0; i < numVertices; i++)
            {
                vertices[i] = new Vertice($"Vertice{i}", $"Valor{i}");
                adicionarVertice(vertices[i].nome, vertices[i].valor);
            }

            Random random = new Random();
            List<Aresta> arestas = new List<Aresta>();

            while (numArestas > 0)
            {
                int origemIndex = random.Next(0, numVertices);
                int destinoIndex = random.Next(0, numVertices);


                while (origemIndex == destinoIndex)
                {
                    destinoIndex = random.Next(0, numVertices);
                }

                Vertice origem = vertices[origemIndex];
                Vertice destino = vertices[destinoIndex];

                string arestaNome = $"Aresta{origemIndex}_{destinoIndex}";
                string arestaValor = $"ValorAresta{numArestas}";


                bool arestaExistente = arestas.Any(a =>
                    (a.origem == origem && a.destino == destino) ||
                    (a.origem == destino && a.destino == origem));

                if (!arestaExistente)
                {
                    Aresta novaAresta = new Aresta(arestaNome, arestaValor, origem, destino);

                    arestas.Add(novaAresta);
                    adicionarAresta(novaAresta.nome, novaAresta.valor, encontrarVertice(novaAresta.origem.nome), encontrarVertice(novaAresta.destino.nome));
                    //adicionarAresta(novaAresta.nome, novaAresta.valor, novaAresta.destino, novaAresta.origem);


                    numArestas--;
                }
            }

            return arestas;
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

        // Gera CSV com o grafo não direc e a lista retornada de arestas aleatória (foi o jeito que eu arrumei pra fazer)
        public void CSV(List<Aresta> arestasaleat)
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

                foreach (var aresta in arestasaleat)
                {
                    Arestas.WriteLine($"{aresta.origem.nome},{aresta.destino.nome},{aresta.valor}");
                }

            }
        }

        //Gera CSV com o grafo não direc e os valores colocados pelo usuário
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
                        //Arestas.WriteLine($"{arestaAtual.destino.nome},{arestaAtual.origem.nome},{arestaAtual.valor}");
                        arestaAtual = arestaAtual.anterior;
                    }
                    verticeAtual = verticeAtual.anterior;
                }
            }


        }

        public void naive()
        {
            GrafoNaoDirecionado grafoDasRemocoes = copiarGrafo(this);

            List<Aresta> listaDeArestas = new List<Aresta>();
            adicionarArestasALista(grafoDasRemocoes, listaDeArestas);
            List<Aresta> listaDePontes = new List<Aresta>();

            foreach (Aresta aresta in listaDeArestas)
            {
                grafoDasRemocoes.removerAresta(aresta.nome, aresta.origem);

                if (!grafoDasRemocoes.semifortConexo())
                {
                    // Console.WriteLine(">>>Ponte Encontrada"+aresta.nome);
                    listaDePontes.Add(aresta);
                }

                grafoDasRemocoes = copiarGrafo(this);
                //listaDePontes = grafoDasRemocoesDirecionado.encontrarPontes();
            }

            if (listaDePontes.Count() != 0)
            {
                Console.WriteLine("Ponte Encontrada");

                foreach (Aresta ponte in listaDePontes)
                {
                    Console.WriteLine("ponte: " + ponte.origem.nome + "->" + ponte.destino.nome);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma Ponte Encontrada");
            }

        }


        public GrafoNaoDirecionado copiarGrafo(GrafoNaoDirecionado grafoASerCopiado)
        {
            GrafoNaoDirecionado grafoCopiado = new GrafoNaoDirecionado();

            Vertice verticeAtual = grafoASerCopiado.ultimoVerticeAdicionado;

            while (verticeAtual != null)
            {
                grafoCopiado.adicionarVertice(verticeAtual.nome, verticeAtual.valor);

                verticeAtual = verticeAtual.anterior;
            }

            verticeAtual = grafoASerCopiado.ultimoVerticeAdicionado;

            while (verticeAtual != null)
            {
                Aresta arestaAtual = verticeAtual.arestas;

                while (arestaAtual != null)
                {
                    grafoCopiado.adicionarAresta(arestaAtual.nome, arestaAtual.valor, grafoCopiado.encontrarVertice(arestaAtual.origem.nome), grafoCopiado.encontrarVertice(arestaAtual.destino.nome));
                    arestaAtual = arestaAtual.anterior;
                }

                verticeAtual = verticeAtual.anterior;
            }

            return grafoCopiado;
        }

        public void adicionarArestasALista(GrafoNaoDirecionado grafo, List<Aresta> lista)
        {
            Vertice verticeAtual = grafo.ultimoVerticeAdicionado;//pegando vertices do grafo especifico


            while (verticeAtual != null)
            {
                Aresta arestaAtual = verticeAtual.arestas;

                while (arestaAtual != null)
                {
                    lista.Add(arestaAtual);
                    arestaAtual = arestaAtual.anterior;
                }

                verticeAtual = verticeAtual.anterior;
            }

        }

        public GrafoDirecionado converterEmDirecionado()
        {
            GrafoDirecionado grafoDirecionado = new GrafoDirecionado();

            //Adicionando vertice
            Vertice verticeAtual = ultimoVerticeAdicionado;
            while (verticeAtual != null)
            {
                grafoDirecionado.adicionarVertice(verticeAtual.nome, verticeAtual.valor);
                verticeAtual = verticeAtual.anterior;//anterior?
            }

            //Adicionando aresta
            verticeAtual = ultimoVerticeAdicionado;
            Aresta arestaAtual;
            while (verticeAtual != null)
            {
                arestaAtual = verticeAtual.arestas;

                while (arestaAtual != null)
                {
                    grafoDirecionado.adicionarAresta(arestaAtual.nome, arestaAtual.valor, grafoDirecionado.encontrarVertice(arestaAtual.origem.nome), grafoDirecionado.encontrarVertice(arestaAtual.destino.nome));
                    grafoDirecionado.adicionarAresta(arestaAtual.nome + "Invertida", arestaAtual.valor, grafoDirecionado.encontrarVertice(arestaAtual.destino.nome), grafoDirecionado.encontrarVertice(arestaAtual.origem.nome));
                    arestaAtual = arestaAtual.anterior;//ou proximo?
                }

                verticeAtual = verticeAtual.anterior;
            }


            return grafoDirecionado;
        }

        public int kosaraju()
        {
            GrafoDirecionado grafoDirecionado = converterEmDirecionado();
            return grafoDirecionado.kosaraju();
        }

        public List<Vertice> obterTodosOsVertices()
        {
            List<Vertice> vertices = new List<Vertice>();
            Vertice verticeAtual = ultimoVerticeAdicionado;
            while (verticeAtual != null)
            {
                vertices.Add(verticeAtual);
                verticeAtual = verticeAtual.anterior;
            }
            return vertices;
        }

        public List<(Vertice origem, Vertice destino)> encontrarPontesTarjan()
        {
            GrafoDirecionado grafoConvertidoParaDirecionado = converterEmDirecionado();
            List<(Vertice origem, Vertice destino)> pontes;
            pontes = grafoConvertidoParaDirecionado.encontrarPontesTarjan();
            return pontes;
        }

        public List<Vertice> encontrarArticulacoesTarjan()
        {
            GrafoDirecionado grafoConvertidoParaDirecionado = converterEmDirecionado();
            List<Vertice> articulacoes = new List<Vertice>();
            articulacoes = grafoConvertidoParaDirecionado.encontrarArticulacoesTarjan();
            return articulacoes;
        }

        public void lerArquivo()
        {
            string caminhoVertices = "grafos_nao_direcionadovertice.csv";
            string caminhoArestas = "grafos_nao_direcionadoaresta.csv";

            StreamReader leitor = new StreamReader(caminhoVertices);
            String linha = leitor.ReadLine();//pula a primeira => colunas
            linha = leitor.ReadLine();
            String[] dados;

            while (linha != null)
            {
                dados = linha.Split(",");

                adicionarVertice(dados[0], dados[1]);

                linha = leitor.ReadLine();
            }

            leitor = new StreamReader(caminhoArestas);
            linha = leitor.ReadLine();//pula a primeira => colunas
            linha = leitor.ReadLine();

            while (linha != null)
            {
                dados = linha.Split(",");

                adicionarAresta("Aresta" + dados[0] + "" + dados[1], dados[2], encontrarVertice(dados[0]), encontrarVertice(dados[1]));

                linha = leitor.ReadLine();
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

    public void adicionarArestaAoVerticeGrafoDirecionado(Aresta novaAresta)
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

    public void removerVertice(string _nome)
    {
        Vertice alvo = buscarVertice(_nome, ultimoVerticeAdicionado);
        if (alvo != null)
        {
            while (alvo.arestas != null)
            {
                //Console.WriteLine("removido " + alvo.arestas.nome);
                RemoverAresta(alvo.arestas.nome);
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

            if (ultimoVerticeAdicionado == alvo)
            {
                ultimoVerticeAdicionado = alvo.anterior;
            }

            //alvo.proximo = null;
            //alvo.anterior = null;

            numVertices--;
        }
    }

    public void adicionarAresta(string _nome, string _valor, Vertice _origem, Vertice _destino)
    {
        Aresta novaAresta = new Aresta(_nome, _valor, _origem, _destino);

        _origem.adicionarArestaAoVerticeGrafoDirecionado(novaAresta);

        numArestas++;
    }

    public void RemoverAresta(string nomeAresta)
    {
        // Itera sobre todos os vértices para encontrar a aresta a ser removida
        Vertice verticeAtual = ultimoVerticeAdicionado;
        while (verticeAtual != null)
        {
            Aresta arestaAtual = verticeAtual.arestas;
            while (arestaAtual != null)
            {
                if (arestaAtual.nome == nomeAresta)
                {
                    // Ajusta os ponteiros para remover a aresta da lista de saída do vértice
                    if (arestaAtual.anterior != null)
                    {
                        arestaAtual.anterior.proxima = arestaAtual.proxima;
                    }
                    if (arestaAtual.proxima != null)
                    {
                        arestaAtual.proxima.anterior = arestaAtual.anterior;
                    }
                    if (verticeAtual.arestas == arestaAtual)
                    {
                        verticeAtual.arestas = arestaAtual.proxima;
                    }

                    // Ajusta os ponteiros no vértice de destino para remover a referência à aresta
                    Vertice destino = arestaAtual.destino;
                    if (destino.arestasQueChegam == arestaAtual)
                    {
                        destino.arestasQueChegam = arestaAtual.anteriorNoDestino;
                    }
                    if (arestaAtual.anteriorNoDestino != null)
                    {
                        arestaAtual.anteriorNoDestino.proximoNoDestino = arestaAtual.proximoNoDestino;
                    }
                    if (arestaAtual.proximoNoDestino != null)
                    {
                        arestaAtual.proximoNoDestino.anteriorNoDestino = arestaAtual.anteriorNoDestino;
                    }

                    numArestas--;

                    return;
                }

                arestaAtual = arestaAtual.proxima;
            }

            verticeAtual = verticeAtual.anterior;
        }

        Console.WriteLine($"Aresta com nome '{nomeAresta}' não encontrada.");
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

        // Primeiro, adiciona todos os vértices
        Vertice verticeAtual = ultimoVerticeAdicionado;
        while (verticeAtual != null)
        {
            grafoSubjacente.adicionarVertice(verticeAtual.nome, verticeAtual.valor);
            verticeAtual = verticeAtual.anterior;
        }

        verticeAtual = ultimoVerticeAdicionado;  // Reinicia a iteração dos vértices

        while (verticeAtual != null)
        {
            Aresta arestaAtual = verticeAtual.arestas;

            if (arestaAtual != null)
            {
                grafoSubjacente.adicionarAresta(
                    arestaAtual.nome,
                    arestaAtual.valor,
                    grafoSubjacente.encontrarVertice(arestaAtual.origem.nome),
                    grafoSubjacente.encontrarVertice(arestaAtual.destino.nome)
                );
            }

            verticeAtual = verticeAtual.anterior;  // Avança para o próximo vértice
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
        grafoSubjacente.imprimirDados();

        return grafoSubjacente.simpconexo();
    }

    public bool semifortConexo()
    {
        if (numVertices <= 1)
        {
            return true;
        }

        Vertice verticeInicial = ultimoVerticeAdicionado;
        bool BEMGrafoOriginal;
        bool BEMGrafoInvertido;

        List<Vertice> visitaOrigem = new List<Vertice>();
        buscaEmProfundidade(verticeInicial, visitaOrigem);

        if (visitaOrigem.Count == numVertices)
        {
            BEMGrafoOriginal = true;
        }
        else
        {
            BEMGrafoOriginal = false;
        }

        GrafoDirecionado grafoInvertido = InverterGrafo();
        List<Vertice> visitaDestino = new List<Vertice>();
        grafoInvertido.buscaEmProfundidade(grafoInvertido.encontrarVertice(verticeInicial.nome), visitaDestino);

        if (visitaDestino.Count == numVertices)
        {
            BEMGrafoInvertido = true;
        }
        else
        {
            BEMGrafoInvertido = false;
        }

        return BEMGrafoOriginal || BEMGrafoInvertido; // Se uma das buscas em profundidade forem bem sucedidas, o grafo é semifortemente conexo
    }

    public bool fortementeConexo()
    {
        if (numVertices <= 1)
        {
            return true;
        }

        Vertice verticeInicial = ultimoVerticeAdicionado;
        bool BEMGrafoOriginal;
        bool BEMGrafoInvertido;

        List<Vertice> visitaOrigem = new List<Vertice>();
        buscaEmProfundidade(verticeInicial, visitaOrigem);

        if (visitaOrigem.Count == numVertices)
        {
            BEMGrafoOriginal = true;
        }
        else
        {
            BEMGrafoOriginal = false;
        }

        GrafoDirecionado grafoInvertido = InverterGrafo();
        grafoInvertido.imprimirDados();
        List<Vertice> visitaDestino = new List<Vertice>();
        grafoInvertido.buscaEmProfundidade(grafoInvertido.encontrarVertice(verticeInicial.nome), visitaDestino);

        if (visitaDestino.Count == numVertices)
        {
            BEMGrafoInvertido = true;
        }
        else
        {
            BEMGrafoInvertido = false;
        }

        return BEMGrafoOriginal && BEMGrafoInvertido; // Se ambas as buscas em profundidade forem bem sucedidas, o grafo é fortemente conexo
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

        // Primeiro, adiciona todos os vértices no grafo invertido
        Vertice verticeAtual = ultimoVerticeAdicionado;
        while (verticeAtual != null)
        {
            grafoInvertido.adicionarVertice(verticeAtual.nome, verticeAtual.valor);
            verticeAtual = verticeAtual.anterior;
        }

        // Agora, adiciona as arestas invertidas
        verticeAtual = ultimoVerticeAdicionado;
        while (verticeAtual != null)
        {
            Aresta arestaAtual = verticeAtual.arestas;
            while (arestaAtual != null)
            {
                // Para cada aresta no grafo original, adicionar a aresta invertida no grafo invertido
                // A aresta original é de origem -> destino, então a aresta invertida será de destino -> origem
                grafoInvertido.adicionarAresta(
                    arestaAtual.nome,
                    arestaAtual.valor,
                    grafoInvertido.encontrarVertice(arestaAtual.destino.nome),
                    grafoInvertido.encontrarVertice(arestaAtual.origem.nome)
                );

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
            if (arestaA.destino == arestaB.origem || arestaA.origem == arestaB.destino)
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

    //Retorna a lista de adjacencia de um vertice especifico
    public string[] listaDeAdjacencia(Vertice verticeRaizDaLista)
    {

        Aresta aresta = verticeRaizDaLista.arestas;
        int count = 0;
        while (aresta != null)
        {
            aresta = aresta.anterior;
            count++;
        }

        string[] listaAdjacencia = new string[count + 1];
        count = 1;
        listaAdjacencia[0] = verticeRaizDaLista.nome;

        aresta = verticeRaizDaLista.arestas;

        while (aresta != null)
        {
            listaAdjacencia[count] = aresta.destino.nome;
            count++;
            aresta = aresta.anterior;
        }

        return listaAdjacencia;
    }



    //É informado o número de vértices, e duas listas (uma de vertices e uma de arestas), será passado um for pela lista de vertices adicionando cada vértice, e um foreach pra cada aresta, olhando vertice de origem e destino, caso true pros 2 adiciona a aresta.
    public List<Aresta> gerarGrafo(int numVertices, int numArestas)
    {

        Vertice[] vertices = new Vertice[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            vertices[i] = new Vertice($"Vertice{i}", $"Valor{i}");
            adicionarVertice(vertices[i].nome, vertices[i].valor);
        }

        Random random = new Random();
        List<Aresta> arestas = new List<Aresta>();

        while (numArestas > 0)
        {
            int origemIndex = random.Next(0, numVertices);
            int destinoIndex = random.Next(0, numVertices);


            while (origemIndex == destinoIndex)
            {
                destinoIndex = random.Next(0, numVertices);
            }

            Vertice origem = vertices[origemIndex];
            Vertice destino = vertices[destinoIndex];

            string arestaNome = $"Aresta{origemIndex}_{destinoIndex}";
            string arestaValor = $"ValorAresta{numArestas}";


            bool arestaExistente = arestas.Any(a =>
                (a.origem == origem && a.destino == destino) ||
                (a.origem == destino && a.destino == origem));

            if (!arestaExistente)
            {
                Aresta novaAresta = new Aresta(arestaNome, arestaValor, origem, destino);

                arestas.Add(novaAresta);
                adicionarAresta(novaAresta.nome, novaAresta.valor, encontrarVertice(novaAresta.origem.nome), encontrarVertice(novaAresta.destino.nome));


                numArestas--;
            }
        }

        return arestas;
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

    // Gera CSV com o grafo não direc e a lista retornada de arestas aleatória (foi o jeito que eu arrumei pra fazer)
    public void CSV(List<Aresta> arestasaleat)
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

            foreach (var aresta in arestasaleat)
            {
                Arestas.WriteLine($"{aresta.origem.nome},{aresta.destino.nome},{aresta.valor}");
            }

        }
    }

    //Gera CSV com o grafo não direc e os valores colocados pelo usuário
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
                    arestaAtual = arestaAtual.anterior;
                }
                verticeAtual = verticeAtual.anterior;
            }
        }


    }


    public int kosaraju()
    {
        //adicionando os vertices a lista
        List<Vertice> vertices = new List<Vertice>();
        Vertice verticeAtual = ultimoVerticeAdicionado;
        while (verticeAtual != null)
        {
            vertices.Add(verticeAtual);
            verticeAtual = verticeAtual.anterior;
        }

        //visitando vertices
        List<Vertice> visitados = new List<Vertice>();
        List<Vertice> stack = new List<Vertice>();

        verticeAtual = vertices.First();
        Aresta arestaAtual;
        while (verticeAtual != null)
        {
            if (!visitados.Contains(verticeAtual))
            {
                pesquisaEmProfundidadeKosaraju(verticeAtual, visitados, stack);
            }

            verticeAtual = verticeAtual.anterior;
        }

        //invertendo grafo
        GrafoDirecionado grafoInvertido = InverterGrafo();

        visitados = new List<Vertice>();
        //Simulando o comportamento de uma pilha em uma lista porque nao consegui substituir a lista por pilha no resto da função

        List<Vertice> aux = new List<Vertice>();
        foreach (var vertice in stack)
        {
            aux.Add(grafoInvertido.encontrarVertice(vertice.nome));
        }
        stack = aux;

        verticeAtual = stack.Last();
        stack.RemoveAt(stack.Count() - 1);
        int componentes = 0;

        while (stack.Count() >= 0)
        {
            //Console.WriteLine("---" + verticeAtual.nome);
            if (!visitados.Contains(verticeAtual))
            {
                grafoInvertido.pesquisaEmProfundidadeKosarajuInvertido(grafoInvertido, verticeAtual, visitados, stack);
                componentes++;
            }

            if (stack.Count() > 0)
            {
                verticeAtual = stack.Last();
                stack.RemoveAt(stack.Count() - 1);
            }
            else
            {
                break;
            }


        }
        //componentes--;
        return componentes;

    }

    private void pesquisaEmProfundidadeKosaraju(Vertice vertice, List<Vertice> visitados, List<Vertice> stack)
    {
        visitados.Add(vertice);
        Aresta arestaAtual = vertice.arestas;

        while (arestaAtual != null)
        {
            if (!visitados.Contains(arestaAtual.destino))
            {
                pesquisaEmProfundidadeKosaraju(arestaAtual.destino, visitados, stack);
            }
            arestaAtual = arestaAtual.proxima;
        }

        stack.Add(vertice); // Adiciona o vértice à pilha após processar todas as arestas
    }

    private void pesquisaEmProfundidadeKosarajuInvertido(GrafoDirecionado grafoInvertido, Vertice vertice, List<Vertice> visitados, List<Vertice> stack)
    {
        visitados.Add(vertice);
        Aresta arestaAtual = vertice.arestas;

        while (arestaAtual != null)
        {
            if (!visitados.Contains(arestaAtual.destino))
            {
                grafoInvertido.pesquisaEmProfundidadeKosarajuInvertido(grafoInvertido, arestaAtual.destino, visitados, stack);
            }
            arestaAtual = arestaAtual.proxima;
        }

    }

    public List<Vertice> obterTodosOsVertices()
    {
        List<Vertice> vertices = new List<Vertice>();
        Vertice verticeAtual = ultimoVerticeAdicionado;
        while (verticeAtual != null)
        {
            vertices.Add(verticeAtual);
            verticeAtual = verticeAtual.anterior;
        }
        return vertices;
    }

    public List<(Vertice origem, Vertice destino)> encontrarPontesTarjan()
    {
        // Lista para armazenar as pontes encontradas
        List<(Vertice origem, Vertice destino)> pontes = new List<(Vertice origem, Vertice destino)>();

        // auxiliares para a busca em profundidade
        Dictionary<Vertice, bool> visitado = new Dictionary<Vertice, bool>();
        Dictionary<Vertice, int> tempoDeDescoberta = new Dictionary<Vertice, int>();
        Dictionary<Vertice, int> menorTempoDeDescoberta = new Dictionary<Vertice, int>();
        Dictionary<Vertice, Vertice> pai = new Dictionary<Vertice, Vertice>();

        // Inicializar as estruturas
        foreach (var vertice in obterTodosOsVertices())
        {
            visitado[vertice] = false;
            tempoDeDescoberta[vertice] = -1;
            menorTempoDeDescoberta[vertice] = -1;
            pai[vertice] = null;
        }

        // Tempo usado no cálculo do tempo de descoberta
        int tempo = 0;

        // Itera por todos os vértices para garantir que todos os componentes sejam processados
        foreach (var vertice in obterTodosOsVertices())
        {
            if (!visitado[vertice])
            {
                buscaEmProfundidadeParaPontesTarjan(vertice, visitado, tempoDeDescoberta, menorTempoDeDescoberta, pai, ref tempo, pontes);
            }
        }

        return pontes;
    }

    private void buscaEmProfundidadeParaPontesTarjan
    (
        Vertice u,
        Dictionary<Vertice, bool> visitado,
        Dictionary<Vertice, int> tempoDeDescoberta,
        Dictionary<Vertice, int> menorTempoDeDescoberta,
        Dictionary<Vertice, Vertice> pai,
        ref int tempo,
        List<(Vertice origem, Vertice destino)> pontes
    )
    {
        // Marca o vértice como visitado
        visitado[u] = true;

        // Define tempo de descoberta e o menor tempo do vértice atual
        tempo++;
        tempoDeDescoberta[u] = menorTempoDeDescoberta[u] = tempo;

        // Percorre todas as arestas do vértice atual
        Aresta arestaAtual = u.arestas;
        while (arestaAtual != null)
        {
            Vertice v = arestaAtual.destino;

            if (!visitado[v])
            {
                // Marca o vértice atual como pai do próximo vértice
                pai[v] = u;

                // Chamada recursiva para o próximo vértice
                buscaEmProfundidadeParaPontesTarjan(v, visitado, tempoDeDescoberta, menorTempoDeDescoberta, pai, ref tempo, pontes);

                // Atualiza o menor tem,po de descoberta do vértice atual com base no filho
                menorTempoDeDescoberta[u] = Math.Min(menorTempoDeDescoberta[u], menorTempoDeDescoberta[v]);

                // Se o menor tempo de descoberta do vértice filho for maior que o tempo de descoberta do vértice atual, é uma ponte
                if (menorTempoDeDescoberta[v] > tempoDeDescoberta[u])
                {
                    pontes.Add((u, v));
                }
            }
            else if (v != pai[u])
            {
                // Atualiza o menor tempo de descoberta do vértice atual com base em arestas de retorno
                menorTempoDeDescoberta[u] = Math.Min(menorTempoDeDescoberta[u], tempoDeDescoberta[v]);
            }

            arestaAtual = arestaAtual.anterior;
        }
    }

    public List<Vertice> encontrarArticulacoesTarjan()
    {
        List<Vertice> articulacoes = new List<Vertice>();

        // auxiliares para a busca em profundidade
        Dictionary<Vertice, bool> visitado = new Dictionary<Vertice, bool>();
        Dictionary<Vertice, int> tempoDeDescoberta = new Dictionary<Vertice, int>();
        Dictionary<Vertice, int> menorTempoDeDescoberta = new Dictionary<Vertice, int>();
        Dictionary<Vertice, Vertice> pai = new Dictionary<Vertice, Vertice>();
        Dictionary<Vertice, int> filhos = new Dictionary<Vertice, int>(); // Contagem de filhos

        // Inicialização das estruturas auxiliares

        foreach (var vertice in obterTodosOsVertices())
        {
            visitado[vertice] = false;
            tempoDeDescoberta[vertice] = -1;
            menorTempoDeDescoberta[vertice] = -1;
            pai[vertice] = null;
            filhos[vertice] = 0;
        }

        // Tempo usado no cálculo do tempo de descoberta
        int tempo = 0;

        // Itera por todos os vértices ordenados para garantir que todos os componentes sejam processados
        foreach (var vertice in obterTodosOsVertices())
        {
            if (!visitado[vertice])
            {
                buscaEmProfundidadeParaArticulacoesTarjan(vertice, visitado, tempoDeDescoberta, menorTempoDeDescoberta, pai, filhos, ref tempo, articulacoes);
            }
        }

        return articulacoes;
    }

    private void buscaEmProfundidadeParaArticulacoesTarjan
    (
        Vertice u,
        Dictionary<Vertice, bool> visitado,
        Dictionary<Vertice, int> tempoDeDescoberta,
        Dictionary<Vertice, int> menorTempoDeDescoberta,
        Dictionary<Vertice, Vertice> pai,
        Dictionary<Vertice, int> filhos,
        ref int tempo,
        List<Vertice> articulacoes
    )
    {
        // Marca o vértice como visitado
        visitado[u] = true;

        // Define tempo de descoberta e o menor tempo do vértice atual
        tempoDeDescoberta[u] = menorTempoDeDescoberta[u] = ++tempo;

        // Percorre todas as arestas do vértice atual
        Aresta arestaAtual = u.arestas;
        while (arestaAtual != null)
        {
            Vertice v = arestaAtual.destino;

            if (!visitado[v])
            {
                // Marca o vértice atual como pai do próximo vértice
                pai[v] = u;
                // Incrementa a contagem de filhos de u
                filhos[u]++;

                // Chamada recursiva para o próximo vértice
                buscaEmProfundidadeParaArticulacoesTarjan(v, visitado, tempoDeDescoberta, menorTempoDeDescoberta, pai, filhos, ref tempo, articulacoes);

                // Atualiza o menor tempo de descoberta do vértice atual com base no filho
                menorTempoDeDescoberta[u] = Math.Min(menorTempoDeDescoberta[u], menorTempoDeDescoberta[v]);

                // Se o vértice u for a raiz e tiver mais de um filho, é uma articulação
                if (pai[u] == null && filhos[u] > 1)
                {
                    articulacoes.Add(u);
                }
                // Se o vértice u não for raiz e o menor tempo de descoberta do v for maior ou igual ao tempo de descoberta de u, é uma articulação
                else if (pai[u] != null && menorTempoDeDescoberta[v] >= tempoDeDescoberta[u])
                {
                    articulacoes.Add(u);
                }

            }
            else if (v != pai[u])
            {
                // Atualiza o menor tempo de descoberta do vértice atual com base em arestas de retorno
                menorTempoDeDescoberta[u] = Math.Min(menorTempoDeDescoberta[u], tempoDeDescoberta[v]);
            }

            arestaAtual = arestaAtual.anterior;
        }
    }

    public bool metodoNaive()
    {
        Vertice verticeAtual = ultimoVerticeAdicionado;

        while (verticeAtual != null)
        {
            Aresta arestaAtual = verticeAtual.arestas;

            while (arestaAtual != null)
            {

                RemoverAresta(arestaAtual.nome);


                if (!simpconexo())
                {

                    adicionarAresta(arestaAtual.nome, arestaAtual.valor, arestaAtual.origem, arestaAtual.destino);
                    return false;
                }


                adicionarAresta(arestaAtual.nome, arestaAtual.valor, arestaAtual.origem, arestaAtual.destino);

                arestaAtual = arestaAtual.anterior;
            }

            verticeAtual = verticeAtual.anterior;
        }

        return true;
    }

    public void naive()
    {
        GrafoDirecionado grafoDasRemocoes = copiarGrafo(this);

        List<Aresta> listaDeArestas = new List<Aresta>();
        adicionarArestasALista(grafoDasRemocoes, listaDeArestas);
        List<Aresta> listaDePontes = new List<Aresta>();

        foreach (Aresta aresta in listaDeArestas)
        {
            grafoDasRemocoes.RemoverAresta(aresta.nome);

            if (!grafoDasRemocoes.semifortConexo())
            {
                // Console.WriteLine(">>>Ponte Encontrada"+aresta.nome);
                listaDePontes.Add(aresta);
            }

            grafoDasRemocoes = copiarGrafo(this);
            //listaDePontes = grafoDasRemocoesDirecionado.encontrarPontes();
        }

        if (listaDePontes.Count() != 0)
        {
            Console.WriteLine("Ponte Encontrada");

            foreach (Aresta ponte in listaDePontes)
            {
                Console.WriteLine("ponte: " + ponte.origem.nome + "->" + ponte.destino.nome);
            }
        }
        else
        {
            Console.WriteLine("Nenhuma Ponte Encontrada");
        }

    }

    public GrafoDirecionado copiarGrafo(GrafoDirecionado grafoASerCopiado)
    {
        GrafoDirecionado grafoCopiado = new GrafoDirecionado();

        Vertice verticeAtual = grafoASerCopiado.ultimoVerticeAdicionado;

        while (verticeAtual != null)
        {
            grafoCopiado.adicionarVertice(verticeAtual.nome, verticeAtual.valor);

            verticeAtual = verticeAtual.anterior;
        }

        verticeAtual = grafoASerCopiado.ultimoVerticeAdicionado;

        while (verticeAtual != null)
        {
            Aresta arestaAtual = verticeAtual.arestas;

            while (arestaAtual != null)
            {
                grafoCopiado.adicionarAresta(arestaAtual.nome, arestaAtual.valor, grafoCopiado.encontrarVertice(arestaAtual.origem.nome), grafoCopiado.encontrarVertice(arestaAtual.destino.nome));
                arestaAtual = arestaAtual.anterior;
            }

            verticeAtual = verticeAtual.anterior;
        }

        return grafoCopiado;
    }

    public void adicionarArestasALista(GrafoDirecionado grafo, List<Aresta> lista)
    {
        Vertice verticeAtual = grafo.ultimoVerticeAdicionado;//pegando vertices do grafo especifico


        while (verticeAtual != null)
        {
            Aresta arestaAtual = verticeAtual.arestas;

            while (arestaAtual != null)
            {
                lista.Add(arestaAtual);
                arestaAtual = arestaAtual.anterior;
            }

            verticeAtual = verticeAtual.anterior;
        }

    }


    public void lerArquivo()
    {
        string caminhoVertices = "grafos_direcionadovertice.csv";
        string caminhoArestas = "grafos_direcionadoaresta.csv";

        StreamReader leitor = new StreamReader(caminhoVertices);
        String linha = leitor.ReadLine();//pula a primeira => colunas
        linha = leitor.ReadLine();
        String[] dados;

        while (linha != null)
        {
            dados = linha.Split(",");

            adicionarVertice(dados[0], dados[1]);

            linha = leitor.ReadLine();
        }

        leitor = new StreamReader(caminhoArestas);
        linha = leitor.ReadLine();//pula a primeira => colunas
        linha = leitor.ReadLine();

        while (linha != null)
        {
            dados = linha.Split(",");

            adicionarAresta("Aresta" + dados[0] + "" + dados[1], dados[2], encontrarVertice(dados[0]), encontrarVertice(dados[1]));

            linha = leitor.ReadLine();
        }

    }

}

