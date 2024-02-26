using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedadnoInformadas
{
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
                        Nodo nHijo = new(hijo);
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

        public static void Main(string[] args)
        {
            // Instanciar el árbol
            ArbolBusqueda a = new ArbolBusqueda(new Nodo(Nodo.estadoInicial), Nodo.estadoFinal);
            // Llamar a la búsqueda por anchura o por profundidad según sea necesario
             a.BusquedaPorAnchura();
            // a.BusquedaPorProfundidad();
        }
    }

    public class Nodo : IComparable<Nodo>
    {
        private string estado;
        private List<Nodo> hijos;

        public int costo;
        public Nodo padre;

        public Nodo(string estado)
        {
            this.estado = estado;
            hijos = new List<Nodo>();
        }

        public string GetEstado()
        {
            return estado;
        }

        public List<Nodo> GetHijos()
        {
            return hijos;
        }

        // Agrega 1 Nodo hijo
        public void AgregarHijo(Nodo h)
        {
            hijos.Add(h);
        }

        public Nodo GetPadre()
        {
            return padre;
        }

        public void SetPadre(Nodo padre)
        {
            this.padre = padre;
        }

        public HashSet<string> GeneraHijos()
        {
            List<string> hijosGenerados = new List<string>();
            int i = estado.IndexOf(" "); // Obtengo el indice del espacio
            string estadoTemp;
            switch (i)
            {

                case 0:

                    estadoTemp = "" + estado[1] + estado[0] + estado[2] + estado[3] + estado[4] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[3] + estado[1] + estado[2] + estado[0] + estado[4] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);


                    break;
                case 1:
                    estadoTemp = "" + estado[1] + estado[0] + estado[2] + estado[3] + estado[4] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[2] + estado[1] + estado[3] + estado[4] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[4] + estado[2] + estado[3] + estado[1] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);


                    break;
                case 2:
                    estadoTemp = "" + estado[0] + estado[2] + estado[1] + estado[3] + estado[4] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[5] + estado[3] + estado[4] + estado[2] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);


                    break;
                case 3:
                    estadoTemp = "" + estado[3] + estado[1] + estado[2] + estado[0] + estado[4] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[4] + estado[3] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[6] + estado[4] + estado[5] + estado[3] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);


                    break;
                case 4:
                    estadoTemp = "" + estado[0] + estado[4] + estado[2] + estado[3] + estado[1] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[4] + estado[3] + estado[5] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[5] + estado[4] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[7] + estado[5] + estado[6] + estado[4] + estado[8];
                    hijosGenerados.Add(estadoTemp);


                    break;
                case 5:
                    estadoTemp = "" + estado[0] + estado[1] + estado[5] + estado[3] + estado[4] + estado[2] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[5] + estado[4] + estado[6] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[4] + estado[8] + estado[6] + estado[7] + estado[5];
                    hijosGenerados.Add(estadoTemp);

                    break;
                case 6:
                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[6] + estado[4] + estado[5] + estado[3] + estado[7] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[4] + estado[5] + estado[7] + estado[6] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    break;
                case 7:
                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[4] + estado[5] + estado[7] + estado[6] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[7] + estado[5] + estado[6] + estado[4] + estado[8];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[4] + estado[5] + estado[6] + estado[8] + estado[7];
                    hijosGenerados.Add(estadoTemp);
                    break;
                case 8:
                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[4] + estado[5] + estado[6] + estado[8] + estado[7];
                    hijosGenerados.Add(estadoTemp);

                    estadoTemp = "" + estado[0] + estado[1] + estado[2] + estado[3] + estado[4] + estado[8] + estado[6] + estado[7] + estado[5];
                    hijosGenerados.Add(estadoTemp);
                    break;

            }

            HashSet<string> resultado = new HashSet<string>(hijosGenerados);
            return resultado;
        }

        public void ImprimeSolucion()
        {
            Console.WriteLine(GetEstado());
        }

        public int CompareTo(Nodo o)
        {
            return this.costo > o.costo ? 1 : this.costo < o.costo ? -1 : 0;
        }

        public static string estadoInicial = "12578 346";
        public static string estadoFinal = "12345678 ";
    }
}