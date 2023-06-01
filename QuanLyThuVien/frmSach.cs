using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLyTV;
using BUS_QuanLyTV;

namespace QuanLyThuVien
{
    public partial class frmSach : Form
    {
        //Khởi tạo BUS_Sach
        BUS_Sach busSach = new BUS_Sach();
        public frmSach()
        {
            InitializeComponent();
        }

        //Sự kiện Form Load
        private void frmSach_Load(object sender, EventArgs e)
        {
            //Load toàn bộ dữ liệu lên DataGridView khi form load
            dgvSach.DataSource = busSach.loadDataSach();

            //Đặt tên các cột trong DataGirdView
            dgvSach.Columns["MASACH"].HeaderText = "Mã sách";
            dgvSach.Columns["TENSACH"].HeaderText = "Tên sách";
            dgvSach.Columns["TENTACGIA"].HeaderText = "Tên tác giả";
            dgvSach.Columns["NAMXB"].HeaderText = "Năm xuất bản";
            dgvSach.Columns["NHAXB"].HeaderText = "Nhà xuất bản";

            //Enable cho các control
            txtMaSach.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Text = "Sửa";
            btnXoa.Text = "Xóa";
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnSave.Enabled = false;
            btnReset.Enabled = false;
            dgvSach.Enabled = true;


        }

        //Hiển thị dữ liệu lên textbox khi nhấn vào DataGridView
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvSach.CurrentCell.RowIndex;
            txtMaSach.Text = dgvSach.Rows[i].Cells[0].Value.ToString();
            txtTenSach.Text = dgvSach.Rows[i].Cells[1].Value.ToString();
            txtTenTG.Text = dgvSach.Rows[i].Cells[2].Value.ToString();
            txtNamXB.Text = dgvSach.Rows[i].Cells[3].Value.ToString();
            txtNXB.Text = dgvSach.Rows[i].Cells[4].Value.ToString();

        }

        //Xử lý sự kiện nút Tìm kiếm
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung cần tìm");
            }
            else
            {
                DTO_Sach sach = new DTO_Sach();
                DataTable dt = new DataTable();
                if (rdoMaSach.Checked)
                {

                    sach.MaSach = txtTimKiem.Text;
                    dt = busSach.timKiemTheoMa(sach);
                    txtTimKiem.Clear();
                    txtTimKiem.Focus();

                }
                else if (rdoTenSach.Checked)
                {

                    sach.TenSach = txtTimKiem.Text;
                    dt = busSach.timKiemTheoTenSach(sach);
                    txtTimKiem.Clear();
                    txtTimKiem.Focus();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sách");
                }
                else
                {
                    dgvSach.DataSource = dt;
                }

            }
        }

        //Xử lý sự kiện click nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSach.Enabled = true;
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtTenTG.Text = "";
            txtNamXB.Text = "";
            txtNXB.Text = "";
            btnSave.Enabled = true;
            btnReset.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Text = "Hủy";
            btnThem.Enabled = false;
            dgvSach.Enabled = false;
            dgvSach.DataSource = busSach.loadDataSach(); 
        }

        //Xử lý sự kiện nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {

            int i = dgvSach.CurrentCell.RowIndex;
            if (i >= 0)
            {
                if (btnSua.Text == "Hủy")
                {
                    txtMaSach.Enabled = false;
                    btnSave.Enabled = false;
                    btnReset.Enabled = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnXoa.Text = "Xóa";
                    btnSua.Text = "Sửa";
                    btnThem.Enabled = true;
                    dgvSach.DataSource = busSach.loadDataSach();
                    dgvSach.Enabled = true;
                }
                else
                {
                    if (txtMaSach.Text != "" && txtTenSach.Text != "" && txtTenTG.Text != "" && txtNamXB.Text != "" && txtNXB.Text != "")
                    {
                        //Lấy thông tin từ các Control
                        string maSach = txtMaSach.Text;
                        string tenSach = txtTenSach.Text;
                        string tenTacGia = txtTenTG.Text;
                        int namXB = int.Parse(txtNamXB.Text);
                        string nhaXB = txtNXB.Text;

                        DTO_Sach sach = new DTO_Sach(maSach, tenSach, tenTacGia, namXB, nhaXB);
                        if (busSach.suaSach(sach))
                        {
                            MessageBox.Show("Sửa thông tin sách thành công !");
                            dgvSach.DataSource = busSach.loadDataSach();
                        }
                        else
                        {
                            MessageBox.Show("Sửa thông tin sách không thành công !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn thông tin sách cần sửa");
                    }
                }


            }

        }

        //Xử lý sự kiện nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (btnXoa.Text == "Hủy")
            {
                txtMaSach.Enabled = false;
                btnSave.Enabled = false;
                btnReset.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnXoa.Text = "Xóa";
                btnSua.Text = "Sửa";
                btnThem.Enabled = true;
                dgvSach.DataSource = busSach.loadDataSach();
                dgvSach.Enabled = true;
            }
            else
            {
                if (txtMaSach.Text != "" && txtTenSach.Text != "" && txtTenTG.Text != "" && txtNamXB.Text != "" && txtNXB.Text != "")
                {
                    string maSach = txtMaSach.Text;
                    string tenSach = txtTenSach.Text;
                    string tenTacGia = txtTenTG.Text;
                    int namXB = int.Parse(txtNamXB.Text);
                    string nhaXB = txtNXB.Text;

                    DTO_Sach sach = new DTO_Sach(maSach, tenSach, tenTacGia, namXB, nhaXB);
                    DialogResult result = MessageBox.Show("Bạn có chắn chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (busSach.xoaSach(sach))
                        {
                            MessageBox.Show("Xóa sách thành công !");
                            lamMoi();
                            dgvSach.DataSource = busSach.loadDataSach();
                        }
                        else
                        {
                            MessageBox.Show("Xóa sách không thành công !");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sách cần xóa");
                }
            }
        }

        //Nút lưu thực hiện chức năng lưu thông tin khi thêm 1 cuốn sách mới
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text != "" && txtTenSach.Text != "" && txtTenTG.Text != "" && txtNamXB.Text != "" && txtNXB.Text != "")
            {

                string maSach = txtMaSach.Text.Trim();
                if (busSach.checkMaSach(maSach) == 0)
                {
                    string tenSach = txtTenSach.Text;
                    string tenTacGia = txtTenTG.Text;
                    int namXB = int.Parse(txtNamXB.Text);
                    string nhaXB = txtNXB.Text;

                    DTO_Sach sach = new DTO_Sach(maSach, tenSach, tenTacGia, namXB, nhaXB);
                    if (busSach.themSach(sach))
                    {
                        MessageBox.Show("Thêm sách thành công !");
                        dgvSach.DataSource = busSach.loadDataSach();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sách không thành công !");
                    }
                }
                else
                {
                    MessageBox.Show("Bị trùng mã sách !");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin");
            }
        }
        //Xử lý sự kiện nút Home
        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
            this.Hide();
        }

        //Phương thức làm mới Controls
        public void lamMoi()
        {
            txtMaSach.Clear();
            txtMaSach.Focus();
            txtTenSach.Clear();
            txtTenTG.Clear();
            txtNamXB.Clear();
            txtNXB.Clear();
        }

        //Nút Reset thực hiện chức năng làm mới
        private void btnReset_Click(object sender, EventArgs e)
        {
            lamMoi();
            dgvSach.DataSource = busSach.loadDataSach();
        }

        //Thực hiện chức năng đóng form
        private void frmSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
