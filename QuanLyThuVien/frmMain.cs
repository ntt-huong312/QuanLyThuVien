using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }



        //Hiển thị form đổi mật khẩu
        private void tsDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            f.Show();
            this.Hide();
        }

        //Hiển thị form Sách
        private void tsSach_Click(object sender, EventArgs e)
        {
            frmSach f = new frmSach();
            f.Show();
            this.Hide();
        }

        //Hiển thị form Độc giả
        private void tsDocGia_Click(object sender, EventArgs e)
        {

            frmDocGia f = new frmDocGia();
            f.Show();
            this.Hide();
        }
        
        //Hiển thị form Mượn trả sách
        private void tsMuonSach_Click(object sender, EventArgs e)
        {
            frmMuonSach f = new frmMuonSach();
            f.Show();
            this.Hide();
        }

        //Đăng xuất form trang chủ và hiển thị form đăng nhập
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.Show();
            this.Hide();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
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
