using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyTV
{
    public class DTO_DocGia
    {
        private string maDG;
        private string hoTen;
        private DateTime ngaySinh;
        private bool gioiTinh;
        private string diaChi;

        /*============ GETTER/SETTER ============*/
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
        public string HoTen
        {
            get
            {
                return hoTen;
            }
            set
            {
                hoTen = value;
            }
        }
        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }
            set
            {
                ngaySinh = value;
            }
        }
        public bool GioiTinh
        {
            get
            {
                return gioiTinh;
            }
            set
            {
                gioiTinh = value;
            }
        }
        public string DiaChi
        {
            get
            {
                return diaChi;
            }
            set
            {
                diaChi = value;
            }
        }

        /*===== CONSTRUCTOR =====*/
        public DTO_DocGia()
        {

        }
        public DTO_DocGia(string madg, string ht, DateTime ngaysinh, bool gt, string dc)
        {
            this.maDG = madg;
            this.hoTen = ht;
            this.ngaySinh = ngaysinh;
            this.gioiTinh = gt;
            this.diaChi = dc;
        }
    }
}
