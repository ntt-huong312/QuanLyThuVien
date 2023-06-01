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
    public partial class frmDoiMatKhau : Form
    {
        BUS_DangNhap busDoiMatKhau = new BUS_DangNhap();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiến đổi mật khẩu, nếu đổi thành công thì hiển thị form đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" && txtMatKhauCu.Text != "" && txtMatKhauMoi.Text != "" && txtNhapLaiMkMoi.Text != "")
            {
                string tenDangNhap = txtTenDangNhap.Text;
                string matKhauCu = txtMatKhauCu.Text;
                string matKhauMoi = txtMatKhauMoi.Text;
                DTO_DangNhap dtoDoiMatKhau = new DTO_DangNhap(tenDangNhap, matKhauMoi);
                if (busDoiMatKhau.checkTaiKhoan(tenDangNhap))
                {
                    if (busDoiMatKhau.checkMatKhau(matKhauCu))
                    {
                        if (txtMatKhauMoi.Text.Equals(txtNhapLaiMkMoi.Text))
                        {
                            if (busDoiMatKhau.doiMatKhau(dtoDoiMatKhau))
                            {
                                MessageBox.Show("Đổi mật khẩu thành công");
                                frmDangNhap f = new frmDangNhap();
                                f.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Đổi mật khẩu không thành công");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không khớp. Vui lòng kiểm tra lại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác. Vui lòng kiểm tra lại");
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập không đúng");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
        //Xử lý sự kiện nút thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
            this.Hide();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                txtMatKhauCu.PasswordChar = (char)0;
                txtMatKhauMoi.PasswordChar = (char)0;
                txtNhapLaiMkMoi.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhauCu.PasswordChar = '⁕';
                txtMatKhauMoi.PasswordChar = '⁕';
                txtNhapLaiMkMoi.PasswordChar = '⁕';

            }
        }
    }
}
