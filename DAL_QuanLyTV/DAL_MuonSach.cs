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
    public class DAL_MuonSach
    {
        /// <summary>
        /// Lấy toàn bộ thông tin mượn sách
        /// </summary>
        /// <returns></returns>
       public DataTable loadDataMuonSach()
        {
            string sql = "SellectAllMuonSach";       
            return DataProvider.getTable(sql);
                           
        }

        //Lấy mã độc giả
        public DataTable loadMaDG()
        {
            string sql = "SELECT * FROM DOCGIA";
            return DataProvider.getTable(sql);
        }

        //Lấy mã sách
        public DataTable loadMaSach()
        {
            string sql = "SELECT * FROM SACH";
            return DataProvider.getTable(sql);
        }
        
        /// <summary>
        /// Thêm thông tin mượn sách
        /// </summary>
        /// <param name="muonsach"></param>
        /// <returns></returns>
        public bool themMuonSach(DTO_MuonSach muonsach)
        {
            string sql = "INSERT INTO MUONSACH VALUES (@maphieumuon, @madocgia, @masach, @ngaymuon, @ngaytra)";
            string[] name = { "@maphieumuon", "@madocgia", "@masach", "@ngaymuon", "@ngaytra" };
            object[] value = { muonsach.MaPhieuMuon, muonsach.MaDG, muonsach.MaSach, muonsach.NgayMuon, muonsach.NgayTra };
            return DataProvider.updateData(sql, name, value);
        }

        /// <summary>
        /// Sửa thông tin mượn sách
        /// </summary>
        /// <param name="muonsach"></param>
        /// <returns></returns>
        public bool suaMuonSach(DTO_MuonSach muonsach)
        {
            string sql = string.Format("UPDATE MUONSACH SET MASACH = @masach, NGAYMUON = @ngaymuon, NGAYTRA = @ngaytra WHERE MAPHIEUMUON = '{0}'", muonsach.MaPhieuMuon);
            string[] name = {  "@masach", "@ngaymuon", "@ngaytra" };
            object[] value = { muonsach.MaSach, muonsach.NgayMuon, muonsach.NgayTra};           
            return DataProvider.updateData(sql, name, value);        
        }

        /// <summary>
        /// Xóa thông tin mượn sách
        /// </summary>
        /// <param name="muonsach"></param>
        /// <returns></returns>
        public bool xoaMuonSach(DTO_MuonSach muonsach)
        {
            string sql = "DELETE FROM MUONSACH WHERE MAPHIEUMUON = @maphieumuon";
            string[] name = { "@maphieumuon" };
            object[] value = { muonsach.MaPhieuMuon };
            return DataProvider.updateData(sql, name, value);
        }

        //Kiểm tra mã phiếu
        public int checkMuonSach(string maphieumuon)
        {
            string sql =string.Format("SELECT COUNT(*) FROM MUONSACH WHERE MAPHIEUMUON ='{0}'", maphieumuon);
            return DataProvider.executeScalar(sql);
        }

        //Kiểm tra mã độc giả đã mượn sách trong bảng MUONSACH
        public int checkMaDocGia(string madocgia)
        {
            string sql = string.Format("SELECT COUNT(*) FROM MUONSACH WHERE MADG ='{0}'", madocgia);
            return DataProvider.executeScalar(sql);
        }
    }

}
