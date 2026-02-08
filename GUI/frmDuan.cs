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
    public partial class frmDuan : Form
    {
        // Khởi tạo client để gọi Service
        private readonly Service1Client client = new Service1Client();
        public frmDuan()
        {
            InitializeComponent();
        }

        private void frmDuan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvDuAn.DataSource = client.Duan_GetAll();

                // cột hiển thị 
                dgvDuAn.Columns["Mada"].HeaderText = "Mã Dự Án";
                dgvDuAn.Columns["Tenda"].HeaderText = "Tên Dự Án";
                dgvDuAn.Columns["Diadiem"].HeaderText = "Địa Điểm";

                // Tự động căn chỉnh độ rộng cột
                dgvDuAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách dự án: " + ex.Message);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DuanDto da = new DuanDto
                {
                    Mada = txtMaDA.Text,
                    Tenda = txtTenDA.Text,
                    Diadiem = txtDiaDiem.Text
                };

                client.Duan_Insert(da);
                MessageBox.Show("Thêm dự án mới thành công!");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                //  Bắt lỗi trống Mã DA hoặc Tên DA từ tầng BUS
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DuanDto da = new DuanDto
                {
                    Mada = txtMaDA.Text,
                    Tenda = txtTenDA.Text,
                    Diadiem = txtDiaDiem.Text
                };

                client.Duan_Update(da);
                MessageBox.Show("Cập nhật thông tin dự án thành công!");
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
                if (string.IsNullOrEmpty(txtMaDA.Text))
                {
                    MessageBox.Show("Vui lòng chọn dự án cần xóa từ danh sách!");
                    return;
                }

                if (MessageBox.Show("Xóa dự án sẽ ảnh hưởng đến dữ liệu phân công. Bạn có chắc chắn xóa?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    client.Duan_Delete(txtMaDA.Text);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDuAn.Rows[e.RowIndex];
                txtMaDA.Text = row.Cells["Mada"].Value.ToString();
                txtTenDA.Text = row.Cells["Tenda"].Value.ToString();
                txtDiaDiem.Text = row.Cells["Diadiem"].Value.ToString();

                // Khóa TextBox Mã DA để không cho phép sửa Khóa chính
                txtMaDA.Enabled = false;
            }
        }
        private void ClearFields()
        {
            txtMaDA.Enabled = true;
            txtMaDA.Clear();
            txtTenDA.Clear();
            txtDiaDiem.Clear();
            txtMaDA.Focus();
        }

    }
}
