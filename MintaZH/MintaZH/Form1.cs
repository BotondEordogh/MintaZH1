using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MintaZH
{
    public partial class Form1 : Form
    {
        List<OlympicResult> results = new List<OlympicResult>(); 
        public Form1()
        {
            InitializeComponent();

            LoadData("Summer_olympic_Medals.csv");
            CreateYearFilter();
        }

        public void LoadData(string fileName)
        {
            using (var sr = new StreamReader(fileName, Encoding.Default))
            {
                sr.ReadLine(); // Az első sort eldobjuk
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(',');
                    var or = new OlympicResult()
                    {
                        Year = int.Parse(line[0]),
                        Country = line[3],
                        Medals = new int[]
                        {
                            int.Parse(line[5]),
                            int.Parse(line[6]),
                            int.Parse(line[7])
                        }
                    };
                    results.Add(or);
                }
            }
        }
        public void CreateYearFilter()
        {
            var years = (from r in results 
                         orderby r.Year 
                         select r.Year).Distinct();
            comboBox1.DataSource = years.ToList();
        }

        private int CalculatePosition
    }
}
