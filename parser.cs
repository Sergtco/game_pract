using Microsoft.Data.Analysis;
using System.Collections.Generic;

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
            var rowsLen = this.df.Rows.Count;
            List<string> rows = new List<string>();
            for (int i = 0; i < rowsLen; i++)
            {
                rows.Add(this.df.Rows[i].ToString());
            }
            return rows;
        }
        public void /*Dictionary<String, int>*/ AvgPlatSales()
        {
            var platforms = this.df.Columns["Platform", "Rank"].ValueCounts();
            Dictionary<String, int> sales = new Dictionary<String, int>();
            foreach (string platform in platforms.Columns[0])
            {
                sales[platform] = 
            }
        }
    }
}
