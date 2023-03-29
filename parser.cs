using Microsoft.Data.Analysis;

namespace game_pract
{
    public class Parser
    {
        string filename;
        DataFrame df;
        

        public Parser(string filename)
        {
            this.filename = filename;
            this.df = DataFrame.LoadCsv(filename);
        }

        public List<string> GetAllRows()
        {
            var rows = this.df.Rows;
            List<string> result = new List<string>();

            Console.WriteLine(df.Head(0));
            foreach (var row in rows) {
                var elm = row.AsEnumerable().ToList();
                string name = (string) elm[1];
                if (name.Length > 50) {
                    name = name.Substring(0, 50);
                    name += "...";
                }
                elm[1] = (object) name;

                Console.WriteLine(String.Format("{1, -60}{2, -5}{3, -5}{4, -20}{5, -30}{6, -6}{7, -6: }{8, -6: 0.0}{9, -6: 0.0}{10, -6: 0.0}", elm.ToArray()));
                result.Add(row.ToString());
            }
            return result;
        }
        public Dictionary<string,double> AvgPlatSales()
        {
            var platforms = this.df.Columns["Platform"].ValueCounts();
            Dictionary<String, double> sales = new Dictionary<String, double>();

            Console.WriteLine(String.Format("{0, -20} {1} in millions", "Platform", "Average Sales"));

            foreach (string platform in platforms.Columns[0])
            {
                var filtered =  df.Filter(df.Columns["Platform"].ElementwiseEquals(platform))["Global_Sales"];
                double sum = 0;
                foreach (string n in filtered) {
                    sum += double.Parse(n, System.Globalization.CultureInfo.InvariantCulture);
                }
                double num = filtered.Length;
                sales.Add(platform, sum / num);
                Console.WriteLine(String.Format("{0, -20} {1: 0.##} M", platform, sales[platform]));
            }
            return sales;

        }
    }
}
