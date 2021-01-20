using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Carta
    {
        private int Id;
        private int Cantidad;
        private string Color;
        private string Forma;
        private string Relleno;

        public Carta(int Id, int Cantidad, string Color, string Forma, string Relleno)
        {
            SetId(Id);
            SetCantidad(Cantidad);
            SetColor(Color);
            SetForma(Forma);
            SetRelleno(Relleno);
        }

        public int GetNumero()
        {
            return Id;
        }

        private void SetId(int Id)
        {
            this.Id = Id;
        }

        public int GetCantidad()
        {
            return Cantidad;
        }

        private void SetCantidad(int Cantidad)
        {
            this.Cantidad = Cantidad;
        }

        public string GetColor()
        {
            return Color;
        }

        private void SetColor(string Color)
        {
            this.Color = Color;
        }
        public string GetForma()
        {
            return Forma;
        }

        private void SetForma(string Forma)
        {
            this.Forma = Forma;
        }

        public string GetRelleno()
        {
            return Relleno;
        }

        private void SetRelleno(string Relleno)
        {
            this.Relleno = Relleno;
        }

        public void MostrarCarta()
        {
            Console.WriteLine("Numero: " + Id);
            Console.WriteLine("Cantidad: " + Cantidad);
            Console.WriteLine("Color: " + Color);
            Console.WriteLine("Relleno : " + Relleno);
            Console.WriteLine("Forma: " + Forma);
            Console.WriteLine("--------------------");
        }

    }
}
