using System.Data;

namespace DisignTechniqueHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Greedy greedy = new Greedy(input);

            greedy.OperaterDivision();
            greedy.InsertParentheses();
            greedy.OutPut();

        }
    }
}