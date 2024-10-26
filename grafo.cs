using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Xml;

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

        //Busca pelo nome e a partir de uma aresta
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

        //Busca pelo nome e em todos os vertices
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

//Quant de vertices do não direcionado (falta direcionado)
         public int ChecarQuantidadedeVert(int numVertices){

        return numVertices;


        }

////Quant de arestas do não direcionado (falta direcionado)
        public int ChecarQuantdeArestas(int numArestas){
 
        return numArestas;
    
        }

// ver se só isso tá certo depois
        public bool vazio(){

        return numArestas == 0;
        
        }

//Verificação de completo, olhando desde o último vértice até o primeiro, se passar a adjacencia por todos, retorna tru
        public bool completo(){


    if (numVertices<2){
      return false;
    }

    Vertice VerticeAtual = ultimoVerticeAdicionado;

    while (VerticeAtual!=null){

    Vertice verticeComparacao = VerticeAtual.anterior;

    while (verticeComparacao !=null){

        if (!adjacenciaEntreVertices(VerticeAtual.nome, verticeComparacao.nome)){

            return false;
        }
        verticeComparacao = verticeComparacao.anterior;
    }
    VerticeAtual = VerticeAtual.anterior;
   }

         return true;

        }




        
//É informado com o número de vértices, no primeiro do while todos os vértices são criados, depois são colocadas as arestas no vértice de origem e de destino, ou não caso digite 3
        public void gerarGrafo(int numVertices)//sendo feito
        {
            int numv=0;

         if (numVertices>=2){   
       do{

        Console.WriteLine("Digite o nome do vértice");
        string _nome = Console.ReadLine();

         Console.WriteLine("Digite o valor do vértice");
        string _valor = Console.ReadLine();

        adicionarVertice( _nome, _valor);

        numv++;

       }while (numv<numVertices);
      }

          int arestas = 0;
          int opcao = 0;
do {
          Console.WriteLine("Adicionar uma aresta? (1 para sim, 2 para não e 3 para parar completamente)");
            opcao = int.Parse(Console.ReadLine());

        if (opcao == 1){
       
       Console.WriteLine("Digite o nome da aresta");
       string nome = Console.ReadLine();

        Console.WriteLine("Digite o valor da aresta");
        string valor = Console.ReadLine();

        Console.WriteLine("Digite o vértice de origem");
        string vertorigem = Console.ReadLine();
        
        Vertice origem = encontrarVertice(vertorigem);

        Console.WriteLine("Digite o vértice de destino");
        string vertdestino = Console.ReadLine();

        Vertice destino = encontrarVertice(vertdestino);

          if (origem != null && destino != null)

            {  

        arestas++;

       if (arestas > 0 && arestas < numVertices)
       {
       adicionarAresta( nome,  valor,  origem,  destino);
         Console.WriteLine("Aresta adicionada");
       } 
       else
            {
                Console.WriteLine("Vértice não encontrado");
            }
        }
        else if (opcao == 2)
        {
            Console.WriteLine("Não adicionar mais arestas");
        }

       }

       } while (opcao != 3);

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


    }}

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

