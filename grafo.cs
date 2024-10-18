using System;

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

        public void removerVertice(string _nome)
        {
            Vertice alvo = buscarVertice(_nome, ultimoVerticeAdicionado);
            if (alvo != null)
            {
                while (alvo.arestas != null)
                {
                    Console.WriteLine("removido " + alvo.arestas.nome);
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
                        else{
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
                        else{
                            alvo.destino.arestasQueChegam = null;
                        }
                    }
                    alvo.anteriorNoDestino = null;
                    alvo.proximoNoDestino = null;

                    numArestas--;
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
    }
}
