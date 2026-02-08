using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.ServiceReference1;

namespace GUI
{
    public partial class frmNhanVienDuan : Form
    {
        // Khởi tạo client để gọi Service
        private readonly Service1Client client = new Service1Client();
        public frmNhanVienDuan()
        {
            InitializeComponent();
        }

        private void frmNhanVienDuan_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadDataGridView();
        }
        private void LoadComboBoxData()
        {
            // Load Nhân viên
            cboNhanVien.DataSource = client.Nhanvien_GetAll();
            cboNhanVien.DisplayMember = "Hoten";     // Hiển thị tên
            cboNhanVien.ValueMember = "Manhanvien";  // Giá trị là mã

            // Load Dự án
            cboDuAn.DataSource = client.Duan_GetAll();
            cboDuAn.DisplayMember = "Tenda";
            cboDuAn.ValueMember = "Mada";
        }

        private void LoadDataGridView()
        {
            // Sử dụng hàm GetReport để hiển thị đầy đủ thông tin (Họ tên, Tên dự án, Giờ công)
            dgvNhanVienDuan.DataSource = client.Nvd_GetReport();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NhanvienDuanDto dto = new NhanvienDuanDto
                {
                    Manv = cboNhanVien.SelectedValue.ToString(),
                    Mada = cboDuAn.SelectedValue.ToString(),
                    Sogiocong = int.Parse(txtSoGioCong.Text)
                };

                client.Nvd_Insert(dto);
                MessageBox.Show("Phân công nhân viên vào dự án thành công!");
                LoadDataGridView();
            }
            catch (Exception ex)
            {
                //  Hiển thị lỗi từ BUS (Mã trống hoặc giờ công <= 0)
                MessageBox.Show("Lỗi nghiệp vụ: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                NhanvienDuanDto dto = new NhanvienDuanDto
                {
                    Manv = cboNhanVien.SelectedValue.ToString(),
                    Mada = cboDuAn.SelectedValue.ToString(),
                    Sogiocong = int.Parse(txtSoGioCong.Text)
                };
                client.Nvd_Update(dto);
                MessageBox.Show("Cập nhật số giờ công thành công!");
                LoadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = cboNhanVien.SelectedValue.ToString();
                string mada = cboDuAn.SelectedValue.ToString();

                if (MessageBox.Show("Bạn có muốn xóa phân công này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    client.Nvd_Delete(manv, mada);
                    LoadDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {

        }

        private void dgvNhanVienDuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVienDuan.Rows[e.RowIndex];
                // Đổ ngược dữ liệu lên ComboBox dựa vào ValueMember
                cboNhanVien.SelectedValue = row.Cells["Manv"].Value.ToString();
                cboDuAn.SelectedValue = row.Cells["Mada"].Value.ToString();
                txtSoGioCong.Text = row.Cells["Sogiocong"].Value.ToString();
            }
        }
    }
}
