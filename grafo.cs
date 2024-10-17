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

    public class Vertice
    {
        public string nome;
        public string valor;

        public Aresta arestas;

        public Vertice proximo;
        public Vertice anterior;

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

        public Aresta(string _nome, string _valor, Vertice _origem, Vertice _destino)
        {
            nome = _nome;
            valor = _valor;
            origem = _origem;
            destino = _destino;
            proxima = null;
            anterior = null;
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
