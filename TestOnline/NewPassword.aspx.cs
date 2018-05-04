using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            if (Request["RecoveryPassword"] != null)
            {

                string link = Request["RecoveryPassword"];
                //string link = "oBdHTSi0VhjaamXERwg+8z5u0aZ9oVUYL7jv9ZZXlZmkflGwRAaqZXbkD6ClmK6A";
                link = Odszyfrowanie(link);
                Label1.Text = link;
                SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
                con.Open();
                string query = "SELECT count(*) FROM PRZYPOMNIENIE_HASLA WHERE login='" + link + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                string output = cmd.ExecuteScalar().ToString();

                if (output == "1")
                {
                    string login = "";
                    DateTime date1 = new DateTime(2018, 5, 1, 22, 11, 0);
                    string query2 = "SELECT TOP 1 login,data FROM PRZYPOMNIENIE_HASLA WHERE login='" + link + "' ORDER BY id DESC";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlDataReader reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        login = reader.GetString(0);
                        date1 = reader.GetDateTime(1);
                    }
                    reader.Close();

                    DateTime date2 = DateTime.Now;
                    TimeSpan result = date2 - date1;
                    //Zapis dp stringa ilości dni jakie uplynely między datami
                    Label1.Text = result.TotalHours.ToString();
                    if (result.TotalHours < 1)
                    {
                        //poprawna zmiana hasla
                        //Label1.Text = "OK";

                    }
                    else
                    {
                        SqlCommand command = new SqlCommand("DELETE FROM PRZYPOMNIENIE_HASLA WHERE login = '" + login + "'", con);
                        command.ExecuteNonQuery();
                        Response.Redirect("~/");
                    }

                }
                else
                {
                    Response.Redirect("~/");
                }
                con.Close();
            }
            else
            {
                Response.Redirect("~/");
            }

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