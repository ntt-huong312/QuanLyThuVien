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
    public class BUS_MuonSach
    { 
        DAL_MuonSach dalMuonSach = new DAL_MuonSach();

        // Phương thức trả về bảng dữ liệu chứa tất cả thông tin mượn sách trong cơ sở dữ liệu.
        public DataTable loadDataMuonSach()
        {
            return dalMuonSach.loadDataMuonSach();
        }

        //Phương thức load dữ liệu mã độc giả từ cơ sở dữ liệu và trả về dưới dạng DataTable.
        public DataTable loadDataMaDG()
        {
            return dalMuonSach.loadMaDG();
        }

        //Phương thức load dữ liệu mã sách từ cơ sở dữ liệu và trả về dưới dạng DataTable.
        public DataTable loadDataMaSach()
        {
            return dalMuonSach.loadMaSach();
        }

        // Phương thức thêm một thông tin mượn sách mới vào cơ sở dữ liệu
        public bool themMuonSach(DTO_MuonSach muonsach)
        {
            return dalMuonSach.themMuonSach(muonsach);
        }

        // Phương thức cập nhật thông tin một cuốn sách trong cơ sở dữ liệu
        public bool suaMuonSach(DTO_MuonSach muonsach)
        {
            return dalMuonSach.suaMuonSach(muonsach);
        }

        // Phương thức xóa thông tin một cuốn sách trong cơ sở dữ liệu
        public bool xoaMuonSach(DTO_MuonSach muonsach)
        {
            return dalMuonSach.xoaMuonSach(muonsach);
        }

        // Phương thức kiểm tra mã phiế mượn
        public int checkMuonSach(string maphieumuon)
        {
            return dalMuonSach.checkMuonSach(maphieumuon);
        }

        //Kiểm tra mã độc giả đã mượn sách trong bảng MUONSACH
        public int checkMaDocGia(string madocgia)
        {
            int count = dalMuonSach.checkMaDocGia(madocgia);
            if(count >= 3)
            {
                return -1;
            }
            else
            {
                return count;
            }
        }
    }
}
