using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Program
    {
        const int CANT_CARTAS_INICIAL = 12;

        private static List<Carta> CartasTotales = new List<Carta>();
        private static List<Carta> CartasMano = new List<Carta>();
        static void Main(string[] args)
        {
            InicializarJuego();
            int[] SetEncontrado = new int [3];
            bool HayAlgunSet = true;
            while (CartasMano.Count >= 3 && HayAlgunSet)
            {

                for (int i = 0; i < CartasMano.Count; i++)
                {
                    CartasMano[i].MostrarCarta();
                }


                SetEncontrado = BuscarSet();
                if (SetEncontrado[0] != -1)
                {
                    Console.WriteLine("-----   EL SET ENCONTRADO ES: ------");
                    CartasMano[SetEncontrado[0]].MostrarCarta();
                    CartasMano[SetEncontrado[1]].MostrarCarta();
                    CartasMano[SetEncontrado[2]].MostrarCarta();
                    SacarCartas(SetEncontrado);
                }
                else
                {
                    Console.WriteLine("----- NO HAY NINGUN SET -----");
                }

                if (!AgregarCartas(3))
                {
                    Console.WriteLine("----- NO HAY MAS CARTAS EN EL MAZO -----");
                    if (SetEncontrado[0] == -1)
                    {
                        HayAlgunSet = false;
                        Console.WriteLine("----- QUEDAN " + CartasMano.Count + " CARTAS EN LA MESA -----");
                        Console.WriteLine("----- MANO TERMINADA -----");
                        Console.WriteLine("----- FIN DEL JUEGO -----");
                    }

                }

                if (HayAlgunSet)
                {
                    Console.WriteLine("----- QUEDAN " + CartasMano.Count + " CARTAS EN LA MESA -----");
                    Console.WriteLine("----- MANO TERMINADA -----\n\n\n");
                }

            }
                
        }

        static void InicializarJuego()
        {
            Carta c; 
            int IdCarta = 0;
            int[] cantidades = { 1, 2, 3 };
            string[] colores = { "rojo", "verde", "violeta" };
            string[] rellenos = { "rayado", "solido", "vacio" };
            string[] formas = { "cuadrado", "triangulo", "circulo" };

            for (int i = 0; i < cantidades.Length; i++)
            {
                for (int j = 0; j < colores.Length; j++)
                {
                    for (int k = 0; k < formas.Length; k++)
                    {
                        for (int l = 0; l < rellenos.Length; l++)
                        {
                            IdCarta++;
                            c = new Carta(IdCarta, cantidades[i], colores[j], formas[k], rellenos[l]);
                            CartasTotales.Add(c);
                        }
                    }
                }
            }
            AgregarCartas(CANT_CARTAS_INICIAL);
        }

        static bool AgregarCartas(int Cantidad) 
        {
            bool PudeAgregar = false;
            if(Cantidad <= CartasTotales.Count)
            {
                Random Random = new Random();
                int IdCarta;
                for(int i=0; i<Cantidad; i++)
                {
                    IdCarta = Random.Next(0, CartasTotales.Count - 1);
                    Carta c = CartasTotales[IdCarta];
                    CartasMano.Add(c);
                    CartasTotales.RemoveAt(IdCarta);
                }
                PudeAgregar = true;
                Console.WriteLine("---- SE HAN AGREGADO " + Cantidad + " CARTAS MAS ----");
            }
            return PudeAgregar;
        }

        static void SacarCartas(int[] CartasASacar)
        {
            for (int i = CartasASacar.Length-1; i >= 0; i--)
            {
                CartasMano.RemoveAt(CartasASacar[i]);
            }
            Console.WriteLine("---- SE HAN QUITADO " + CartasASacar.Length + " CARTAS ----");
        }

        static bool SonTodosIguales(int num1, int num2, int num3)
        {
            return num1==num2 && num2==num3;
        }

        static bool SonTodosIguales(string txt1, string txt2, string txt3)
        {
            return txt1 == txt2 && txt2 == txt3;
        }
        static bool SonTodosDistintos(int num1, int num2, int num3)
        {
            return num1 != num2 && num1 != num3 && num2 != num3;
        }

        static bool SonTodosDistintos(string txt1, string txt2, string txt3)
        {
            return txt1 != txt2 && txt1 != txt3 && txt2 != txt3;
        }

        static bool EsSet(Carta carta1, Carta carta2, Carta carta3)
        {
            bool esSet = false, rellenoIguales, rellenoDistintos, formaIguales, formaDistintos, cantidadIguales, cantidadDistintas, colorIguales, colorDistintos;

            rellenoIguales = SonTodosIguales(carta1.GetRelleno(), carta2.GetRelleno(), carta3.GetRelleno());
            rellenoDistintos = SonTodosDistintos(carta1.GetRelleno(), carta2.GetRelleno(), carta3.GetRelleno());
            formaIguales = SonTodosIguales(carta1.GetForma(), carta2.GetForma(), carta3.GetForma());
            formaDistintos = SonTodosDistintos(carta1.GetForma(), carta2.GetForma(), carta3.GetForma());
            cantidadIguales = SonTodosIguales(carta1.GetCantidad(), carta2.GetCantidad(), carta3.GetCantidad());
            cantidadDistintas = SonTodosDistintos(carta1.GetCantidad(), carta2.GetCantidad(), carta3.GetCantidad());
            colorIguales = SonTodosIguales(carta1.GetColor(), carta2.GetColor(), carta3.GetColor());
            colorDistintos = SonTodosDistintos(carta1.GetColor(), carta2.GetColor(), carta3.GetColor());

            if ((rellenoIguales && formaIguales && colorIguales && cantidadDistintas)
                ||(rellenoIguales && formaIguales && colorDistintos && cantidadIguales)
                ||(rellenoIguales && formaIguales && colorDistintos && cantidadDistintas)
                ||(rellenoIguales && formaDistintos && colorIguales && cantidadIguales)
                ||(rellenoIguales && formaDistintos && colorIguales && cantidadDistintas)
                ||(rellenoIguales && formaDistintos && colorDistintos && cantidadIguales)
                ||(rellenoIguales && formaDistintos && colorDistintos && cantidadDistintas)
                ||(rellenoDistintos && formaIguales && colorIguales && cantidadIguales)
                ||(rellenoDistintos && formaIguales && colorIguales && cantidadDistintas)
                ||(rellenoDistintos && formaIguales && colorDistintos && cantidadIguales)
                ||(rellenoDistintos && formaIguales && colorDistintos && cantidadDistintas)
                ||(rellenoDistintos && formaDistintos && colorIguales && cantidadIguales)
                ||(rellenoDistintos && formaDistintos && colorIguales && cantidadDistintas)
                ||(rellenoDistintos && formaDistintos && colorDistintos && cantidadIguales)
                ||(rellenoDistintos && formaDistintos && colorDistintos && cantidadDistintas)
                )
            {
                esSet = true;
            }

            return esSet;
        }
        static int[] BuscarSet() //Busca entre las cartas de la mano algún set (modo autojuego)
        {
            int valorMaximoK = CartasMano.Count;
            int valorMaximoJ = valorMaximoK - 1;
            int valorMaximoI = valorMaximoJ - 1;
            int i = 0;
            int j = i + 1;
            int k = j + 1;
            int[] SetEncontrado = { -1, -1, -1 };
            bool encontre = false;
            while (i < valorMaximoI && !encontre)
            {
                while (j < valorMaximoJ && !encontre)
                {
                    while (k < valorMaximoK && !encontre)
                    {
                        encontre = EsSet(CartasMano[i], CartasMano[j], CartasMano[k]);
                        if (encontre)
                        {
                            SetEncontrado[0] = i;
                            SetEncontrado[1] = j;
                            SetEncontrado[2] = k;
                        }
                        k++;
                    }
                    j++;
                    k = j + 1;
                }
                i++;
                j = i + 1;
            }
            return SetEncontrado;
        }
    }
}
