using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLyTV;
using DTO_QuanLyTV;

namespace QuanLyThuVien
{
    public partial class frmDocGia : Form
    {
        BUS_DocGia busDocGia = new BUS_DocGia();
        public frmDocGia()
        {
            InitializeComponent();
        }

        //Xử lý sự kiện Form Load
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            //Load dữ liệu lên DataGirdView khi load form
            dgvDocGia.DataSource = busDocGia.loadDataDocGia();

            //Đặt tên các cột trong DataGirdView
            dgvDocGia.Columns["MADG"].HeaderText = "Mã độc giả";
            dgvDocGia.Columns["HOTEN"].HeaderText = "Họ tên";
            dgvDocGia.Columns["NGAYSINH"].HeaderText = "Ngày sinh";
            dgvDocGia.Columns["GIOITINH"].HeaderText = "Giới tính";
            dgvDocGia.Columns["DIACHI"].HeaderText = "Địa chỉ";
            btnSave.Enabled = false;

            //Enable cho các control
            txtMaDG.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Text = "Sửa";
            btnXoa.Text = "Xóa";
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnSave.Enabled = false;
            btnReset.Enabled = false;
            dgvDocGia.Enabled = true;
        }

        //Xử lý sự kiện nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaDG.Enabled = true;
            txtMaDG.Text = "";
            txtHoTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            btnSave.Enabled = true;
            btnReset.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Text = "Hủy";
            btnThem.Enabled = false;
            dgvDocGia.Enabled = false;
            dgvDocGia.DataSource = busDocGia.loadDataDocGia();
            btnSave.Enabled = true;          
        }

        //Xử lý sự kiện nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        { 
            int i = dgvDocGia.CurrentCell.RowIndex;
            if(i >= 0)
            {
                if(btnSua.Text == "Hủy")
                {
                    txtMaDG.Enabled = false;
                    btnSave.Enabled = false;
                    btnReset.Enabled = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnXoa.Text = "Xóa";
                    btnSua.Text = "Sửa";
                    btnThem.Enabled = true;
                    dgvDocGia.DataSource = busDocGia.loadDataDocGia();
                    dgvDocGia.Enabled = true;
                }
                else
                {
                    if (txtMaDG.Text != "" && txtHoTen.Text != "" && dtpNgaySinh.Text != "" && rdoNam.Text != "" && txtDiaChi.Text != "")
                    {
                        string maDG = txtMaDG.Text;
                        string hoTen = txtHoTen.Text;
                        DateTime ngaySinh = Convert.ToDateTime(dtpNgaySinh.Text);
                        bool gt = rdoNam.Checked == true ? true : false;
                        string diaChi = txtDiaChi.Text;

                        //Tạo DTO
                        DTO_DocGia docgia = new DTO_DocGia(maDG, hoTen, ngaySinh, gt, diaChi);

                        if(ngaySinh >= DateTime.Now)
                        {
                            MessageBox.Show("Ngày sinh không hợp lệ");
                        }
                        else
                        {
                            if (busDocGia.suaDocGia(docgia))
                            {
                                MessageBox.Show("Sửa độc giả thành công");
                                dgvDocGia.DataSource = busDocGia.loadDataDocGia();
                            }
                            else
                            {
                                MessageBox.Show("Sửa độc giả không thành công");
                            }
                        }                     
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn độc giả muốn sửa");
            }
        }

        //Xử lý sự kiện nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text == "Hủy")
            {
                txtMaDG.Enabled = false;
                btnSave.Enabled = false;
                btnReset.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnXoa.Text = "Xóa";
                btnSua.Text = "Sửa";
                btnThem.Enabled = true;
                dgvDocGia.DataSource = busDocGia.loadDataDocGia();
                dgvDocGia.Enabled = true;
            }
            else
            {
                if(txtMaDG.Text !="" && txtHoTen.Text !="" && dtpNgaySinh.Text != "" && txtDiaChi.Text != "")
                {
                    string maDG = txtMaDG.Text;
                    string hoTen = txtHoTen.Text;
                    DateTime ngaySinh = dtpNgaySinh.Value;
                    bool gt = rdoNam.Checked == true ? true : false;
                    string diaChi = txtDiaChi.Text;
                    DTO_DocGia docgia = new DTO_DocGia(maDG, hoTen, ngaySinh, gt, diaChi);
                    DialogResult result = MessageBox.Show("Bạn có chắn chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (busDocGia.xoaDocGia(docgia))
                        {
                            MessageBox.Show("Xóa độc giả thành công");
                            lamMoi();
                            dgvDocGia.DataSource = busDocGia.loadDataDocGia();
                        }
                        else
                        {
                            MessageBox.Show("Xóa độc giả không thành công");
                        }
                    }               
                }
                else
                {
                    MessageBox.Show("Vui lòng độc giả cần xóa");
                }
            }
            

        }

        //Hiển thị dữ liệu lên textbox khi nhấn vào DataGridView
        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvDocGia.CurrentCell.RowIndex;
            txtMaDG.Text = dgvDocGia.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dgvDocGia.Rows[i].Cells[1].Value.ToString();
            dtpNgaySinh.Text = dgvDocGia.Rows[i].Cells[2].Value.ToString();
            string gt = dgvDocGia.Rows[i].Cells[3].Value.ToString();
            if (gt.Equals("Nam"))
            {
                rdoNam.Checked = true;
            } 
            else
                rdoNu.Checked = true;
            txtDiaChi.Text = dgvDocGia.Rows[i].Cells[4].Value.ToString();
        }

        //Xử lý sự kiện nút Home
        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
            this.Hide();
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text != "" && txtHoTen.Text != "" && dtpNgaySinh.Text != "" && rdoNam.Text != "" && txtDiaChi.Text != "")
            {
                string maDG = txtMaDG.Text.Trim();
                string hoTen = txtHoTen.Text;
                DateTime ngaySinh = dtpNgaySinh.Value;
                bool gt = rdoNam.Checked == true ? true : false;
                string diaChi = txtDiaChi.Text;
                //Tạo DTO
                DTO_DocGia docgia = new DTO_DocGia(maDG, hoTen, ngaySinh, gt, diaChi);
                if (ngaySinh >= DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ");
                }
                else
                {
                    if (busDocGia.checkMaDocGia(maDG) == 0)
                    {
                        
                        if (busDocGia.themDocGia(docgia))
                        {
                            MessageBox.Show("Thêm độc giả thành công");
                            dgvDocGia.DataSource = busDocGia.loadDataDocGia();
                        }
                        else
                        {
                            MessageBox.Show("Thêm độc giả không thành công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bị trùng mã độc giả");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
        //Phương thức làm mới controls
        public void lamMoi()
        {
            txtMaDG.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtDiaChi.Clear();
        }

        //Nút Reset thực hiện chức năng làm mới
        private void btnReset_Click(object sender, EventArgs e)
        {
            lamMoi();
            dgvDocGia.DataSource = busDocGia.loadDataDocGia();
        }

        private void frmDocGia_FormClosing(object sender, FormClosingEventArgs e)
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
