using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace BlackJack
{
    class Baraja
    {
        Cartas tarjeta; // CREO UN OBJETO PARA PODER VINCULAR LA CLASE CARTAS
        Random revolver;
        int victorias, perdidas;
        List<Cartas> misCartas, laBaraja; 
        //UTILIZO LISTAS PARA PODER AÑADIR TODAS LAS CARTAS Y TOMAR LAS QUE ME PERTENECEN 
        Stack<Cartas> Listo;
        // ESTA PILA LLEVA CON SIGO TODA LA BARAJA YA BARAGEADA LISTA PARA INICIAR EL JUEGO 
        public Baraja() // METODO CON LAS FUNCIONES PRINCIPALES PARA BARAJEAR Y LLEVAR EL REGISTRO
        {
            revolver = new Random(); // LO USO PARA DARLE UN NUEVO ORDEN A LAS CARTAS
            victorias = 0;
            perdidas = 0;
        }
        // declaro los parametros para hacer los Atributos publicos y poder MANDAR A LLAMAR AL METODO
        public int Victorias
        {
            get { return victorias; }  set { victorias = value; }
        }
        public int Perdidas 
        {
            get { return perdidas; } set { perdidas = value; }
        }
        // la pila peincipal que me permite ir quitando las cartas usadas 
        public Stack<Cartas> BarajaListsa 
        {
            get { return Listo; }  set { Listo = value; }
        }
        public void Ccreacion() // EN TOTAL SON 52 CARTAS 1
        {
            laBaraja = new List<Cartas>(52);
            for (int primeras = 0; primeras < 13; primeras++) // EL CONTADOR INICIALIZA EN CERO POR LO CUA ARROGARA 13 ELEMENTOS
            {
                tarjeta = new Cartas(); tarjeta.Tipo(primeras, "♥C");
                laBaraja.Add(tarjeta);
                tarjeta = new Cartas(); tarjeta.Tipo(primeras, "♦D");
                laBaraja.Add(tarjeta);
                tarjeta = new Cartas(); tarjeta.Tipo(primeras, "♣T");
                laBaraja.Add(tarjeta);
                tarjeta = new Cartas(); tarjeta.Tipo(primeras, "♠E");
                laBaraja.Add(tarjeta);
            }
        }
        public void Revolver()
        {
            for (int contar = 0; contar < laBaraja.Count; contar++) 
                //TENEIENDO LAS 52 CARTAS DE LA BARAJA INICIAMOS A BARAJEAR LLAMADO AL METODO RANDOM (REVOLVER)
            {
                Cartas dispersion = laBaraja[contar];
                int barajeada = revolver.Next(contar, laBaraja.Count);
                laBaraja[contar] = laBaraja[barajeada];
                laBaraja[barajeada] = dispersion;
            }
            Listo = new Stack<Cartas>();  // inicializo la pila 
            // muestro las cartas que seran asignadas
            foreach (Cartas naipe in laBaraja)
            {
                Listo.Push(naipe);
            }
        }
        // EN ESTE METODO SE INICIA EL JUEGO YA QUE SE COMIENZA LA REPARICION DE LAS CARTAS
        public void Juego()
        {
            misCartas = new List<Cartas>();
            int conteo = 2;
            bool condicion = true;
            string opcion;
            //LAS CARTAS DE LA PILA SON MOSTRADAS AL USUSARIO Y AÑADIDAS A UNA LISTA 
            //ESTO CON EL FIN DE QUE LAS PEIMERAS DOS SEAN QUITADAS DE LA PILA
            misCartas.Add(Listo.Pop());
            misCartas.Add(Listo.Pop());
            int conteoCartas = misCartas[0].Valor + misCartas[1].Valor;
            Console.Write("\n\t\t__________________\n");
            Console.Write("\n\tLA SUMA ES DE   : {0}", conteoCartas);
            do
            {
                // PARA COMENZAR SE DEBEN PASAR POR UNSA SERIE DE CONDICIONES 
                // EL USUARIO DEBE TENER 5 CARTAS COMO MAXIMO 
                //LA SUMA DE LAS CARTAS DEBE SER IGUAL A 21
                //SI ES MAYOR A 21 SE TERMINA EL CICLO
                if (conteo == 5 || conteoCartas > 21 || conteoCartas == 21)
                {
                    condicion = false;
                }
               // DE LO CONTRARIO SI EL MENOR A 21, LA MAQUINA LE SEGURA PREGUNTANDO SI QUIERE OTRA CARTA O ASI SE QUEDA 
                else
                {
                    // IMPRIMIENDO LAS CARTAS QUE LE SON ASIGNADAS
                    Console.Write("\n\tTUS CARTAS :");
                    foreach (Cartas naipe in misCartas)
                    {
                        Console.Write("\n\t " + naipe.caract);
                    }
                    Console.Write("\n\t 1) TOMAR UNA CARTA EXTRA || 2) QUEDASE ASI  : ");
                    opcion = Console.ReadLine();
                    switch (opcion)
                    { // CUANDO DECIDE TOMAR OTRA CARTA, SE AÑADE A PILA
                      //  QUE SE CREO ANTERIOR MENTE PARA GUARDAR SU MANO (CRATAS)
                      // CON LAS PROPIENDADES PODEMOS USAR EL POP PARA IR ELIMINANDO LAS CARTAS USADAS
                        case "1":
                            Console.Write("\n\t>>>CONTINUAS <<<\n");
                            misCartas.Add(Listo.Pop());
                            conteo++;

                            Console.Write("\n\tTU CARTA ES : ");
                            Console.Write(misCartas[conteo - 1].caract);
                            // COMO LA PILA LAS ACOMODAD DE MANERA INVERSA EL CONTADOR DEBE SER -1
                            if (misCartas[conteo - 1].Valor < 11)
                            {
                                conteoCartas = conteoCartas + misCartas[conteo - 1].Valor;
                            }
                            // CUANDO APARECE UN AS EL USUARIO PUEDE ELEGIR EL VALOR MAS FAVORABLE PARA SU JUEGO
                            else
                            {
                                Console.Write("\n\t>>>CONTINUAS <<<\n");
                                Console.Write("\n\tEL AS PUEDE VALER 1 O 11 : ");
                                opcion = Console.ReadLine();
                                switch (opcion)
                                {
                                    case "1":
                                        conteoCartas = conteoCartas + 1;
                                        break;
                                    case "11":
                                        conteoCartas = conteoCartas + 11;
                                        break;
                                    default:
                                        conteoCartas = conteoCartas + 1;
                                        break;
                                }
                            }
                            Console.Write("\n\tLA SUMA ES DE  {0} ", conteoCartas);
                            // CALCULAMOS LA SUMA DE LAS CARTAS QUE LLEVA HASTA EL MOMENTO
                            break;
                        case "2": // SI EL USUARIO DECIDE QUEDARSE ASI AUTOMATICAMENTE CERRARA EL CICLO 
                            condicion = false;
                            break;
                        default:
                            Console.Write("\n\t\aERROR");
                            break;
                    }
                }
            }
            while (condicion == true);
            conteo = revolver.Next(2, 5);
            Console.Write("\n\tTOTAL {0}", conteoCartas);
            Console.Write("\n\t\t__________________\n");
            //SI EL TOTAL DE LAS CARTAS ES IGUAL A 21 O SI JUNTA 5 CARTAS 
            if (conteoCartas == 21 || conteo==5)
            {
                Console.Write("\n\t\a GANASTES !!!  ");
                Console.Write("\n\t\t FELICIDADES.... ");
                victorias++; // LAS VICTORIA SE VAN ANIDANDO PARA LLEVAR EL REGISTRO
            }
            //SI LA SUMA ES MENOR A 21 O MAYOR A EL NO GANA POR QUE COMO ES DE UN SOLO JUAGADOR 
            //A FUERZAS DEBE CUMPLIR CON EL NUMERO 21
            else if (conteoCartas > 21 || conteoCartas < 21)
            {
                Console.Write("\n\t\aSUERTE PARA LA PROXIMA ...");
                Console.Write("\n\t\tSIGUE PARTICIPANDO ... ");
                perdidas++; // LO MISMO CON LAS NO GANADAS

            }
        }
    }
}


        