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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public static int vid;
        string v;
       
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            v = textBox1.Text;

           

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            string VID = textBox1.Text;
            string password = textBox2.Text.ToString();

            SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*)from VOTERREG where VOTER_ID='" + VID + "'and PASSWORD='" + password + "'", cnn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            
            {

               // SqlDataAdapter sda = new SqlDataAdapter("select count(*)from VOTERREG where VOTE="1" + "'and PASSWORD='" + passwo

                this.Hide();
                new VOTINGOTP().Show();


            }
           
            else
                MessageBox.Show("invalid username or password");


          
           
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new result().Show();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        /*  private void button4_Click(object sender, EventArgs e)
          {
              SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
              string sql = "";
              sql = "SELECT VOTE FROM VOTERREG WHERE VOTER_ID='" + v + "'";
              SqlCommand cmd = new SqlCommand(sql, cnn);
              cnn.Open();
             bool result = cmd.ExecuteScalar();
              if (result)
              {
                  button2.Visible = false;
                  MessageBox.Show("YOU ALREADY VOTED !");
              }
              else
                  MessageBox.Show("GO AHEAD VOTING !");
          }*/
    } } 
