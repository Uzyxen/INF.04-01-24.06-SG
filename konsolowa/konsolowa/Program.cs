namespace konsolowa
{
    internal class Program
    {
        static void Main()
        {
            bool playAgain = true;
            while (playAgain)
            {
                Console.Write("Podaj liczbę kostek do rzucenia (3-10): ");

                int numberOfDice;
                while (!int.TryParse(Console.ReadLine(), out numberOfDice) || numberOfDice < 3 || numberOfDice > 10)
                {
                    Console.WriteLine("Nieprawidłowa liczba. Wprowadź liczbę od 3 do 10: ");
                }

                // Rzut kostkami i zapis wyników
                List<int> diceResults = RollDice(numberOfDice);
                DisplayDiceResults(diceResults);

                // Obliczanie punktów
                int points = CalculatePoints(diceResults);
                Console.WriteLine($"Twoje punkty: { points }");

                // Zapytanie o powtórzenie gry
                Console.Write("Czy chcesz zagrać ponownie? (t/n): ");
                string? response = Console.ReadLine();
                playAgain = response.ToLower() == "t";
            }
        }

        static List<int> RollDice(int count)
        {
            Random rand = new Random();
            List<int> results = new List<int>();

            for (int i = 0; i < count; i++)
            {
                results.Add(rand.Next(1, 7));
            }
            return results;
        }

        static void DisplayDiceResults(List<int> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"Kostka {i + 1}: {results[i]}");
            }
        }

        static int CalculatePoints(List<int> results)
        {
            int points = 0;

            // Grupowanie wyników i liczenie punktów dla wartości powtórzonych
            var groupedResults = results.GroupBy(x => x)
                                        .Where(g => g.Count() >= 2); // Tylko liczby, które występują co najmniej 2 razy

            foreach (var group in groupedResults)
            {
                points += group.Key * group.Count();
            }

            return points;
        }
    }
}
