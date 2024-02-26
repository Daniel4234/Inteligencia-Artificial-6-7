using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinariodeBusqueda
{
    internal class Arbol
    {
        private Nodo raiz;

        public Arbol()
        {
            raiz = null;
        }

        public bool Vacio()
        {
            return raiz == null;
        }

        public Nodo BuscarNodo(int valor)
        {
            return BuscarNodoRec(raiz, valor);
        }

        private Nodo BuscarNodoRec(Nodo nodo, int valor)
        {
            if (nodo == null || nodo.valor == valor)
            {
                return nodo;
            }

            if (valor < nodo.valor)
            {
                return BuscarNodoRec(nodo.izquierdo, valor);
            }
            else
            {
                return BuscarNodoRec(nodo.derecho, valor);
            }
        }

        public void Insertar(int valor)
        {
            raiz = InsertarRec(raiz, valor);
        }

        private Nodo InsertarRec(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                nodo = new Nodo(valor);
                return nodo;
            }

            if (valor < nodo.valor)
            {
                nodo.izquierdo = InsertarRec(nodo.izquierdo, valor);
            }
            else if (valor > nodo.valor)
            {
                nodo.derecho = InsertarRec(nodo.derecho, valor);
            }

            return nodo;
        }

        public void ImprimirEnOrden()
        {
            ImprimirEnOrdenRec(raiz);
        }

        private void ImprimirEnOrdenRec(Nodo nodo)
        {
            if (nodo != null)
            {
                ImprimirEnOrdenRec(nodo.izquierdo);
                Console.Write(nodo.valor + " ");
                ImprimirEnOrdenRec(nodo.derecho);
            }
        }

        public static void Main(string[] args)
        {
            Arbol arbol = new Arbol();

            arbol.Insertar(50);
            arbol.Insertar(30);
            arbol.Insertar(20);
            arbol.Insertar(40);
            arbol.Insertar(70);
            arbol.Insertar(60);
            arbol.Insertar(80);

            Console.WriteLine("Recorrido en orden del árbol: ");
            arbol.ImprimirEnOrden();

            Console.WriteLine("\n¿El árbol está vacío? " + arbol.Vacio());

            Nodo nodoBuscado = arbol.BuscarNodo(30);
            if (nodoBuscado != null)
            {
                Console.WriteLine("Se encontró el nodo con valor " + nodoBuscado.valor);
            }
            else
            {
                Console.WriteLine("No se encontró el nodo buscado");
            }
        }
    }
    }
