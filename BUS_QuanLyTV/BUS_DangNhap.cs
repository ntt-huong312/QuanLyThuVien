using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QuanLyTV;
using DTO_QuanLyTV;

namespace BUS_QuanLyTV
{
    public class BUS_DangNhap
    {
        //Khởi tạo DAL
        DAL_DangNhap dalDangNhap = new DAL_DangNhap();

        /*============= ĐĂNG NHẬP =============*/

        // Phương thức kiểm tra tên tài khoản
        public bool checkTaiKhoan(string tentaikhoan)
        {
            return dalDangNhap.checkTaiKhoan(tentaikhoan);
        }

        //Phương thức kiểm tra mật khẩu
        public bool checkMatKhau(string matkhau)
        {
            return dalDangNhap.checkMatKhau(matkhau);
        }


        /*============= ĐỔI MẬT KHẨU =============*/
        //Phương thức cập nhật mật khẩu của người dùng trong cơ sở dữ liệu
        public bool doiMatKhau(DTO_DangNhap matkhau)
        {
            return dalDangNhap.doiMatKhau(matkhau);
        }

        /*============= ĐĂNG KÝ =============*/
        //Phương thức thêm thông tin một người dùng mới vào cơ sở dữ liệu
        public bool dangKy(DTO_DangNhap dk)
        {
            return dalDangNhap.dangKy(dk);
        }

        //Phương thức kiểm tra tên tài khoản đã có trong cơ sở dữ liệu hay chưa
        public int checkTenTaiKhoan(string taikhoan)
        {
            return dalDangNhap.checkTenTaiKhoan(taikhoan);
        }

    }
}
