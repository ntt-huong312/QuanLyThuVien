using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DTO_QuanLyTV;

namespace DAL_QuanLyTV
{
    public class DAL_Sach
    {
        
        /// <summary>
        /// Lấy toàn bộ sách
        /// </summary>
        /// <returns></returns>
       public DataTable loadDataSach()
        {
            string sql = "SELECT * FROM SACH";
            return DataProvider.getTable(sql);
        }

        /// <summary>
        /// Tìm kiếm tên theo mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public DataTable timKiemTheoMa(DTO_Sach ma)
        {
            string sql = string.Format("SELECT * FROM SACH WHERE MASACH LIKE '%{0}%'", ma.MaSach);
            return DataProvider.getTable(sql);
        }

        /// <summary>
        /// Tìm kiếm theo tên sách
        /// </summary>
        /// <param name="tensach"></param>
        /// <returns></returns>
        public DataTable timKiemTheoTenSach(DTO_Sach tensach)
        {
            string sql = string.Format("SELECT * FROM SACH WHERE TENSACH LIKE N'%{0}%'", tensach.TenSach);
            return DataProvider.getTable(sql);
        }

        /// <summary>
        /// Thêm sách
        /// </summary>
        /// <param name="maSach"></param>
        /// <param name="tenSach"></param>
        /// <param name="tenTg"></param>
        /// <param name="namXB"></param>
        /// <param name="nhaXB"></param>
        public bool themSach(DTO_Sach sach)
        {
            string sql = string.Format("INSERT INTO SACH VALUES (@masach, @tensach, @tentacgia, @namxb, @nxb)");
            string[] name = { "@masach", "tensach", "tentacgia", "@namxb", "@nxb" };
            object[] value = { sach.MaSach, sach.TenSach, sach.TenTacGia, sach.NamXuatBan, sach.NhaXuatBan};

            return DataProvider.updateData(sql, name, value);
        }

        /// <summary>
        /// Sửa sách
        /// </summary>
        /// <param name="sach"></param>
        /// <returns></returns>
        public bool suaSach(DTO_Sach sach)
        {
            string sql = string.Format("UPDATE SACH SET TENSACH = @tensach, TENTACGIA = @tentacgia, NAMXB = @namxb, NHAXB = @nxb WHERE MASACH = '{0}'", sach.MaSach);
            string[] name = { "@tensach", "@tentacgia", "@namxb", "@nxb" };
            object[] value = { sach.TenSach, sach.TenTacGia, sach.NamXuatBan, sach.NhaXuatBan};
            return DataProvider.updateData(sql, name, value);
        }

        /// <summary>
        /// Xóa sách
        /// </summary>
        /// <param name="sach"></param>
        /// <returns></returns>
        public bool xoaSach(DTO_Sach sach)
        {
            string sql = "DELETE FROM SACH WHERE MASACH = @masach";
            string[] name = { "@masach" };
            object[] value = { sach.MaSach};
            return DataProvider.updateData(sql, name, value);
        }

        /// <summary>
        /// Kiểm tra mã sách
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public int checkMaSach(string ma)
        {
            string sql = string.Format("select count(*) from SACH where MASACH ='{0}'", ma);
            return DataProvider.executeScalar(sql);
        }
    }
}
