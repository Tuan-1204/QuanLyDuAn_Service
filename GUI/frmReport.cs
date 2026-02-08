using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GUI.ServiceReference1;

namespace GUI
{
    public partial class frmReport : Form
    {
        // Khởi tạo Client để gọi WCF
        private readonly Service1Client client = new Service1Client();
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

            try
            {
                //  Gọi hàm lấy dữ liệu từ WCF 
                var data = client.Nvd_GetReport();

                //  Xóa các nguồn dữ liệu cũ nếu có
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", data);
                reportViewer1.LocalReport.DataSources.Add(rds);
                //  Đường dẫn tới file báo cáo RDLC
                reportViewer1.LocalReport.ReportPath = "../../report1.rdlc";

                //  Làm mới và hiển thị dữ liệu
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message);
            }
        }
    }
}
