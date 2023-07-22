using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using System;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Data;

namespace scansText
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private TesseractEngine ocrEngine;
        private bool isScanned;
        private Form2 form2;

        public Form1()
        {
            InitializeComponent();
            ocrEngine = new TesseractEngine("../../tessdata", "eng", EngineMode.Default);
            InitializeWebcam();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        string idStd = "";

        private void InitializeWebcam()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("Không tìm thấy webcam trên máy tính của bạn.");
            }
        }
        Bitmap bitmap = null;
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {


            bitmap = (Bitmap)eventArgs.Frame.Clone();

            using (Page page = ocrEngine.Process(bitmap))
            {
                string recognizedText = page.GetText();

                if (!string.IsNullOrEmpty(recognizedText))
                {
                    int startIndex = recognizedText.IndexOf("SE");

                    if (startIndex != -1 && startIndex + 2 + 6 <= recognizedText.Length)
                    {
                        string scannedText = recognizedText.Substring(startIndex, 8);

                        // Kiểm tra xem ký tự thứ 3 đến thứ 8 là số
                        bool isNumber = int.TryParse(scannedText.Substring(2), out int _);

                        if (isNumber)
                        {
                            txt_IdStd.Text = scannedText;
                            idStd = scannedText;
                            scannedText = "";
                            pictureBox.Image = null;
                            pictureBox.Image.Dispose();

                        }
                    }
                }

            }

            pictureBox.Invoke((MethodInvoker)delegate
            {
                pictureBox.Image = bitmap;

            });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btn_Pay.Visible = true;
            txt_NameStudent.Text = string.Empty;
            lb_valid1.Visible = false;
            txt_IdStd.Text = string.Empty;
            idStd = "";
            dataGridView1.Visible = false;
            btn_Register.Visible = false;
            label2.Visible = false;
            btn_Hitsory.Visible = false;
            txt_NameStudent.Visible = false;
            this.Width = 521;
            this.CenterToScreen();
        }

        private void btn_Cleardata_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Form1_Load(sender, e);
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            form2 = new Form2(idStd);
            this.Hide();
            form2.ShowDialog();
        }
        private void btn_Pay_Click(object sender, System.EventArgs e)
        {

            double price = -50000;
            try
            {
                if (txt_IdStd.Text != "")
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
                    var values = service.Spreadsheets.Values.Get("1wjt4VJTrIUAc6wHFbZRZelq83J5PhHZr8T-od8C96JI", $"{"data-received"}!A:C").Execute().Values;
                    int i = 0;
                    Boolean checkaccout = false;
                    foreach (var Column in values)
                    {
                        i++;

                        if (Column[0].ToString().Equals(idStd))
                        {
                            checkaccout = true;
                            string name = Column[1].ToString();
                            txt_NameStudent.Text = name;
                            DialogResult result = MessageBox.Show($"Xin Chào {name}" + "\n" + "Bạn có sẵn sàng tham gia vào lớp học Thầy Phương!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                double blank = double.Parse(Column[2].ToString());
                                blank += price;
                                if (blank >= 0)
                                {

                                    var date = DateTime.Now;
                                    var rowNumber = i;
                                    var range = $"{"data-received"}!C{rowNumber}:D{rowNumber}";
                                    var ValueRange = new ValueRange();
                                    ValueRange.Values = new List<IList<object>> { new List<object> { blank, date } };
                                    var updatePlank = service.Spreadsheets.Values.Update(ValueRange, "1wjt4VJTrIUAc6wHFbZRZelq83J5PhHZr8T-od8C96JI", range);
                                    updatePlank.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                                    var UpdateResponse = updatePlank.Execute();

                                    SpreadsheetsResource.ValuesResource.GetRequest getRequest = service.Spreadsheets.Values.Get("1wjt4VJTrIUAc6wHFbZRZelq83J5PhHZr8T-od8C96JI", "data-record!A:C");
                                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender2, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };
                                    ValueRange getRespone = getRequest.Execute();
                                    IList<IList<Object>> valuess = getRespone.Values;

                                    var Range = $"data-record!A" + (valuess.Count + 1) + ":E" + (valuess.Count + 1);
                                    var ValueRange2 = new ValueRange();
                                    string id = Column[0].ToString();
                                    ValueRange2.Values = new List<IList<object>> { new List<object>() { id, name, price, blank, date } };
                                    var addResquest = service.Spreadsheets.Values.Update(ValueRange2, "1wjt4VJTrIUAc6wHFbZRZelq83J5PhHZr8T-od8C96JI", Range);
                                    addResquest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                                    var AddResponse = addResquest.Execute();
                                    MessageBox.Show($"Cảm ơn {name} đã tham gia, xin mời bạn vào lớp !");
                                    label2.Visible = true;
                                    dataGridView1.Visible = true;
                                    DataTable dataTable = new DataTable();
                                    dataTable.Columns.Add("TransactionID");
                                    dataTable.Columns.Add("Student_ID");
                                    dataTable.Columns.Add("Student_Name");
                                    dataTable.Columns.Add("Pay");
                                    dataTable.Columns.Add("Available_Balances");
                                    dataTable.Columns.Add("Trading_Time");
                                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                    dataGridView1.DataSource = dataTable;
                                    btn_Hitsory.Visible = true;
                                    txt_NameStudent.Visible = true;
                                    this.Width = 1303;
                                    this.CenterToScreen();
                                }
                                else
                                {
                                    MessageBox.Show("Bạn chưa thể tham gia, tài khoản của bạn hiện còn dưới 50.000đ !");
                                    label2.Visible = true;
                                    dataGridView1.Visible = true;
                                    DataTable dataTable = new DataTable();
                                    dataTable.Columns.Add("TransactionID");
                                    dataTable.Columns.Add("Student_ID");
                                    dataTable.Columns.Add("Student_Name");
                                    dataTable.Columns.Add("Pay");
                                    dataTable.Columns.Add("Available_Balances");
                                    dataTable.Columns.Add("Trading_Time");
                                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                    dataGridView1.DataSource = dataTable;
                                    btn_Hitsory.Visible = true;
                                    txt_NameStudent.Visible = true;
                                    this.Width = 1303;
                                    this.CenterToScreen();
                                }

                            }
                            else
                            {
                                MessageBox.Show($"Quay Lại khi bạn đã sẵn sàng nhé {name}");
                                label2.Visible = true;
                                dataGridView1.Visible = true;
                                DataTable dataTable = new DataTable();
                                dataTable.Columns.Add("TransactionID");
                                dataTable.Columns.Add("Student_ID");
                                dataTable.Columns.Add("Student_Name");
                                dataTable.Columns.Add("Pay");
                                dataTable.Columns.Add("Available_Balances");
                                dataTable.Columns.Add("Trading_Time");
                                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                dataGridView1.DataSource = dataTable;
                                btn_Hitsory.Visible = true;
                                txt_NameStudent.Visible = true;
                                this.Width = 1303;
                                this.CenterToScreen();

                            }
                        }
                    }
                    if (checkaccout == false)
                    {
                        btn_Pay.Visible = false;
                        btn_Register.Visible = true;
                        lb_valid1.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn vui lòng scan Studen Card Của mình ! ");
                }


            }
            catch
            {

            }
        }

        private void btn_Hitsory_Click(object sender, EventArgs e)
        {
            try
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
                var values = service.Spreadsheets.Values.Get("1wjt4VJTrIUAc6wHFbZRZelq83J5PhHZr8T-od8C96JI", $"{"data-record"}!A:F").Execute().Values;

                var listvalues = values.Where(r => r.Count >= 0 && r[0].ToString().Equals(idStd)).ToList();
                // Dương tạo bảng để định hình dữ liệu cho dataGridView1
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("TransactionID");
                dataTable.Columns.Add("Student_ID");
                dataTable.Columns.Add("Student_Name");
                dataTable.Columns.Add("Pay");
                dataTable.Columns.Add("Available_Balances");
                dataTable.Columns.Add("Trading_Time");
                // Duyệt và thêm dữ liệu trả về vào bảng vừa tạo
                foreach (var row in listvalues)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["TransactionID"] = row[5].ToString();
                    dataRow["Student_ID"] = row[0].ToString();
                    dataRow["Student_Name"] = row[1].ToString();
                    dataRow["Pay"] = row[2].ToString();
                    dataRow["Available_Balances"] = row[3].ToString();
                    dataRow["Trading_Time"] = row[4].ToString();
                    dataTable.Rows.Add(dataRow);
                }
                //Truyển bảng vào dataGridView1 để hiển thị

                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch { }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tắt ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {

                if (form2 != null && !form2.IsDisposed)
                {
                    form2.Close();
                }
                form2 = new Form2(idStd);
                Form1_Load(sender, e);
                e.Cancel = false;
            }
        }

    }
}
