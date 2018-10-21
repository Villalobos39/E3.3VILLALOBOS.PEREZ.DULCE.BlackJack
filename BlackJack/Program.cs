using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Baraja baraja = new Baraja(); 
            // CREO EL OBJETO DE LA CLASE PARA MANDAR A LLAMAR A LOS METODOS     
            string opcion; // VARIABLE PARA VALIDAR LOS CASOS
            baraja.Ccreacion();       
            do
            {
                try
                {
                    // CUANDO INICIA EL JUEGO EL PROGRAMA LE PREGUNTA AL USUARIO SI DESEA COMENZAR O SALIR 
                    Console.Write("\n\tBLACK JACK 21 \n\tJUEGOS : GANADOS: {0} || PERDIDOS: {1} ", baraja.Victorias, baraja.Perdidas);
                    // COMO TAMBIEN SE MUESTRA EL REGISTRO DE JAGADAS MARCANDO VICTORIA O NO GANADAS
                    Console.Write("\n\t1)COMENZAR || 2)ABANDONAR PARTIDA : ");
                    opcion = Console.ReadLine();       
                    
                    switch (opcion) // AQUI SE RECIBE LA OPCION QUE EL USUARIO INGRESO 
                    {
                        case "1":
                            // AL COMENZAR EL JUGUEGO LOS PROCESOS LOGICOS COMIENZAN 
                            baraja.Ccreacion();
                            Console.Write("\tBARAJEADA"); 
                            baraja.Revolver(); baraja.Revolver();
                            // TANTO EL REVOLVER LA BARAJA COMO LA CREACCION DE ELLA 
                            Console.Write("\n\t>>>INICIANDO<<<");                       
                            // Y ASI SE DA COMIENZO AL JUEGO DONDE SE LE ASIGNAN DOS CARTAS AL USUARIO
                            baraja.Juego();
                            break;
                     
                        case "2":
                            Console.Write("\n\tSALIR\n");
                            Environment.Exit(0); //TERMINA EL PROCESO Y PERMITE LA SALIDA DEL PROGRAMA
                            break;
                        default:
                            Console.Write("\a\n\tERROR");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Write("\n\t\aERROR REINICIAR");
                }
                Console.Write("\n\t\aREINICIAR (SI || NO): ");
                opcion = Console.ReadLine();       
                Console.Clear(); //CORRA LOS DATOS QUE NOS MUESTRAS ANTERIORMENTE
            } while (opcion == "si" || opcion=="SI");
            Console.ReadKey();
        }
    }
}

  


  