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
    public partial class result : Form
    {
        public result()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            new Form3().Show();
        }

        private void result_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
            SqlDataAdapter sd = new SqlDataAdapter("SELECT CANDIDATE_ID,FIRST_NAME,PARTY_NAME,VOTES_GAINED FROM CANDIDATE ORDER BY VOTES_GAINED DESC ", con);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;

        }

      //  private void pictureBox1_Click(object sender, EventArgs e)
       // {

       // }
    }
}
