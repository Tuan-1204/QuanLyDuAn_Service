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
    public partial class frmNhanvien : Form
    {
        // Khởi tạo client để gọi Service
        private readonly Service1Client client = new Service1Client();
        public frmNhanvien()
        {
            InitializeComponent();
        }
        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            try
            {
                dgvNhanVien.DataSource = client.Nhanvien_GetAll();
                //  tiêu đề cột 
                dgvNhanVien.Columns["Manhanvien"].HeaderText = "Mã Nhân Viên";
                dgvNhanVien.Columns["Hoten"].HeaderText = "Họ Tên";
                dgvNhanVien.Columns["Gioitinh"].HeaderText = "Giới Tính";
                dgvNhanVien.Columns["Ngaysinh"].HeaderText = "Ngày Sinh";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NhanvienDto nv = new NhanvienDto
                {
                    Manhanvien = txtMaNV.Text,
                    Hoten = txtHoTen.Text,
                    Gioitinh = txtGioiTinh.Text,
                    Ngaysinh = dtpNgaySinh.Value
                };

                client.Nhanvien_Insert(nv);
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                //  Bắt lỗi nghiệp vụ từ BUS gửi qua WCF
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                NhanvienDto nv = new NhanvienDto
                {
                    Manhanvien = txtMaNV.Text,
                    Hoten = txtHoTen.Text,
                    Gioitinh = txtGioiTinh.Text,
                    Ngaysinh = dtpNgaySinh.Value
                };

                client.Nhanvien_Update(nv);
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    client.Nhanvien_Delete(txtMaNV.Text);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["Manhanvien"].Value.ToString();
                txtHoTen.Text = row.Cells["Hoten"].Value.ToString();
                txtGioiTinh.Text = row.Cells["Gioitinh"].Value.ToString();

                if (row.Cells["Ngaysinh"].Value != null)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["Ngaysinh"].Value);

                // Khóa mã nhân viên khi sửa để tránh sửa nhầm khóa chính
                txtMaNV.Enabled = false;
            }
        }

        private void ClearFields()
        {
            txtMaNV.Enabled = true;
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            txtMaNV.Focus();
        }


    }
}
