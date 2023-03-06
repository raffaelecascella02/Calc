using System;

namespace Calcolatrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int scelta = 0;
            int exit = 0;

            while (exit == 0)
            {
                StampaIstruzioni();

                switch (Scelta())
                {
                    case 1: //somma

                        Console.WriteLine("\tSOMMA DI DUE VALORI\n");
                        Somma(RetrieveNum(), RetrieveNum());
                        break;

                    case 2: //differenza

                        Console.WriteLine("\tDIFFERENZA DI DUE VALORI\n");
                        Differenza(RetrieveNum(), RetrieveNum());
                        break;

                    case 3: //prodotto

                        Console.WriteLine("\tPRODOTTO TRA DUE VALORI\n");
                        Prodotto(RetrieveNum(), RetrieveNum());
                        break;

                    case 4: //quoziente

                        Console.WriteLine("\tQUOZIENTE DI DUE VALORI\n");
                        Quoziente(RetrieveNum(), RetrieveNum());
                        break;

                    case 5: //quadrato

                        Console.WriteLine("\tQUADRATO DI UN VALORE\n");
                        Quadrato(RetrieveNum());
                        break;

                    case 6: //cubo

                        Console.WriteLine("\tCUBO DI UN VALORE\n");
                        Cubo(RetrieveNum());
                        break;

                    default:
                        Console.WriteLine("Inserimento imprevisto");
                        break;
                }

                Console.WriteLine("\nCONTINUARE (0) o USCIRE (1)?");
                Console.Write("Risposta -> ");


                /*=================================
                 * CONTROLLO SUL VALORE DI USCITA
                 *================================*/
                while (true)
                {
                    try
                    {
                        exit = Convert.ToInt32(Console.ReadLine());
                        if (exit != 0 && exit != 1)
                        {
                            Console.WriteLine("Errore di inserimento");
                            Console.Write("Reinserire, prego: ");
                            exit = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Inserimento errato: {e}");
                    }
                    break;
                }
            }
        }

        /*===============
         * OPERATORI
         *===============*/

        static void Somma (double num1, double num2)
        {
            double somma = num1 + num2;
            Console.WriteLine($"La SOMMA vale: {somma}");
        }

        static void Differenza (double num1, double num2)
        {
            double differenza = num1 - num2;
            Console.WriteLine($"La DIFFERENZA vale: {differenza}");
        }

        static void Prodotto (double num1, double num2)
        {
            double prodotto = num1 * num2;
            Console.WriteLine($"Il PRODOTTO vale: {prodotto}");
        }

        static void Quoziente (double num1, double num2)
        {
            double quoziente;
            while (true)
            {
                try
                {
                    quoziente = num1 / num2;
                    Console.WriteLine($"Il QUOZIENTE vale: {quoziente}");                    
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine($"Inserimento errato:\n \"{e}\"\n");
                }
                break;
            }
        }

        static void Quadrato (double num)
        {
            double quadrato = num * num;
            Console.WriteLine($"Il QUADRATO vale: {quadrato}");
        }

        static void Cubo (double num)
        {
            double cubo = num * num * num;
            Console.WriteLine($"Il CUBO vale: {cubo}");
        }
        /*===================
         * STAMPA ISTRUZIONI
         *=================*/

        static void StampaIstruzioni()
        {
            Console.Clear();
            Console.WriteLine("Scegli l'operazione scrivendo il numero equivalente:");
            Console.WriteLine("1. SOMMA\n" +
                              "2. DIFFERENZA\n" +
                              "3. PRODOTTO\n" +
                              "4. QUOZIENTE\n" +
                              "5. QUADRATO\n" +
                              "6. CUBO");
        }

        static int Scelta()
        {

            int scelta;
            Console.Write("\nScelta -> ");
            scelta = Convert.ToInt32(Console.ReadLine());
            return scelta;
        }


        /*=================
         * LETTURA VALORI
         *================*/

        static double RetrieveNum()
        {
            string? numero;
            double num = 0;
            while (true)
            {
                Console.Write("Inserisci valore -> ");
                try
                {
                    numero = Console.ReadLine();
                    num = Double.Parse(numero);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Inserimento errato:\n \"{e}\" \n");
                }
                break;
            }
            return num;
        }

        /*============
         * (EXIT)
         *===========*/
        


        //============================================================
    }
}