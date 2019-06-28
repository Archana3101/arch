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

   

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        public string constr = "Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True";

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            //int age = TextBox7_TextChanged(TextBox7_TextChanged,).Text;
          //// if(age<18)
              //  MessageBox.Show( "only above 18 yrs.");
        }

       

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            //if(Label5.Click== null)
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        int age;

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            age = Convert.ToInt32(textBox7.Text);
        }

           
      

        
        public static int  rotp=0;
        private void Button1_Click(object sender, EventArgs e)
        {

            int x = 1;
            // if (x == 0)
            //  {
            if (age < 18)
            { MessageBox.Show("Only above 18 are eligible"); x = 0; }

            if (TextBox1.Text == string.Empty)
            { MessageBox.Show("First name cannot be empty"); x = 0; }
            if (textBox7.Text == string.Empty)
            { MessageBox.Show("Age cannot be empty"); x = 0; }

            if (TextBox6.Text == string.Empty)
            { MessageBox.Show("city cannot be empty"); x = 0; }

            if (TextBox2.Text == string.Empty)
            { MessageBox.Show("contact number cannot be empty"); x = 0; }
            if (TextBox2.Text.Length != 10)
            { MessageBox.Show(TextBox2, "enter a valid ph no"); x = 0; }

            
            if (x == 1)
            {
                String date = dateTimePicker1.Value.ToString();
                string state = /*this.comboBox1.GetItemText*/(comboBox1.SelectedItem).ToString();
                string nation= this.comboBox2.GetItemText(this.comboBox2.SelectedItem).ToString();
                String gender;
                if(RadioButton1.Checked)
                      gender = "MALE"; 
                else if (RadioButton3.Checked)
                             gender = "FEMALE"; 
                      else
                             gender = "OTHER";

                SqlCommand command;
                SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
                SqlDataAdapter adapter = new SqlDataAdapter();
                cnn.Open();
                string sql = "";
                sql = "INSERT INTO VOTERREG(FIRST_NAME,LAST_NAME,DOB,AGE,CITY,STATE,NATIONALITY,GENDER,GAURDIAN_NAME,CONTACT_NUM,ADDRESS,EMAIL,AADHAR_NUM) VALUES('"+TextBox1.Text+"','"+TextBox9.Text+ "','" + date + "','" +
                 textBox7.Text + "','" +TextBox6.Text + "','" + state + "','" + nation + "','" + gender + "','" +TextBox3.Text + "','" + TextBox2.Text + "','" + textBox5.Text + "','" +TextBox11.Text + "','" + TextBox10.Text + "')";
                command = new SqlCommand(sql,cnn);
                adapter.InsertCommand = new SqlCommand(sql,cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                cnn.Close();

              
                string Sendotp()
                {
                    Random rand1 = new Random();
                     rotp = rand1.Next(1, 10000);
                   // label5.Text = voterid.ToString();
                    String message = HttpUtility.UrlEncode("THE OTP IS : "+ rotp.ToString());
                    using (var wb = new WebClient())


                    {

                        string num = TextBox2.Text;

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


                this.Hide();

                new regotp().Show();
            }

        }

       

       
    }



}
    
 
