using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace BlackJack
{
    class Cartas
    {
        string caracter; int valor;
        // contructor por defecto sin sobrecarga
        public Cartas() { } 
        // declaramos un atributo valor 
        public int Valor 
        {
            get { return valor; } set { valor = value; }
        }
        // artributo caracter
        public string caract 
        {
            get { return caracter; } set { caracter = value; }
        }
        public void Tipo(int NumeroCarta, string TipoDeCarta)
        {
            if (NumeroCarta < 9) // son 8 carats de numero y 4 con un caracter 
            {
                valor = NumeroCarta + 2;
                caracter = (NumeroCarta + 2) + " " + TipoDeCarta;
            }
            else
            {   // cuando el numero de cartas es mayor a nueve 
                //se le asigna un valor especifico con una simpologia propia 
                switch (NumeroCarta)
                {
                    case 9:
                        valor = 10;
                        caracter = "J " + TipoDeCarta;
                        break;
                    case 10:
                        valor = 10;
                        caracter = "Q " + TipoDeCarta;
                        break;
                    case 11:
                        valor = 10;
                        caracter = "K " + TipoDeCarta;
                        break;
                    case 12:
                        valor = 11;
                        caracter = "A " + TipoDeCarta;
                        break;
                }
            }
        }
    }
}
   

