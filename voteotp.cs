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
    public partial class voteotp : Form
    {
        public voteotp()
        {
            InitializeComponent();
        }
        int rotp; string num;
        private void voteotp_Load(object sender, EventArgs e)
        {
            string Sendotp()
            {
                Random rand1 = new Random();
                rotp = rand1.Next(1, 10000);
                // label5.Text = voterid.ToString();
                String message = HttpUtility.UrlEncode("THE OTP IS : " + rotp.ToString());
                label2.Text = voterregister.rotp.ToString();
                using (var wb = new WebClient())


                {
                  
                    SqlConnection cnn = new SqlConnection("Data Source=DELL\\sqlexpress;Initial Catalog=votingdatabase;Integrated Security=True");
                    cnn.Open();
                    SqlCommand command = new SqlCommand("SELECT CONTACT_NUM FROM VOTERREG WHERE VOTER_ID= " + Form3.vid+"", cnn);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlDataReader rdr = null;
                    rdr = command.ExecuteReader();
                    while(rdr.Read())
                    {
                        string num = rdr["CONTACT_NUM"].ToString();
                    }

                 //   command = ;
                    

                    

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


            string res1 =/* obj.*/Sendotp();
            Console.WriteLine(" result {0}", res1);
            Console.ReadLine();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (Convert.ToInt32(textBox1.Text) != Convert.ToInt32(voterregister.rotp))
            {
                MessageBox.Show("OOPS! OTP DOES NOT MATCH");
            }
            else
            {
                new vote().Show();

                this.Hide();

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
