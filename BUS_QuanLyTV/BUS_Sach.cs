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
    public class BUS_Sach
    {
        DAL_Sach dalSach = new DAL_Sach();

        // Phương thức trả về bảng dữ liệu chứa thông tin của tất cả các sách trong cơ sở dữ liệu.
        public DataTable loadDataSach()
        {
            return dalSach.loadDataSach();
        }

        // Phương thức trả về bảng dữ liệu chứa thông tin của sách có mã trùng với mã được truyền vào.
        public DataTable timKiemTheoMa(DTO_Sach ma)
        {
            return dalSach.timKiemTheoMa(ma);
        }

        // Phương thức trả về bảng dữ liệu chứa thông tin của sách có tên sách trùng với tên được truyền vào.
        public DataTable timKiemTheoTenSach(DTO_Sach tensach)
        {
            return dalSach.timKiemTheoTenSach(tensach);
        }

        // Phương thức thêm thông tin một cuốn sách mới vào cơ sở dữ liệu
        public bool themSach(DTO_Sach sach)
        {
            return dalSach.themSach(sach);
        }

        // Phương thức cập nhật thông tin của một cuốn sách trong cơ sở dữ liệu
        public bool suaSach(DTO_Sach sach)
        {
            return dalSach.suaSach(sach);
        }

        // Phương thức xóa thông tin của một cuốn sách trong cơ sở dữ liệu
        public bool xoaSach(DTO_Sach sach)
        {
            return dalSach.xoaSach(sach);
        }

       //Phương thức kiểm tra mã sách
        public int checkMaSach(string ma)
        {
            return dalSach.checkMaSach(ma);
        }
    }
}
