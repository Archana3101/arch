/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Collections.Specialized;
//using System.Web.dll;
namespace votingproject
{

   /* public class CSharpApp
    {
        static void start()
        {
            sendSMS del = new sendSMS();
            string res1 = del.SendSMS();
            Console.WriteLine(" result {0}", res1);
            Console.ReadLine();
        }
    }
    */

    /*
     class sendSMS
    {
        public string SendSMS()
        {
            String message = HttpUtility.UrlEncode("This is the otp");
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection() {
                {"username","csharp2018nmit@gmail.com"},
                {"hash","e40ffc2b10c7bda2448dc0b5f21db60bfccb6437afc843476eee68aae049809b"},
                {"numbers" , "9482633726"},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
    }
}
*/