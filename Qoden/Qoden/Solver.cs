using Qoden.task_1;
using Qoden.task_2;
using Qoden.task_3;

namespace Qoden
{
    internal class Solver
    {
        static void Main(string[] args)
        {
            //TASK 1
            int divider = Int32.Parse(Console.ReadLine());
            int[] values = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            HashTable table = new HashTable(divider);
            for (int i = 0; i < values.Length; i++)
            {
                table.Insert(values[i]);
            }

            table.Print();

            //TASK 2
            string text = Console.ReadLine();
            DiagramManager diagramManager = new DiagramManager(text);
            diagramManager.PrintDiagramm();

            //TASK 3
            var exp = Console.ReadLine();
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Calculate(exp));

        }
    }
}
