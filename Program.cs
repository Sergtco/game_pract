using Microsoft.Data.Analysis;
using System.Collections.Generic;

namespace game_pract
{
    public class Program
    {
        static Dictionary<string, string> commands = new Dictionary<string, string>
        {
            ["help"] = "get help",
            ["GetAll"] = "get all lines",
            ["AvgPlatSales"] = "average sales by platform"
        };
        public static void Main(string[] args)
        {
            String fn = "./vgsales.csv";
            Parser parser = new Parser(fn);
            if (args.Length != 0)
            {
                try
                {
                    run_command(args, parser);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                list_commands();

            }
        }
        public static void run_command(string[] args, Parser parser)
        {

            switch (args[0])
            {
                case "GetAll":
                    parser.GetAllRows();
                    break;
                case "AvgPlatSales":
                    parser.AvgPlatSales();
                    break;
                default:
                    throw new Exception("Invalid command");

            }
        }
        public static void list_commands()
        {
            foreach (var pair in commands) {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }
}
