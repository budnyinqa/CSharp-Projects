using System;
using System.Drawing;
using System.Windows.Forms;

namespace Currency_Converter
{
    public partial class Form1 : Form
    {
        private bool isInitializing = true;
        private readonly decimal[,] exchange_rate = new decimal[,] // 2D array storing exchange rates between different currencies
        {
            {1.0m, 4.25126m, 1.03717m},
            {0.235224m, 1.0m, 0.243978m},
            {0.964161m, 4.10505m, 1.0m}
        };
        public Form1()
        {
            InitializeComponent();

            EnterAmount.Text = "1"; // Sets default value for the amount input
            From.SelectedIndex = 1; // Select the second currency by default
            To.SelectedIndex = 0; // Select the first currency by default

            AmountScrollBar.Scroll += AmountScrollBar_Scroll; // Attach scroll event handler to AmountScrollBar

            isInitializing = false;

            UpdateConversion(); // Perform an conversion update
        }
        private void UpdateConversion()
        {
            if (isInitializing) return; // If the form is still initializing, skip the conversion
            decimal amount;

            if (!decimal.TryParse(EnterAmount.Text, out amount)) // Try to parse the input amount from the text box
            {
                MessageBox.Show("Error occured.\nPlease enter a numerical value.");
                return;
            }

            // Get the selected currencies from the dropdown lists
            int fromCurrency = From.SelectedIndex;
            int toCurrency = To.SelectedIndex;

            if (fromCurrency == -1 || toCurrency == -1) // If no currency is selected, stop the conversion
            {
                return;
            }

            decimal converted_amount = ConvertCurrency(amount, fromCurrency, toCurrency); // Perform the currency conversion

            if (Round_checkBox.Checked) // Round the result to 2 decimal places if the checkbox is checked
            {
                converted_amount = Math.Round(converted_amount, 2);
            }

            result2.Text = $"{amount}{From.Text} = {converted_amount}{To.Text}"; // Display the conversion result in the result label
            // Center the result label horizontally in the form
            result2.Location = new Point(
                (this.ClientSize.Width - result2.Width) / 2,
                result2.Location.Y);

            UpdateConversionRate(); // Update the displayed conversion rate information
        }

        private decimal ConvertCurrency(decimal amount, int fromCurrency, int toCurrency)
        {
            decimal rate = exchange_rate[fromCurrency, toCurrency]; // Get the exchange rate from the table
            return amount * rate; // Multiply the amount by the rate
        }

        private decimal UpdateCoversionLabel()
        {
            // Get the selected currency indexes
            int fromCurrency = From.SelectedIndex;
            int toCurrency = To.SelectedIndex;

            return exchange_rate[fromCurrency, toCurrency];
        }

        private void UpdateConversionRate()
        {
            decimal rate = UpdateCoversionLabel(); // Get the current exchange rate
            result1.Text = $"Conversion rate: {rate:F2}"; // Display the rate with two decimal places
            result1.Location = new Point( // Center the label horizontally in the form
                (this.ClientSize.Width - result1.Width) / 2,
                result1.Location.Y);
        }

        private void AmountScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            EnterAmount.Text = AmountScrollBar.Value.ToString(); // Updates the textboxamount based on the scrollbar value.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateConversion();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            From.SelectedIndex = -1; // Deselect "From" currency
            To.SelectedIndex = -1; // Deselect "To" currency
            EnterAmount.Text = ""; // Clear input field
            Round_checkBox.Checked = false; // Reset checkbox
            AmountScrollBar.Value = AmountScrollBar.Minimum; // Reset scrollbar to its minimum position
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int To_copy = To.SelectedIndex; // Temporarily store the target currency
            // Swap the selections
            To.SelectedIndex = From.SelectedIndex;
            From.SelectedIndex = To_copy;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Event handler for the "To"/"From" currency dropdown change. Skips execution if the form is still initializing.
        private void From_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;
        }

        private void To_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing) return;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label2_Click_3(object sender, EventArgs e)
        {

        }

        private void result_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
