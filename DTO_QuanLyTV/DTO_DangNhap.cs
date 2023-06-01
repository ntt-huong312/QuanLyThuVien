using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyTV
{
    public class DTO_DangNhap
    {
        private string taiKhoan;
        private string matKhau;
        private string gmail;
        
        /*========= GETTER/SETTER =========*/
        public string TaiKhoan
        {
            get
            {
                return taiKhoan;
            }
            set 
            {
                taiKhoan = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return matKhau;
            }
            set
            {
                matKhau = value;
            }
        }
        public string Gmail
        {
            get
            {
                return gmail;
            }
            set
            {
                gmail = value;
            }
        }

        /*========== CONSTRUCTOR ==========*/
        public DTO_DangNhap()
        {

        }
        public DTO_DangNhap(string tk, string mk, string gmail = "")
        {
            this.taiKhoan = tk;
            this.matKhau = mk;
            this.gmail = gmail;
        }
    }
}
