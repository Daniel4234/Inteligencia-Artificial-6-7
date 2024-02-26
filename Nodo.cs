using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedadnoInformadas
{
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
                /*
                Usar los métodos: Replace, CharAt
                Otra idea es pasar el String a Matriz, hacer los cambios y luego pasarlo a String... xD		
                */
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


        public void ImprimeSolucion()//Parametros????
        {
            Console.WriteLine(GetEstado());
        }

        public int CompareTo(Nodo o)
        {
            return this.costo > o.costo ? 1 : this.costo < o.costo ? -1 : 0;
        }
    }
    }
