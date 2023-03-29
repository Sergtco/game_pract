using Microsoft.Data.Analysis;

namespace game_pract
{
    public class Program
    {
        public static void Main(string[] args)
        {
            String fn = "./correct.csv";
            Parser parser = new Parser(fn);
            parser.AvgPlatSales();
        }
    }
}
