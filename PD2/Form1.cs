using System.Collections.Concurrent;

namespace PD2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] numbers = GetInput(textBox1.Text);

            QuickSort(numbers, 0, numbers.Length - 1);
            string sorted = string.Join(", ", numbers);
            label1.Text = $"{sorted}";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int[] numbers = GetInput(textBox1.Text);

            MergeSort(numbers, 0, numbers.Length - 1);
            string sorted = string.Join(", ", numbers);
            label1.Text = $"{sorted}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] numbers = GetInput(textBox1.Text);

            InsertSort(numbers);
            string sorted = string.Join(", ", numbers);
            label1.Text = $"{sorted}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] numbers = GetInput(textBox1.Text);

            numbers = CountingSort(numbers);
            string sorted = string.Join(", ", numbers);
            label1.Text = $"{sorted}";
        }

        private int[] GetInput(string input)
        {
            string[] stringList = input.Split(' ');
            int[] numbers = new int[stringList.Count()];

            for (int i = 0; i < stringList.Count(); i++)
            {
                numbers[i] = Int32.Parse(stringList[i]);
            }

            return numbers;
        }

        private void QuickSort(int[] list, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(list, low, high);
                QuickSort(list, low, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, high);
            }
        }

        private int Partition(int[] list, int low, int high)
        {
            int pivot = list[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    int temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            int temp1 = list[i + 1];
            list[i + 1] = list[high];
            list[high] = temp1;

            return i + 1;
        }

        private void MergeSort(int[] list, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(list, left, middle);
                MergeSort(list, middle + 1, right);
                Merge(list, left, middle, right);
            }
        }

        private void Merge(int[] list, int left, int middle, int right)
        {
            int num1 = middle - left + 1;
            int num2 = right - middle;
            int[] leftList = new int[num1];
            int[] rightList = new int[num2];

            Array.Copy(list, left, leftList, 0, num1);
            Array.Copy(list, middle + 1, rightList, 0, num2);

            int i = 0, j = 0;
            int k = left;

            while (i < num1 && j < num2)
            {
                if (leftList[i] <= rightList[j])
                {
                    list[k] = leftList[i];
                    i++;
                }
                else
                {
                    list[k] = rightList[j];
                    j++;
                }
                k++;
            }

            while (i < num1)
            {
                list[k] = leftList[i];
                i++;
                k++;
            }

            while (j < num2)
            {
                list[k] = rightList[j];
                j++;
                k++;
            }
        }

        public void InsertSort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                int key = list[i];
                int j = i - 1;

                while (j >= 0 && list[j] > key)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = key;
            }
        }

        private int[] CountingSort(int[] list)
        {
            int max = list.Max();
            int[] count = new int[max + 1];

            for (int i = 0; i < list.Length; i++)
            {
                count[list[i]]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            int[] result = new int[list.Length];

            for (int i = list.Length - 1; i >= 0; i--)
            {
                result[count[list[i]] - 1] = list[i];
                count[list[i]]--;
            }

            return result;
        }
    }
}
