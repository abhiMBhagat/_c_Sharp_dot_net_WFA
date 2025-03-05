namespace Karma_Restaurant_app
{
    public partial class KarmaRestaurant : Form
    {
        public KarmaRestaurant()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Assuming you have two TextBox controls named txtUsername and txtPassword
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Validate the username and password
            if (username == "admin" && password == "password")
            {
                using (Dashboard da = new Dashboard())
                {
                    da.ShowDialog();
                }
            }
            else
            {
                // Display an error message if the credentials are incorrect
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
