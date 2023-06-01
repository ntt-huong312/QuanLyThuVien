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
    public class BUS_DocGia
    {
        DAL_DocGia dalDocGia = new DAL_DocGia();

        // Phương thức trả về bảng dữ liệu chứa thông tin của tất cả độc giả trong cơ sở dữ liệu.
        public DataTable loadDataDocGia()
        {
            return dalDocGia.loadDataDocGia();
        }

        // Phương thức thêm thông tin một độc giả mới vào cơ sở dữ liệu
        public bool themDocGia(DTO_DocGia docgia)
        {
            return dalDocGia.themDocGia(docgia);
        }

        // Phương thức cập nhật thông tin độc giả trong cơ sở dữ liệu
        public bool suaDocGia(DTO_DocGia docgia)
        {
            return dalDocGia.suaDocGia(docgia);
        }

        // Phương thức xóa thông tin độc giả trong cơ sở dữ liệu
        public bool xoaDocGia(DTO_DocGia docgia)
        {
            return dalDocGia.xoaDocGia(docgia);
        }

        // Phương thức kiểm tra mã độc giả
        public int checkMaDocGia(string ma)
        {
            return dalDocGia.checkMaDocGia(ma);
        }
    }
}
