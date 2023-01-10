using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

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
        public static SortedDictionary<int, List<string>> operations = new SortedDictionary<int, List<string>>();
        async public void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var watch = new System.Diagnostics.Stopwatch();

                watch.Start();

                operations.Clear();

                listBoxOutA.DataSource=null;
                listBoxOutB.DataSource=null;

                string filePath = openFileDialog.FileName;
                List <string> fileContent = File.ReadAllText(filePath).Trim().Split('\n').ToList();

                List<int> pancakes = fileContent.Select(s=> int.Parse(s)).ToList();

                pancakes.RemoveAt(0);

                var task=Task.Run(()=>SortPancakes(new List<int>(pancakes)));

                await task;

                listBoxOutA.DataSource = operations.First().Value;

                watch.Stop();

                lblPWUEOutput.Text=watch.ElapsedMilliseconds.ToString();

                watch.Reset();
            }
        }
        async public static void SortPancakes(List<int> pancakes)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= pancakes.Count; i++)
            {
                Task task;
                List<string> currentOperations = new List<string>();
                var tempPancakes = ReversePancakesAt(new List<int>(pancakes), i);
                currentOperations.Add("Pfannenwender unter Nr. " + pancakes[i - 1] + "! ");
                if (tempPancakes.SequenceEqual(tempPancakes.OrderBy(x => x)))
                {
                    lock (operations)
                    {
                        if (!operations.Keys.Contains(currentOperations.Count))
                        {
                            operations.Add(currentOperations.Count, new List<string>(currentOperations));
                        }
                    }
                    currentOperations.RemoveAt(currentOperations.Count - 1);
                    continue;
                }
                else
                {
                    task=Task.Run(()=>SortPancakes(new List<int>(tempPancakes), new List<string>(currentOperations)));
                    tasks.Add(task);
                }
            }
            await Task.WhenAll(tasks);
        }

        public static void SortPancakes(List<int> pancakes, List<string> currentOperations)
        {
            for (int i = 1; i <= pancakes.Count; i++)
            {
                var tempPancakes = ReversePancakesAt(new List<int>(pancakes), i);
                currentOperations.Add("Pfannenwender unter Nr. " + pancakes[i - 1] + "! ");
                var watch = new System.Diagnostics.Stopwatch();
                
                watch.Start();
                if (tempPancakes.SequenceEqual(tempPancakes.OrderBy(x => x)))
                {
                    lock (operations)
                    {
                        if (!operations.Keys.Contains(currentOperations.Count))
                        {
                            operations.Add(currentOperations.Count, new List<string>(currentOperations));
                        }
                    }
                    currentOperations.RemoveAt(currentOperations.Count - 1);
                    continue;
                }
                else
                {
                    SortPancakes(new List<int>(tempPancakes), currentOperations);
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