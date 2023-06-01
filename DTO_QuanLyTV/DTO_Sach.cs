using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO_QuanLyTV
{
    public class DTO_Sach
    {
        private string maSach;
        private string tenSach;
        private string tenTacGia;
        private int namXuatBan;
        private string nhaXuatBan;

        /*============ GETTER/SETTER ============*/
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
        public string TenSach
        {
            get
            {
                return tenSach;
            }
            set
            {
                tenSach = value;
            }
        }
        public string TenTacGia
        {
            get
            {
                return tenTacGia;
            }
            set
            {
                tenTacGia = value;
            }
        }
        public int NamXuatBan
        {
            get
            {
                return namXuatBan;
            }
            set
            {
                namXuatBan = value;
            }
        }
        public string NhaXuatBan
        {
            get
            {
                return nhaXuatBan;
            }
            set
            {
                nhaXuatBan = value;
            }
        }

        /*===== CONSTRUCTOR =====*/  
        public DTO_Sach()
        {

        }
        public DTO_Sach(string ms, string tensach, string tentg, int namxb, string nxb)
        {
            this.maSach = ms;
            this.tenSach = tensach;
            this.tenTacGia = tentg;
            this.namXuatBan = namxb;
            this.nhaXuatBan = nxb;
        }

    }
}
