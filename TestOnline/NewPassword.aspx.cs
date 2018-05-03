using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class NewPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Uri myUri = new Uri("http://www.example.com?param1=good&param2=bad");
            //Label1.Text = HttpUtility.ParseQueryString(myUri.Query).Get("param1");
            //string link = Odszyfrowanie(Request.QueryString["RecoveryPassword"]);
            //byte[] link = Encoding.UTF8.GetBytes("RecoveryPassword=");
            //string link = Request["RecoveryPassword"];
            string link = "oBdHTSi0VhjaamXERwg+8z5u0aZ9oVUYL7jv9ZZXlZmkflGwRAaqZXbkD6ClmK6A";
            link = Odszyfrowanie(link);
            Label1.Text = link;
        }

        string hash = "f83$7*utX";

        private string Odszyfrowanie(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
    }
}