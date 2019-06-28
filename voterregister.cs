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
    public partial class voterregister : Form
    {
        public voterregister()
        {
            InitializeComponent();
        }

        private void voterregister_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        int age;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        public static int aadhar;

        public void textBox9_TextChanged(object sender, EventArgs e)
        {
            aadhar = Convert.ToInt32(textBox9.Text);
        }
        public static int rotp;
        String date;
        string state;
        string nation;
        String gender;
        private void button1_Click(object sender, EventArgs e)
        {
            int x = 1;

            if (age < 18)
            { MessageBox.Show("Only above 18 are eligible"); x = 0; }

            if (textBox1.Text == string.Empty)
            { MessageBox.Show("First name cannot be empty"); x = 0; }
            if (textBox2.Text == string.Empty)
            { MessageBox.Show("Age cannot be empty"); x = 0; }

            if (textBox3.Text == string.Empty)
            { MessageBox.Show("city cannot be empty"); x = 0; }

            if (textBox5.Text == string.Empty)
            { MessageBox.Show("contact number cannot be empty"); x = 0; }
            if (textBox5.Text.Length != 10)
            { MessageBox.Show("enter a valid ph no"); x = 0; }

           

            if (x == 1)
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



                string Sendotp()
                {
                    Random rand1 = new Random();
                    rotp = rand1.Next(1, 10000);
                    // label5.Text = voterid.ToString();
                    String message = HttpUtility.UrlEncode("THE OTP IS : " + rotp.ToString());
                    using (var wb = new WebClient())


                    {

                        string num = textBox5.Text;

                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection() {
                {"username","csharp2018nmit@gmail.com"},
                {"hash","e40ffc2b10c7bda2448dc0b5f21db60bfccb6437afc843476eee68aae049809b"},
                {"numbers" ,num},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                        string result = System.Text.Encoding.UTF8.GetString(response);
                        return result;
                    }
                }


                // SendSMS obj = new SendSMS();
                string res1 =/* obj.*/Sendotp();
                Console.WriteLine(" result {0}", res1);
                Console.ReadLine();
                label21.Text = voterregister.rotp.ToString();

                //

            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        int vid;
        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox10.Text) != Convert.ToInt32(voterregister.rotp))
            {
                MessageBox.Show("OOPS! OTP DOES NOT MATCH");
            }
            else
            {
                Random rand1 = new Random();
                vid = rand1.Next(1, 10000);
                label17.Text = vid.ToString();
            }
            // {
            //   // new idpwd().Show();

            //  this.Hide();

            // }
        }

        private void label17_Click(object sender, EventArgs e)
        {

            Random rand1 = new Random();
            int voterid = rand1.Next(0, 10000);
            label17.Text = voterid.ToString();
        }
        string pwd;
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            pwd = textBox11.Text;
        }
        string confpwd;
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            confpwd = textBox12.Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pwd.CompareTo(confpwd) != 0)
              MessageBox.Show("PASSWORD WRONG.PLEASE CONFIRM AGAIN .");
            else

           {
               
                SqlCommand command;
                SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
                SqlDataAdapter adapter = new SqlDataAdapter();
                cnn.Open();
                string sql = "";
                sql = "INSERT INTO VOTERREG(FIRST_NAME,LAST_NAME,DOB,AGE,CITY,STATE,NATIONALITY,GENDER,GAURDIAN_NAME,CONTACT_NUM,ADDRESS,EMAIL,AADHAR_NUM,VOTER_ID,PASSWORD) VALUES('" + textBox1.Text + "','" + textBox4.Text + "','" + date + "','" +
                 textBox2.Text + "','" + textBox3.Text + "','" + state + "','" + nation + "','" + gender + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + label17.Text + "','" + textBox11.Text + "')";
                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                MessageBox.Show("REGISTRATION SUCCESSFULL!.");
                cnn.Close();
                this.Hide();

                new Form1().Show();


            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
