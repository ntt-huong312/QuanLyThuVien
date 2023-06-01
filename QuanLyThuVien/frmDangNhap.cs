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
    public partial class frmDangNhap : Form
    {
        BUS_DangNhap busDangNhap = new BUS_DangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiện nút đăng nhập, nếu nhập đúng thông tin thì hiển thị form Trang chủ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtTenDangNhap.Text != "" && txtMatKhau.Text != "")
            {
                string tenTaiKhoan = txtTenDangNhap.Text;
                string matKhau = txtMatKhau.Text;
                if (busDangNhap.checkTaiKhoan(tenTaiKhoan))
                {
                    if (busDangNhap.checkMatKhau(matKhau))
                    {
                        MessageBox.Show("Đăng nhập thành công !");
                        frmMain f = new frmMain();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không chính xác !");
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập không chính xác !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập !");
            }      
        }


        /// <summary>
        /// Xử lý sự kiện nút Đăng ký nếu người dùng chưa có tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy f = new frmDangKy();
            f.Show();
            this.Hide();
        }

        //Phương thức hiển thị mật khẩu
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '⁕';
            }    
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }
    }
}
