using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_QuanLyTV;

namespace DAL_QuanLyTV
{
    public class DAL_DocGia
    {
        /// <summary>
        /// Lấy toàn bộ thông tin độc giả
        /// </summary>
        /// <returns></returns>
        public DataTable loadDataDocGia()
        {          
            string sql = "SelectAllDocGia";
            return DataProvider.getTable(sql);
        }

        /// <summary>
        /// Thêm độc giả
        /// </summary>
        /// <param name="docgia"></param>
        /// <returns></returns>
        public bool themDocGia(DTO_DocGia docgia)
        {
            string sql = "INSERT INTO DOCGIA VALUES (@madg, @hoten, @ngaysinh, @gt, @diachi)";
            string[] name = { "@madg", "@hoten", "@ngaysinh", "@gt", "@diachi" };
            object[] value = { docgia.MaDG, docgia.HoTen, docgia.NgaySinh, docgia.GioiTinh, docgia.DiaChi};
            return DataProvider.updateData(sql, name, value);
        }

        /// <summary>
        /// Sửa độc giả
        /// </summary>
        /// <param name="docgia"></param>
        /// <returns></returns>
        public bool suaDocGia(DTO_DocGia docgia)
        {
            string sql =string.Format("UPDATE DOCGIA SET HOTEN = @hoten, NGAYSINH = @ngaysinh, GIOITINH = @gt, DIACHI = @diachi WHERE MADG ='{0}'",docgia.MaDG);
            string[] name = { "@hoten", "@ngaysinh", "@gt", "@diachi"};
            object[] value = {docgia.HoTen, docgia.NgaySinh, docgia.GioiTinh, docgia.DiaChi};
            return DataProvider.updateData(sql, name, value);
        }

        /// <summary>
        /// Xóa độc giả
        /// </summary>
        /// <param name="docgia"></param>
        /// <returns></returns>
        public bool xoaDocGia(DTO_DocGia docgia)
        {
            string sql = "DELETE FROM DOCGIA WHERE MADG = @madg";
            string[] name = { "@madg"};
            object[] value = { docgia.MaDG};
            return DataProvider.updateData(sql, name, value);
        }

        //Kiểm tra mã độc giả
        public int checkMaDocGia(string ma)
        {
            string sql = string.Format("SELECT COUNT(*) FROM DOCGIA WHERE MADG ='{0}'", ma);
            return DataProvider.executeScalar(sql);
        }
    }
}
