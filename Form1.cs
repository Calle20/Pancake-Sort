using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
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
        public static SortedDictionary<int, List<string>> operationsA = new SortedDictionary<int, List<string>>();
        public static SortedDictionary<int,SortedDictionary<int, int>> operationsB = new SortedDictionary<int,SortedDictionary<int, int>>();
        public static List<string> currentOperationsA = new List<string>();
        public static Dictionary <int,int> currentOperationsB = new Dictionary<int, int>();
        async public void btnOpen_Click(object sender, EventArgs e)
        {
            listBoxOutA.DataSource = currentOperationsA;
            listBoxOutB.DataSource = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                btnOpen.Enabled = false;
                string filePath = openFileDialog.FileName;
                List <string> fileContent = File.ReadAllText(filePath).Trim().Split('\n').ToList();

                List<int> pancakes = fileContent.Select(s=> int.Parse(s)).ToList();

                pancakes.RemoveAt(0);

                await Task.Run(() => SortPancakesA(new List<int>(pancakes)));
                btnOpen.Enabled = true;
                listBoxOutA.DataSource = operationsA.First().Value;

                operationsA.Clear();
                currentOperationsA.Clear();
                progressBar.Style=ProgressBarStyle.Blocks;
            }
        }
        async private void btnCalc_Click(object sender, EventArgs e)
        {
            int[] index = new int[2];
            index[0] = 0;
            index[1] = 0;
            listBoxOutB.DataSource = null;
            int n = int.Parse(txtNInput.Text);
            List<List<int>> allPancakes = GenerateAllPermutations(n);
            for (int i = 0; i < allPancakes.Count; i++) {
                operationsB.Add(i, new SortedDictionary<int, int>());
                currentOperationsB.Add(i, 0);
                await SortPancakesB(allPancakes[i], i);
                if ((index[1] != 0 && index[1] < operationsB[i].First().Key)|| index[1] ==0)
                {
                    index[0]= i;
                    index[1] = operationsB[i].First().Key;
                }
            }
            listBoxOutB.DataSource = allPancakes[operationsB[index[0]].First().Key];
            lblPWUEOutput.Text = operationsB[index[0]].First().Key.ToString();
            operationsB.Clear();
            currentOperationsB.Clear();
        }
        private void txtNInput_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtNInput.Text, out int result) && result>2)
            {
                btnCalc.Enabled = true;
            }
            else
            {
                btnCalc.Enabled = false;
            }
        }
        async public static Task SortPancakesA(List<int> pancakes)
        {
            for (int i = pancakes.Count; i != 0; i--)
            {
                var tempPancakes = ReversePancakesAt(new List<int>(pancakes), i);
                currentOperationsA.Add("Unter Größe " + pancakes[i - 1] + " an Stelle "+i+"! ");
                if (operationsA.Count != 0 && currentOperationsA.Count >= operationsA.First().Key)
                {
                    if (currentOperationsA.Count >= 2)
                    {
                        currentOperationsA.RemoveAt(currentOperationsA.Count - 1);
                        currentOperationsA.RemoveAt(currentOperationsA.Count - 1);
                    }
                    return;
                }
                if (tempPancakes.SequenceEqual(tempPancakes.OrderBy(x => x)))
                {
                    if (!operationsA.Keys.Contains(currentOperationsA.Count))
                    {
                        operationsA.Add(currentOperationsA.Count, new List<string>(currentOperationsA));
                    }
                    currentOperationsA.RemoveAt(currentOperationsA.Count - 1);
                }
                else
                {
                    await SortPancakesA(new List<int>(tempPancakes));
                }
            }
            if (currentOperationsA.Count != 0)
            {
                currentOperationsA.RemoveAt(currentOperationsA.Count - 1);
            }
        }
        async public static Task SortPancakesB(List<int> pancakes, int index)
        {
            for (int i = pancakes.Count; i != 0; i--)
            {
                var tempPancakes = ReversePancakesAt(new List<int>(pancakes), i);
                currentOperationsB[index]++;
                if (operationsB[index].Count != 0 && currentOperationsB[index] >= operationsB[index].First().Key)
                {
                    if (currentOperationsB[index] >= 2)
                    {
                        currentOperationsB[index] -= 2;
                    }
                    return;
                }
                if (tempPancakes.SequenceEqual(tempPancakes.OrderBy(x => x)))
                {
                    if (!operationsB[index].Keys.Contains(currentOperationsB[index]))
                    {
                        operationsB[index].Add(currentOperationsB[index], currentOperationsB[index]);
                    }
                    currentOperationsB[index]--;
                }
                else
                {
                    await SortPancakesB(new List<int>(tempPancakes), index);
                }
            }
            if (currentOperationsB[index] != 0)
            {
                currentOperationsB[index]--;
            }
        }
        public static List<int> ReversePancakesAt(List<int> pancakes, int index)
        {
            pancakes.Reverse(0, index);
            pancakes.RemoveAt(0);
            return pancakes;
        }
        static List<List<int>> GenerateAllPermutations(int n)
        {
            List<List<int>> permutations = new List<List<int>>();
            List<int> numbers = Enumerable.Range(1, n).ToList();
            GeneratePermutations(numbers, new List<int>(), permutations, n);
            permutations=RemoveOrderedLists(permutations);
            return permutations;
        }

        private static List<List<int>> RemoveOrderedLists(List<List<int>> permutations)
        {
            permutations.RemoveAt(0);
            permutations.RemoveAt(permutations.Count - 1);
            return permutations;
        }

        static void GeneratePermutations(List<int> numbers, List<int> currentPermutation, List<List<int>> permutations, int n)
        {
            if (currentPermutation.Count == n)
            {
                permutations.Add(currentPermutation);
                return;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> newNumbers = new List<int>(numbers);
                newNumbers.RemoveAt(i);
                List<int> newPermutation = new List<int>(currentPermutation);
                newPermutation.Add(numbers[i]);
                GeneratePermutations(newNumbers, newPermutation, permutations, n);
            }
        }
    }
}