using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //form nhân viên load cùng lúc với form chính
            frmNhanvien frm = new frmNhanvien();
            OpenChildForm(frm);

        }
        private void OpenChildForm(Form childForm)
        {
            // Kiểm tra xem Form  đã mở chưa
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == childForm.GetType())
                {
                    f.Activate(); // Nếu mở rồi thì focus vào nó
                    return;
                }
            }
            
            childForm.MdiParent = this;
            childForm.Show();
        }

        // Gọi Form Quản lý Nhân viên Dự án 
        private void menuQuanLy_Click(object sender, EventArgs e)
        {
            frmNhanVienDuan frm = new frmNhanVienDuan();
            OpenChildForm(frm);
        }

        // Gọi Form Báo cáo 
        private void menuBaoCao_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            OpenChildForm(frm);
        }

        // Thoát hệ thống
        private void menuThoát_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanvien frm = new frmNhanvien();
            frm.MdiParent = this; 
            frm.Show();
        }

        private void dựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDuan frm = new frmDuan();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
