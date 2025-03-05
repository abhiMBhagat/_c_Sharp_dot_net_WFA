namespace Karma_Restaurant_app
{
    public partial class Dashboard : Form
    {
        private string? customerName;
        private string? phoneNumber;
        private List<string> comboBoxData = new List<string>(); // Class-level variable for storing data

        public Dashboard()
        {
            InitializeComponent();
        }

        private void saveComboBoxData(ComboBox comboBox)  // This method handles collecting data from any ComboBox
        {
            // Check if the ComboBox or the selected item is null
            if (comboBox?.SelectedItem is string selectedItem)
            {
                comboBoxData.Add(selectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Open tabControl1 and select the first tab (index 0)
                tabControl1.SelectedIndex = 2;

                // Clear previous data
                comboBoxData.Clear();

                // Collect data from all ComboBoxes
                saveComboBoxData(comboBox1);
                saveComboBoxData(comboBox2);
                saveComboBoxData(comboBox3);
                saveComboBoxData(comboBox4);
                saveComboBoxData(comboBox5);
                saveComboBoxData(comboBox6);
                saveComboBoxData(comboBox7);
                saveComboBoxData(comboBox8);
                saveComboBoxData(comboBox9);

                // Populate listBox1 with collected data
                if (listBox1 != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(comboBoxData.ToArray());
                }
                else
                {
                    MessageBox.Show("ListBox is not initialized.");
                }

                // Optional: Notify the user
                // MessageBox.Show("Combobox data collected and ListBox updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing data: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Ensure a valid selection from listBox1
            if (listBox1.SelectedItem is not string selectedItem)
            {
                MessageBox.Show("Please select an item from ListBox1.");
                return;
            }

            // Determine suffix based on selected radio button
            string suffix = radioButton1.Checked ? " x R" :
                            radioButton2.Checked ? " x M" :
                            radioButton3.Checked ? " x L" : string.Empty;

            // Check if textBox6 has a valid integer
            if (int.TryParse(textBox6.Text, out int number))
            {
                // Append the selected item with suffix and number to textBox5
                textBox5.AppendText($"{selectedItem}{suffix} {number}{Environment.NewLine}");
            }
            else
            {
                MessageBox.Show("Please enter a valid number ");
                return;
            }

            try
            {
                double multiplier = radioButton1.Checked ? 1.0 :
                                    radioButton2.Checked ? 1.5 :
                                    radioButton3.Checked ? 2.0 : 1.0;

                double totalSum = 0;

                foreach (string item in listBox1.Items)
                {
                    int dollarIndex = item.IndexOf('$');
                    if (dollarIndex >= 0)
                    {
                        string numberString = item.Substring(dollarIndex + 1);

                        if (double.TryParse(numberString, out double value))
                        {
                            totalSum += value * multiplier;  // Multiply by the selected multiplier
                        }
                        else
                        {
                            MessageBox.Show($"Could not parse value after $ in line: {item}");
                        }
                    }
                }

                // Display the total sum in textBox7
                textBox7.Text = totalSum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total: " + ex.Message);
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Your existing logic here
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // Your existing logic here
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Your existing logic here
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            // Your existing logic here
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Ensure the selected item is not null
            if (listBox1.SelectedItem is string selectedItem)
            {
                bool itemFound = comboBoxData.Contains(selectedItem);

                if (itemFound)
                {
                    MessageBox.Show($"Click on {selectedItem} and select your size & quantity to add meal");
                }
                else
                {
                    MessageBox.Show($"{selectedItem} is out of stock");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect data from the controls and assign to global variables
                customerName = textBox1.Text;
                phoneNumber = textBox2.Text;
                string email = textBox3.Text;
                string addressText = textBox4.Text;

                // Prepare the data to save
                string data = $"Customer Name: {customerName}\n" +
                              $"Phone Number: {phoneNumber}\n" +
                              $"Email: {email}\n" +
                              $"Address: {addressText}";

                // Define the file path
                string filePath = "customer_details.txt";

                // Write data to the file
                System.IO.File.WriteAllText(filePath, data);

                // Notify user of success
                MessageBox.Show("Congrats! Your details are stored with us", "Details stored ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Notify user of failure
                MessageBox.Show("Error storing details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Set the selected index of tabControl1 to 3 to open the fourth tab
            tabControl1.SelectedIndex = 3;

            // Constants for formatting
            const int gapLength = 34;
            const int spaceLength = 37;

            // Define the thank you message, content, and formatting elements
            string topMsg = "                 -//--  KARMA'S KITCHEN  -//-";
            string thankYouMessage = " !!! THANK U 4 VISITING, HAVE A GREAT DAY !!!";
            string orderDetails = textBox5.Text;
            string totalAmount = textBox7.Text;
            string gap = new string('=', gapLength); // Create gap line
            string space = new string(' ', spaceLength); // Create space line

            // Construct the final message
            string finalMessage = string.Join(string.Empty,
                gap, "Customer Name: ", customerName, space, "Mobile Number: ", phoneNumber, space, space, space, space, gap, topMsg, gap, space, gap, orderDetails, space, gap, "Total: ", totalAmount, space, gap, thankYouMessage);

            // Display the final message in textBox8
            textBox8.Text = finalMessage;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Congratulations, Your receipt is printed successfully!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Set the selected index of tabControl1 to 1 to open the second tab
            tabControl1.SelectedIndex = 1;
        }
    }
}