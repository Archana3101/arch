using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace votingproject
{
    public partial class deleteC : Form
    {
        public deleteC()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        string candid;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            candid = textBox1.Text;

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
         //  SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string sql = "";
            sql = "DELETE FROM CANDIDATE WHERE CANDIDATE_ID='"+candid+"'";
            command = new SqlCommand(sql, cnn);
            command.ExecuteNonQuery();


         // adapter.SelectCommand = new SqlCommand(sql, cnn);

            MessageBox.Show("DELETED SUCCEFULLY");

            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader reader;
            cnn.Open();
            string sql = "";
            sql = "SELECT c.CANDIDATE_ID,c.FIRST_NAME,c.LAST_NAME FROM CANDIDATE c";
            command = new SqlCommand(sql, cnn);
            adapter.SelectCommand = new SqlCommand(sql, cnn);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }

            cnn.Close();
        }

        private void deleteC_Load(object sender, EventArgs e)
        {

        }
    }
}
