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
    public partial class frmDangKy : Form
    {
        BUS_DangNhap busDangNhap = new BUS_DangNhap();
       
        public frmDangKy()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiện nút đăng ký, nếu người dùng chưa có tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(txtTenTaiKhoan.Text != "" && txtMatKhau.Text != "" && txtNhapLaiMk.Text != "" && txtEmail.Text != "")
            {
                string tenTK = txtTenTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                string nhapLaiMk = txtNhapLaiMk.Text;
                string gmail = txtEmail.Text;
                if(busDangNhap.checkTenTaiKhoan(tenTK) == 0)
                {
                    if (matKhau.Equals(nhapLaiMk))
                    {
                        DTO_DangNhap dtoDangKy = new DTO_DangNhap(tenTK, matKhau, gmail);
                        if (busDangNhap.dangKy(dtoDangKy))
                        {
                            MessageBox.Show("Đăng ký tài khoản thành công !");
                            frmDangNhap f = new frmDangNhap();
                            f.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không khớp. Vui lòng nhập lại mật khẩu !");
                    }
                }
                else
                {
                    MessageBox.Show("Tên tài khoản đã được đăng ký. Vui lòng chọn tên khác");
                }         
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
            }
        }

        //Phương thức hiển thị mật khẩu
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = (char)0;
                txtNhapLaiMk.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '⁕';
                txtNhapLaiMk.PasswordChar = '⁕';
            }
        }

        //Xử lý sự kiện nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.Show();
            this.Hide();
        }

        private void frmDangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
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
