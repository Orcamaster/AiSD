namespace PD1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[] SortArray(int[] NumArray)
        {
            var n = NumArray.Length;

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (NumArray[j] > NumArray[j + 1])
                    {
                        var tempVar = NumArray[j];
                        NumArray[j] = NumArray[j + 1];
                        NumArray[j + 1] = tempVar;
                    }

            return NumArray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userInput = textBox1.Text;
            string[] stringList = userInput.Split(' ');
            int[] numberList = new int[stringList.Count()];

            for (int i = 0; i < stringList.Count(); i++)
            {
                numberList[i] = Int32.Parse(stringList[i]);
            }

            if (numberList.Count() > 0)
            {
                int[] bubbleSortedList = SortArray(numberList);
                string sortedString = string.Join(" ", bubbleSortedList);
                label1.Text = sortedString;
            }
            else
            {
                MessageBox.Show("ZLE!!!!!!!!!!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
