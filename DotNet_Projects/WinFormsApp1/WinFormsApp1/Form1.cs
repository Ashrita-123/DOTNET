using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            con = new SqlConnection("Server=DESKTOP-5JT3T8O\\ASHRITA;User Id=sa;Password=user123;Database=Ashritadb");
            con.Open();
            MessageBox.Show("connection successful");
        }
    }
}
