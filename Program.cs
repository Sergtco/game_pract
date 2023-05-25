using Microsoft.Data.Analysis;
using System.Collections.Generic;

namespace game_pract
{
    public class Program
    {
        // Dictionary with commands and their discriptions
        static Dictionary<string, string> commands = new Dictionary<string, string>
        {
            ["help"] = "get help",
            ["GetAll"] = "get all lines",
            ["AvgPlatSales"] = "average sales by platform",
            ["TopTen"] = "show top ten games",
            ["ByGenre"] = "show games by typed genre",
            ["ByPublisher"] = "show games by certain publisher",
            ["GamesRatio"] = "show distribution of games by genre",
            ["GenresByPublisher"] = "show percentage of all games of different genres of the specified publisher",
            ["SalesByRegion"] = "show percentage of sales of games of each genre in different regions of the total number of sales"
        };
        public static void Main(string[] args)
        {
            String fn = "./vgsales.csv";
            Parser parser = new Parser(fn);
            // Passing args
            if (args.Length != 0)
            {
                try
                {
                    run_command(args, parser);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Available commands:");
                    list_commands();
                }
            }
            else
            {
                list_commands();

            }

        }
        public static void run_command(string[] args, Parser parser)
        {
            // Run commands
            switch (args[0])
            {
                case "GetAll":
                    parser.GetAllRows();
                    break;
                case "AvgPlatSales":
                    parser.AvgPlatSales();
                    break;
                case "TopTen":
                    parser.TopTenGames();
                    break;
                case "ByGenre":
                    parser.ShowThisGenreGames();
                    break;
                case "ByPublisher":
                    parser.GetCertainGames();
                    break;
                case "GamesRatio":
                    parser.GamesRatio();
                    break;
                case "SalesByRegion":
                    parser.SalesByRegion();
                    break;
                case "GenresByPublisher":
                    parser.GenresByPublisher();
                    break;
                case "help":
                    list_commands();
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