using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinariodeBusqueda
{
     class Nodo
    {
        public int valor;
        public Nodo izquierdo;
        public Nodo derecho;

        public Nodo(int valor)
        {
            this.valor = valor;
            izquierdo = null;
            derecho = null;
        }
    }
}