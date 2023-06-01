using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyTV
{
    public class DTO_MuonSach
    {
        private string maPhieuMuon;
        private string maDG;
        private string maSach;
        private DateTime ngayMuon;       
        private DateTime ngayTra;

        /*============ GETTER/SETTER ============*/
        public string MaPhieuMuon
        {
            get
            {
                return maPhieuMuon;
            }
            set
            {
                maPhieuMuon = value;
            }
        }
        public string MaDG
        {
            get
            {
                return maDG;
            }
            set
            {
                maDG = value;
            }
        }
        public string MaSach
        {
            get
            {
                return maSach;
            }
            set
            {
                maSach = value;
            }
        }
        public DateTime NgayMuon
        {
            get
            {
                return ngayMuon;
            }
            set
            {
                ngayMuon = value;
            }
        }
        public DateTime NgayTra
        {
            get
            {
                return ngayTra;
            }
            set
            {
                ngayTra = value;
            }
        }
        /*===== CONSTRUCTOR =====*/ 
        public DTO_MuonSach()
        {

        }
        public DTO_MuonSach(string maphieumuon, string madg, string masach, DateTime ngaymuon, DateTime ngaytra)
        {
            this.maPhieuMuon = maphieumuon;
            this.maDG = madg;
            this.maSach = masach;
            this.ngayMuon = ngaymuon;           
            this.ngayTra = ngaytra;
        }

    }
}
