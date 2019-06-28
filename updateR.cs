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
using System.Net;
using System.Web;
using System.Collections.Specialized;
namespace votingproject
{
    public partial class updateR : Form
    {
        public updateR()
        {
            InitializeComponent();
        }
        String date;
        string state;
        string nation;
        String gender;
        int age;
        string v;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32(textBox2.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            v = textBox10.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {


         





            String date = dateTimePicker1.Value.ToString();
            string state = /*this.comboBox1.GetItemText*/(comboBox2.SelectedItem).ToString();
            string nation = this.comboBox2.GetItemText(this.comboBox1.SelectedItem).ToString();
            String gender;
            if (radioButton1.Checked)
                gender = "MALE";
            else if (radioButton3.Checked)
                gender = "FEMALE";
            else
                gender = "OTHER";



            SqlCommand command;
            SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string sql = "";
            sql = "UPDATE VOTERREG SET FIRST_NAME='" + textBox1.Text + "',LAST_NAME='" + textBox4.Text + "',DOB='" + date + "',AGE= '"+textBox2.Text +"',CITY='"+ textBox3.Text +"',STATE='" + state + "',NATIONALITY='" + nation + "',GENDER='" + gender + "',GAURDIAN_NAME='" + textBox6.Text + "',CONTACT_NUM='" + textBox5.Text + "',ADDRESS='" + textBox7.Text + "',EMAIL='" + textBox8.Text + "',AADHAR_NUM='" + textBox9.Text + "' WHERE VOTER_ID='" + v + "'";
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            MessageBox.Show("REGISTRATION SUCCESSFULL!.");
            cnn.Close();
            this.Hide();

            new Form4().Show();
        }
       
        public static int aadhar;
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
             

      
            aadhar = Convert.ToInt32(textBox9.Text);
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updateR_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
