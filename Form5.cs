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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        //String date = dateTimePicker1.Value.ToString();
        private void button1_Click(object sender, EventArgs e)
        {
            Random rand1 = new Random();
            int ID = rand1.Next(1, 10000);
            String date = dateTimePicker1.Value.ToString();
            SqlCommand command;
            SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string sql = "";
            sql = "INSERT INTO CANDIDATE(FIRST_NAME,LAST_NAME,DOB,AGE,ADDRESS,PARTY_NAME,CANDIDATE_ID) VALUES('" + textBox7.Text + "','" + textBox10.Text + "','" + date + "','" +
             textBox9.Text + "','" + textBox11.Text + "','" + textBox8.Text +  "','"+ID+"')";
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
            MessageBox.Show("REGISTRATION SUCCESSFULL.");
            new Form4().Show();
            this.Hide();
        }

       
    }
}
