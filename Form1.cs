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

                //for (int i = 0; i < pancakes.Count; i++)
                //{
                //    var tempPancakes=ReversePancakesAt(new List <int>(pancakes), i);
                //    currentOperations++;
                //    for(int j = 0; j < tempPancakes.Count; j++)
                //    {
                //        var temp1Pancakes = ReversePancakesAt(new List<int> (tempPancakes), i);
                //        currentOperations++;
                //        for (int k = 0; k < temp1Pancakes.Count; k++)
                //        {
                //            var temp2Pancakes = ReversePancakesAt(new List<int> (temp1Pancakes), i);
                //            currentOperations++;
                //            for (int l = 0; l < temp2Pancakes.Count; l++)
                //            {
                //                var temp3Pancakes = ReversePancakesAt(new List<int> (temp2Pancakes), i);
                //                currentOperations++;
                //                for (int m = 0; m < temp3Pancakes.Count; m++)
                //                {
                //                    var temp4Pancakes = ReversePancakesAt(new List<int> (temp3Pancakes), i);
                //                    currentOperations++;
                //                    for (int n = 0; n < temp4Pancakes.Count; n++)
                //                    {
                //                        var temp5Pancakes = ReversePancakesAt(new List<int> (temp4Pancakes), i);
                //                        currentOperations++;
                //                        if (temp5Pancakes.SequenceEqual(temp5Pancakes.OrderBy(x => x))){
                //                            break;
                //                        }
                //                    }
                //                    if (temp4Pancakes.SequenceEqual(temp4Pancakes.OrderBy(x => x))){
                //                        break;
                //                    }
                //                }
                //                if (temp3Pancakes.SequenceEqual(temp3Pancakes.OrderBy(x => x))){
                //                    break;
                //                }
                //            }
                //            if (temp2Pancakes.SequenceEqual(temp2Pancakes.OrderBy(x => x))){
                //                break;
                //            }
                //        }
                //        if (temp1Pancakes.SequenceEqual(temp1Pancakes.OrderBy(x => x))){
                //            break;
                //        }
                //    }
                SortPancakes(new List<int>(pancakes));
                //    SortPancakes(ReversePancakesAt(pancakes, i));
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
