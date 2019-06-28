using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
//using System.
    using System.Data.SqlClient;

namespace votingproject
{
    public partial class vote : Form
    {
        public vote()
        {
            InitializeComponent();
        }

        private void vote_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'votingdatabaseDataSet.CANDREG' table. You can move, or remove it, as needed.
            //   this.CANDIDATETableAdapter.Fill(this.votingdatabaseDataSet.CANDIDATE);
            // var data=new AppsAuthData()


            //  MessageBox.Show("DOUBLE CLICK TO VOTE");
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        int selected_id;
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowindex];
            selected_id = Convert.ToInt32(row.Cells[0].Value);
            //int x=
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string sql = "";
            sql = "UPDATE CANDIDATE SET VOTES_GAINED=VOTES_GAINED+1 WHERE CANDIDATE_ID="+selected_id+"";
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
            MessageBox.Show("****THANKS FOR VOTING******");
            this.Hide();
            new Form3().Show();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
