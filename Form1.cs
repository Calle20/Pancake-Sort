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
using System.Collections;

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
        public static List<string> operations = new List<string>();
        public static string currentOperations="";
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
                SortPancakes(pancakes);
                    //    SortPancakes(ReversePancakesAt(pancakes, i));
                listBoxOutA.DataSource = operations;
            }
        }
        public static void SortPancakes(List<int> pancakes)
        {
            for (int i = 0; i < pancakes.Count; i++)
            {
                var tempPancakes = ReversePancakesAt(new List<int>(pancakes), i);
                currentOperations+="PW in "+i+"! ";
                if (tempPancakes.SequenceEqual(tempPancakes.OrderBy(x => x)))
                {
                    operations.Add(currentOperations);
                    currentOperations = "";
                    return;
                }
                SortPancakes(tempPancakes);
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
