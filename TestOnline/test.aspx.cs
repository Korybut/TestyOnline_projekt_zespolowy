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
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox2.Text = Szyfrowanie(TextBox1.Text);
        }

        string hash = "f83$7*utX";

        private string Szyfrowanie(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

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

        public string GetSalt(string text)
        {
            string salt = "49cbfd9dcbdce78b142";
            return text + salt;
        }

        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }

        public string GetSHA1(string text)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox3.Text = Odszyfrowanie(TextBox2.Text);
        }

        

        protected void Button3_Click(object sender, EventArgs e)
        {
            String value = TextBox4.Text;
            Char delimiter = '}';
            String[] substrings = value.Split(delimiter);
            
            int i = 1;
            foreach (var substring in substrings)
            {
                switch (i)
                {
                    case 1:
                        Label1.Text = substring;
                        break;
                    case 2:
                        Label2.Text = substring;
                        break;
                    case 3:
                        Label3.Text = substring;
                        break;
                }

                //if(i==1)
                //{
                //    Label1.Text = substring;
                //}

                TextBox5.Text = TextBox5.Text + "\n" + substring;
                i = i + 1;
            }
            

            //TextBox6.Text = a2 + "\n" + a1 + "\n" + a3;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DateTime date1 = new DateTime(2018,5,1,22,11,0);
            DateTime date2 = DateTime.Now;
            TimeSpan result = date2 - date1;
            //Zapis dp stringa ilości dni jakie uplynely między datami
            Label4.Text = result.TotalHours.ToString();
            if(result.TotalHours < 1)
            {
                TextBox7.Text = "OK";
            } else
            {
                TextBox7.Text = "NIE!";
            }
        }
    }
}