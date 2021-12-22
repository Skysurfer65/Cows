using System;

namespace Cows
{
    class Program
    {

        static void Main(string[] args)
        {
            string input;

            Console.WriteLine("Kor kostar 10 :-\nGrisar kostar 3 :-\nHönor kostar 50 öre");
            Console.WriteLine("Se hur många kombinationer du får om du måste få lika många djur som belopp (heltal), minst ett av varje");
            do
            {
                int cows, pigs, hens;
                int numberOfSolutions = 0;
                int numberOfIterations = 0;
                string text = "";
               

                Console.Write("Ange belopp i hela kronor: ");
                int amount = Input();

                //Räkna ut loop boundaries, det måste gå jämt ut så minst två hönor...
                int maxCows = (amount - 4) / 10;
                int maxPigs = (amount - 11) / 3;
                int maxHens = (int)((amount - 13) / 0.5);

                //Hitta lösning
                for (int i = 1; i <= maxCows; i++)
                {
                    cows = i;

                    for (int j = 1; j <= maxPigs; j++)
                    {
                        pigs = j;

                        for (int k = 1; k <= maxHens; k++)
                        {
                            hens = k;
                            if (cows + pigs + hens == amount && (cows * 10) + (pigs * 3) + (hens * 0.5) == amount)
                            {
                                text += cows + " kor, " + pigs + " grisar och " + hens + " hönor\n";
                                numberOfSolutions++;
                            }
                            numberOfIterations++;
                        }
                    }

                }
                Console.WriteLine("Vi har provat "+ numberOfIterations +" kombinationer\noch hittat "+ numberOfSolutions +" lösning/ar\n" + text);
                Console.Write("\nSkriv \"Q\" för att avsluta programmet eller retur \"Enter\" för att försöka igen: ");
                input = Console.ReadLine();
            } while (!input.ToUpper().Equals("Q"));

        }
        static int Input()
        {
            int amount = 0;
            bool notValid = true;
            do
            {
                try
                {
                    amount = int.Parse(Console.ReadLine());
                    notValid = false;          
                }
                catch (Exception e)
                {
                    Console.Write("Du måste ange ett heltal, försök igen: ");
                }
            } while (notValid);
            return amount;
        }
    }
}
