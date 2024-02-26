using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedadnoInformadas
{
    using System;
    using System.Collections.Generic;

    public class ArbolBusqueda
    {
        Nodo raiz;
        string objetivo;

        public ArbolBusqueda(Nodo raiz, string objetivo)
        {
            this.raiz = raiz;
            this.objetivo = objetivo;
        }

        // Búsqueda por Anchura
        public void BusquedaPorAnchura()
        {
            Nodo nodoActual = raiz;
            HashSet<string> estadosVisitados = new HashSet<string>();
            Queue<Nodo> estadosPorVisitar = new Queue<Nodo>();

            while (!nodoActual.GetEstado().Equals(objetivo))
            {
                estadosVisitados.Add(nodoActual.GetEstado());
                // Generar a los Nodos Hijos
                HashSet<string> hijos = nodoActual.GeneraHijos();    
                foreach (string hijo in hijos)
                {
                    if (!estadosVisitados.Contains(hijo))
                    {
                        // Crear nuevo Nodo.
                        Nodo nHijo = new Nodo(hijo);
                        nHijo.SetPadre(nodoActual);
                        estadosPorVisitar.Enqueue(nHijo);
                    }
                }
                nodoActual = estadosPorVisitar.Dequeue();
            }
            ImprimeNodos(nodoActual);
            Console.WriteLine("YA SE ENCONTRO EL NODO OBJETIVO");
            nodoActual.ImprimeSolucion();
        }

        // Búsqueda por Profundidad
        public void BusquedaPorProfundidad()
        {
            Nodo nodoActual = raiz;
            HashSet<string> estadosVisitados = new HashSet<string>();
            Stack<Nodo> estadosPorVisitar = new Stack<Nodo>();

            while (!nodoActual.GetEstado().Equals(objetivo))
            {
                estadosVisitados.Add(nodoActual.GetEstado());
                // Generar a los Nodos Hijos
                HashSet<string> hijos = nodoActual.GeneraHijos(); 
                foreach (string hijo in hijos)
                {
                    if (!estadosVisitados.Contains(hijo))
                    {
                        // Crear nuevo Nodo.
                        Nodo nHijo = new Nodo(hijo);
                        nHijo.SetPadre(nodoActual);
                        estadosPorVisitar.Push(nHijo);
                    }
                }
                nodoActual = estadosPorVisitar.Pop();
            }

            ImprimeNodos(nodoActual);
            Console.WriteLine("YA SE ENCONTRO EL NODO OBJETIVO");
            nodoActual.ImprimeSolucion();
        }

        public void ImprimeNodos(Nodo n)
        {
            Nodo nodoActual = n;
            while (!nodoActual.GetEstado().Equals(this.raiz.GetEstado()))
            {
                nodoActual.ImprimeSolucion();
                nodoActual = nodoActual.GetPadre();
            }
            this.raiz.ImprimeSolucion();
        }
        public static string estadoInicial = "12578 346";
        public static string estadoFinal = "12345678 ";

        public static void Main(string[] args)
        {
            // Instanciar el árbol
            ArbolBusqueda a = new ArbolBusqueda(new Nodo(estadoInicial), estadoFinal);
          

           
        }

        // Calcula el valor absoluto de la diferencia del índice del estado contra
        // el objetivo y va acumulando la suma de estos valores
        public int CalculaCostoSuma(string Estado, string Objetivo)
        {
            int costo = 0;
            string estado = Estado.Replace(" ", "0");
            string objetivoS = Objetivo.Replace(" ", "0");
            char[] indicesEstado = estado.ToCharArray();
            char[] indicesObjetivo = objetivoS.ToCharArray();

            for (int i = 0; i < indicesEstado.Length; i++)
            {
                costo += Math.Abs(int.Parse(indicesEstado[i].ToString()) - int.Parse(indicesObjetivo[i].ToString()));
            }

            return costo;
        }

 
    }

}
