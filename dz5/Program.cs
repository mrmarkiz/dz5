namespace dz5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int run;
            do
            {
                Console.Write("Enter task to run (0 to exit): ");
                int.TryParse(Console.ReadLine(), out run);
                switch (run)
                {
                    case 1:
                        Task1.Run();
                        break;
                    case 2:
                        Task2.Run();
                        break;
                    case 3:
                        Task3.Run();
                        break;
                    case 4:
                        Task4.Run();
                        break;
                }
            } while (run != 0);
        }
    }
}