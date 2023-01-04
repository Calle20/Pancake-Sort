using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Pancake_Sort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBoxOutA.Items.Clear();
            listBoxOutB.Items.Clear();
        }
        public static List<List<string>> operations = new List<List<string>>();
        public static List <string> currentOperations= new List<string>();
        public void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string[] newLines = { Environment.NewLine.ToString() };
                List <string> fileContent = File.ReadAllText(filePath).Trim().Split(newLines,StringSplitOptions.RemoveEmptyEntries).ToList();

                List<int> pancakes = fileContent.Select(s=> int.Parse(s)).ToList();

                pancakes.RemoveAt(0);

                SortPancakes(new List<int>(pancakes));

                listBoxOutA.DataSource = operations;
            }
        }
        public static void SortPancakes(List<int> pancakes)
        {
            for (int i = 1; i <= pancakes.Count; i++)
            {
                var tempPancakes = ReversePancakesAt(new List<int>(pancakes), i);
                currentOperations.Add("PW in "+i+"! ");
                if (tempPancakes.SequenceEqual(tempPancakes.OrderBy(x=>x)))
                {
                    operations.Add(new List<string>(currentOperations));
                    currentOperations.RemoveAt(currentOperations.Count - 1);
                    continue;
                }
                else
                {
                    SortPancakes(new List<int>(tempPancakes));
                }
            }
            if (currentOperations.Count != 0)
            {
                currentOperations.RemoveAt(currentOperations.Count - 1);
            }
        }

        public static List<int> ReversePancakesAt(List<int> pancakes, int index)
        {
            pancakes.Reverse(0, index);
            pancakes.RemoveAt(0);
            return pancakes;
        }
    }
}
