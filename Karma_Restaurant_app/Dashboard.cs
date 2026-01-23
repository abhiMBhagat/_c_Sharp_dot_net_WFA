using System.Globalization;
using System.Text.RegularExpressions;

namespace Karma_Restaurant_app
{
    public partial class Dashboard : Form
    {
        private string? customerName;
        private string? phoneNumber;
        private List<string> comboBoxData = new List<string>(); // Class-level variable for storing data

        // New class-level fields so button6 can clear them
        private string? email;
        private string? addressText;

        public Dashboard()
        {
            InitializeComponent();

            // Make order/details text boxes read-only for the user
            // Defensive null checks in case controls are not created by the designer
            if (textBox5 != null)
            {
                textBox5.ReadOnly = true;
                textBox5.TabStop = false;
            }

            if (textBox7 != null)
            {
                textBox7.ReadOnly = true;
                textBox7.TabStop = false;
            }
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
                double totalSum = 0;

                // Parse each order line from textBox5 (these lines include size & quantity)
                var lines = textBox5.Lines;
                var pattern = new Regex(@"\$(?<price>[0-9]+(?:\.[0-9]+)?)\s*x\s*(?<size>[RML])\s*(?<qty>\d+)", RegexOptions.IgnoreCase);

                foreach (var raw in lines)
                {
                    var line = raw?.Trim();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    var m = pattern.Match(line);
                    if (!m.Success)
                    {
                        // skip or log invalid lines; don't attempt to parse from listBox1
                        continue;
                    }

                    if (!double.TryParse(m.Groups["price"].Value, NumberStyles.Number, CultureInfo.InvariantCulture, out double price))
                        continue;

                    if (!int.TryParse(m.Groups["qty"].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int qty))
                        continue;

                    var size = m.Groups["size"].Value.ToUpperInvariant();
                    double sizeMultiplier = size switch
                    {
                        "R" => 1.0,
                        "M" => 1.5,
                        "L" => 2.0,
                        _ => 1.0
                    };

                    totalSum += price * sizeMultiplier * qty;
                }

                textBox7.Text = totalSum.ToString("F2", CultureInfo.InvariantCulture);
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
                customerName = textBox1.Text.Trim();
                phoneNumber = textBox2.Text.Trim();
                // Use class-level fields so they can be cleared by button6
                email = textBox3.Text.Trim();
                addressText = textBox4.Text.Trim();

                // 1. Customer Name validation (letters and spaces only)
                if (!Regex.IsMatch(customerName, @"^[A-Za-z ]{2,}$"))
                {
                    MessageBox.Show("Please enter a valid customer name (letters only).",
                                    "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                // 2. Phone Number validation (exactly 10 digits)
                if (!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
                {
                    MessageBox.Show("Phone number must be exactly 10 digits.",
                                    "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }

                // 3. Email validation
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address.",
                                    "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return;
                }

                // 4. Address validation (max 50 characters)
                if (addressText.Length > 50)
                {
                    MessageBox.Show("Address cannot exceed 50 characters.",
                                    "Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox4.Focus();
                    return;
                }

                // Prepare data to save
                string data = $"Customer Name: {customerName}\n" +
                              $"Phone Number: {phoneNumber}\n" +
                              $"Email: {email}\n" +
                              $"Address: {addressText}";

                string filePath = "customer_details.txt";

                System.IO.File.WriteAllText(filePath, data);

                MessageBox.Show("Congrats! Your details are stored with us",
                                "Details Stored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 1;
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
            //string finalMessage = string.Join(string.Empty,
            //    gap, "Customer Name: ", customerName, space, space, "Mobile Number: ", phoneNumber, space, space, space, space, gap, topMsg, gap, space, gap, orderDetails, space, gap, "Total: ", totalAmount, space, gap, thankYouMessage);
            string finalMessage = string.Join(string.Empty, gap, Environment.NewLine,
                                "Customer Name: ", customerName, Environment.NewLine,
                                "Mobile Number: ", phoneNumber, Environment.NewLine, gap,
                                Environment.NewLine, Environment.NewLine, Environment.NewLine,

                                gap, Environment.NewLine, topMsg, Environment.NewLine,
                                gap, Environment.NewLine,
                                orderDetails, Environment.NewLine, Environment.NewLine,
                                gap, Environment.NewLine,
                                    "Total: ", totalAmount, Environment.NewLine,
                                gap, Environment.NewLine, Environment.NewLine, Environment.NewLine,
                                      thankYouMessage);


            // Display the final message in textBox8
            textBox8.Text = finalMessage;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            // Logic not needed for this event now
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox8 == null || string.IsNullOrWhiteSpace(textBox8.Text))
                {
                    MessageBox.Show("There is nothing to save to PDF.", "No Content", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.FileName = "receipt.pdf";
                    sfd.Title = "Save receipt as PDF";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    byte[] pdfBytes = BuildPdfFromText(textBox8.Text);
                    System.IO.File.WriteAllBytes(sfd.FileName, pdfBytes);
                    MessageBox.Show("PDF saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Local helper: escape parentheses and backslashes for PDF literal strings
            static string EscapePdfString(string s)
            {
                if (s == null) return string.Empty;
                return s.Replace(@"\", @"\\").Replace("(", @"\(").Replace(")", @"\)");
            }

            // Local helper: build a minimal single-page PDF containing the provided text (lines separated by \r\n or \n)
            static byte[] BuildPdfFromText(string text)
            {
                // Page and text layout settings
                const int pageWidth = 612;   // 8.5in * 72
                const int pageHeight = 792;  // 11in * 72
                const int marginLeft = 50;
                const int marginTop = 742;   // initial y position (from bottom)
                const int lineHeight = 14;
                const int fontSize = 12;

                string[] lines = text.Replace("\r\n", "\n").Split('\n');

                // Build PDF text content stream
                var sb = new System.Text.StringBuilder();
                sb.AppendLine("BT");
                sb.AppendLine($"/F1 {fontSize} Tf");
                sb.AppendLine($"{marginLeft} {marginTop} Td");
                bool first = true;
                for (int i = 0; i < lines.Length; i++)
                {
                    string ln = EscapePdfString(lines[i]);
                    if (!first)
                    {
                        // move down by lineHeight (negative y)
                        sb.AppendLine($"0 -{lineHeight} Td");
                    }
                    first = false;
                    sb.Append("(" + ln + ") Tj");
                    sb.AppendLine();
                }
                sb.AppendLine("ET");

                byte[] contentBytes = System.Text.Encoding.ASCII.GetBytes(sb.ToString());

                // Build PDF objects (we'll compute offsets)
                var objects = new List<byte[]>();

                // Object 1: Catalog
                objects.Add(System.Text.Encoding.ASCII.GetBytes("1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n"));

                // Object 2: Pages
                objects.Add(System.Text.Encoding.ASCII.GetBytes("2 0 obj\n<< /Type /Pages /Kids [3 0 R] /Count 1 >>\nendobj\n"));

                // Object 3: Page (references content obj 5)
                string pageObj = $"3 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 {pageWidth} {pageHeight}] /Resources << /Font << /F1 4 0 R >> >> /Contents 5 0 R >>\nendobj\n";
                objects.Add(System.Text.Encoding.ASCII.GetBytes(pageObj));

                // Object 4: Font
                objects.Add(System.Text.Encoding.ASCII.GetBytes("4 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>\nendobj\n"));

                // Object 5: Content stream (needs /Length value)
                string contentHeader = $"5 0 obj\n<< /Length {contentBytes.Length} >>\nstream\n";
                string contentFooter = "\nendstream\nendobj\n";
                byte[] contentObjBytes = Combine(System.Text.Encoding.ASCII.GetBytes(contentHeader), contentBytes, System.Text.Encoding.ASCII.GetBytes(contentFooter));
                objects.Add(contentObjBytes);

                // Now assemble the whole PDF with offsets
                using (var ms = new System.IO.MemoryStream())
                {
                    // PDF header
                    var header = System.Text.Encoding.ASCII.GetBytes("%PDF-1.4\n%\u00e2\u00e3\u00cf\u00d3\n");
                    ms.Write(header, 0, header.Length);

                    // record offsets
                    var offsets = new List<long>();
                    for (int i = 0; i < objects.Count; i++)
                    {
                        offsets.Add(ms.Position);
                        ms.Write(objects[i], 0, objects[i].Length);
                    }

                    long xrefStart = ms.Position;

                    // Write xref table
                    var xrefSb = new System.Text.StringBuilder();
                    xrefSb.AppendLine("xref");
                    xrefSb.AppendLine($"0 {objects.Count + 1}");
                    xrefSb.AppendLine("0000000000 65535 f "); // object 0
                    foreach (var off in offsets)
                    {
                        xrefSb.AppendLine(off.ToString("D10") + " 00000 n ");
                    }

                    // Trailer
                    xrefSb.AppendLine("trailer");
                    xrefSb.AppendLine("<<");
                    xrefSb.AppendLine($"/Size {objects.Count + 1}");
                    xrefSb.AppendLine("/Root 1 0 R");
                    xrefSb.AppendLine(">>");
                    xrefSb.AppendLine("startxref");
                    xrefSb.AppendLine(xrefStart.ToString());
                    xrefSb.AppendLine("%%EOF");

                    byte[] xrefBytes = System.Text.Encoding.ASCII.GetBytes(xrefSb.ToString());
                    ms.Write(xrefBytes, 0, xrefBytes.Length);

                    return ms.ToArray();
                }

                // Helper to combine byte arrays
                static byte[] Combine(params byte[][] arrays)
                {
                    int len = 0;
                    foreach (var a in arrays) len += a.Length;
                    var res = new byte[len];
                    int pos = 0;
                    foreach (var a in arrays)
                    {
                        System.Buffer.BlockCopy(a, 0, res, pos, a.Length);
                        pos += a.Length;
                    }
                    return res;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Clear stored variables
            customerName = null;
            phoneNumber = null;
            email = null;
            addressText = null;

            // Clear input fields so UI reflects cleared state
            if (textBox1 != null) textBox1.Text = string.Empty;
            if (textBox2 != null) textBox2.Text = string.Empty;
            if (textBox3 != null) textBox3.Text = string.Empty;
            if (textBox4 != null) textBox4.Text = string.Empty;

            MessageBox.Show("Customer details cleared.", "Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect all combo boxes in one array for concise handling
                ComboBox[] boxes = new ComboBox[]
                {
                    comboBox1, comboBox2, comboBox3, comboBox4, comboBox5,
                    comboBox6, comboBox7, comboBox8, comboBox9
                };

                foreach (var cb in boxes)
                {
                    if (cb != null)
                    {
                        // Clear selection and any editable text
                        cb.SelectedIndex = -1;
                        cb.SelectedItem = null;
                        cb.Text = string.Empty;
                    }
                }

                // Clear the stored selections list so it stays in sync with the UI
                comboBoxData.Clear();

                MessageBox.Show("All combobox selections cleared.", "Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing comboboxes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Pseudocode (detailed):
            // 1. Validate that the control reference for textBox5 exists (not null).
            // 2. If it exists, clear its contents so previous order lines are removed:
            //    - Use Clear() or set Text to string.Empty.
            //    - Also set Lines to an empty string array to ensure no lingering line entries.
            // 3. Optionally update any derived fields (not requested here) such as totals.
            // 4. Provide user feedback via MessageBox that the order entries were cleared.
            // 5. Wrap operations in try/catch to surface any unexpected errors to the user.
            try
            {
                if (textBox5 != null)
                {
                    // Clear the text content and any lines
                    textBox5.Clear();
                    textBox5.Lines = Array.Empty<string>();
                }

                MessageBox.Show("Order entries cleared.", "Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing order entries: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    // Set the selected index of tabControl1 to 1 to open the second tab
        //    tabControl1.SelectedIndex = 1;
        //}
    }
}