using AForge.Video;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace scansText
{
    public partial class Form2 : Form
    {
        private Form1 form1;

        private string id;

        public Form2(string id)
        {
            InitializeComponent();
            this.id = id;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblScannedText.Text = $"Đăng Ký Với Mã Tài Khoản {id}";
            lb_valid1.Visible = false ;
        }
        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (txt_StudentName.Text != "")
            {
                string[] Scopes = { SheetsService.Scope.Spreadsheets };
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                    {
                        ClientId = "188776004155-u1ir7kf15fsbted8q4lq250qoitku7lk.apps.googleusercontent.com",
                        ClientSecret = "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"
                    }
                , Scopes, "user", CancellationToken.None, new FileDataStore("MyAppsToken")).Result,
                    ApplicationName = "Google Sheets API .NET Quickstart",
                });

                SpreadsheetsResource.ValuesResource.GetRequest getRequest = service.Spreadsheets.Values.Get("1wjt4VJTrIUAc6wHFbZRZelq83J5PhHZr8T-od8C96JI", "data-received!A:D");
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender2, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };
                ValueRange getRespone = getRequest.Execute();

                IList<IList<Object>> valuess = getRespone.Values;
                var Range = $"data-received!A" + (valuess.Count + 1) + ":D" + (valuess.Count + 1);
                var ValueRange2 = new ValueRange();
                string ids = id;
                string name = txt_StudentName.Text;
                var date = DateTime.Now;
                double price = 500000;
                ValueRange2.Values = new List<IList<object>> { new List<object>() { ids, name, price, date } };
                var addResquest = service.Spreadsheets.Values.Update(ValueRange2, "1wjt4VJTrIUAc6wHFbZRZelq83J5PhHZr8T-od8C96JI", Range);
                addResquest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                var AddResponse = addResquest.Execute();
                MessageBox.Show($"{name} đăng ký Thành Công" + "\n" + "Bạn sẽ có 500.000đ trong tài khoản tương đương với 10 buổi học thử!");
                form1 = new Form1();
                this.Hide();
                form1.Show();
            }
            else
            {
                lb_valid1.Visible = true;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn Muốn Hủy Đăng Ký?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                form1 = new Form1();
                this.Hide();
                form1.Show();
            }

        }

        private void txt_PriceAddorUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = false; 
            }
        }
    }
}
