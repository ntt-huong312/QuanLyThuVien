using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLyTV;
using BUS_QuanLyTV;

namespace QuanLyThuVien
{
    public partial class frmMuonSach : Form
    {
        BUS_MuonSach busMuonSach = new BUS_MuonSach();

        public frmMuonSach()
        {
            InitializeComponent();
        }

        //Sự kiện Form Load
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            //Load mã độc giả lên combobox
            cboMaDG.DataSource = busMuonSach.loadDataMaDG();
            cboMaDG.ValueMember = "MADG";
            cboMaDG.DisplayMember = "MADG";

            //Load mã sách lên Combobox
            cboMaSach.DataSource = busMuonSach.loadDataMaSach();         
            cboMaSach.ValueMember = "MASACH";
            cboMaSach.DisplayMember = "MASACH";

            //Load dữ liệu lên DataGirdView           
            dgvMuonSach.DataSource = busMuonSach.loadDataMuonSach();

            //Đặt tên các cột trong DataGirdView 
            dgvMuonSach.Columns["MAPHIEUMUON"].HeaderText = "Mã phiếu mượn";
            dgvMuonSach.Columns["MADG"].HeaderText = "Mã độc giả";
            dgvMuonSach.Columns["MASACH"].HeaderText = "Mã sách";
            dgvMuonSach.Columns["NGAYMUON"].HeaderText = "Ngày mượn";
            dgvMuonSach.Columns["NGAYTRA"].HeaderText = "Ngày trả";

            //Enable cho các control
            txtMaPhieuMuon.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Text = "Sửa";
            btnXoa.Text = "Xóa";
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnSave.Enabled = false;
            btnReset.Enabled = false;
            dgvMuonSach.Enabled = true;

        }
        
        //Hiển thị dữ liệu lên textbox khi nhấn vào DataGridView
        private void dgvMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvMuonSach.CurrentCell.RowIndex;
            txtMaPhieuMuon.Text = dgvMuonSach.Rows[i].Cells[0].Value.ToString();
            cboMaDG.SelectedValue = dgvMuonSach.Rows[i].Cells[1].Value.ToString();
            cboMaSach.SelectedValue = dgvMuonSach.Rows[i].Cells[2].Value.ToString();
            dtpNgayMuon.Text = dgvMuonSach.Rows[i].Cells[3].Value.ToString();
            dtpNgayTra.Text = dgvMuonSach.Rows[i].Cells[4].Value.ToString();


        }

        //Xử lý sự kiện click nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhieuMuon.Enabled = true;
            cboMaDG.Text = "";
            cboMaSach.Text = "";
            dtpNgayMuon.Value = DateTime.Now;
            dtpNgayTra.Value = DateTime.Now;
            btnSave.Enabled = true;
            btnReset.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Text = "Hủy";
            btnThem.Enabled = false;
            dgvMuonSach.Enabled = false;
            dgvMuonSach.DataSource = busMuonSach.loadDataMuonSach();
            btnSave.Enabled = true;          
        }

        //Xử lý sự kiện click nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            int i = dgvMuonSach.CurrentCell.RowIndex;
            if(i >= 0)
            {
                if (btnSua.Text == "Hủy")
                {
                    txtMaPhieuMuon.Enabled = false;
                    btnSave.Enabled = false;
                    btnReset.Enabled = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnXoa.Text = "Xóa";
                    btnSua.Text = "Sửa";
                    btnThem.Enabled = true;
                    dgvMuonSach.DataSource = busMuonSach.loadDataMuonSach();
                    dgvMuonSach.Enabled = true;
                }
                else
                {
                    if (txtMaPhieuMuon.Text != "" && cboMaDG.Text != "" && cboMaSach.Text != "" && dtpNgayMuon.Text != "" && dtpNgayTra.Text != "")
                    {
                        string maPhieuMuon = txtMaPhieuMuon.Text;
                        string maDG = cboMaDG.Text.Trim();
                        string maSach = cboMaSach.Text.Trim();
                        DateTime ngayMuon = dtpNgayMuon.Value;
                        DateTime ngayTra = dtpNgayTra.Value;

                        //Tạo DTO
                        DTO_MuonSach muonsach = new DTO_MuonSach(maPhieuMuon, maDG, maSach, ngayMuon, ngayTra);

                        //Sửa                                     
                        if (ngayTra > ngayMuon)
                        {
                            if (busMuonSach.suaMuonSach(muonsach))
                            {
                                MessageBox.Show("Sửa thành công");
                                dgvMuonSach.DataSource = busMuonSach.loadDataMuonSach();
                            }
                            else
                            {
                                MessageBox.Show("Sửa không thành công");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ngày trả phải lớn hơn ngày mượn");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    }
                }           
            }
            else
            {
                MessageBox.Show("Hãy chọn phiếu mượn muốn sửa");
            }
        }

        //Xử lý sự kiện click nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text == "Hủy")
            {
                txtMaPhieuMuon.Enabled = false;
                btnSave.Enabled = false;
                btnReset.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnXoa.Text = "Xóa";
                btnSua.Text = "Sửa";
                btnThem.Enabled = true;
                dgvMuonSach.DataSource = busMuonSach.loadDataMuonSach();
                dgvMuonSach.Enabled = true;
            }
            else
            {
                string maPhieuMuon = txtMaPhieuMuon.Text;
                string maDG = cboMaDG.Text.Trim();
                string maSach = cboMaSach.Text.Trim();
                DateTime ngayMuon = dtpNgayMuon.Value;
                DateTime ngayTra = dtpNgayTra.Value;

                //Tạo DTO
                DTO_MuonSach muonsach = new DTO_MuonSach(maPhieuMuon, maDG, maSach, ngayMuon, ngayTra);
                DialogResult result = MessageBox.Show("Bạn có chắn chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (busMuonSach.xoaMuonSach(muonsach))
                    {
                        MessageBox.Show("Xóa thông tin mượn sách thành công");
                        dgvMuonSach.DataSource = busMuonSach.loadDataMuonSach();
                        lamMoi();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại !");
                    }
                }
            }
            
        }
    
        //Thoát
        private void frmMuonSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuMuon.Text != "" && cboMaDG.Text != "" && cboMaSach.Text != "" && dtpNgayMuon.Text != "" && dtpNgayTra.Text != "")
            {
                string maPhieuMuon = txtMaPhieuMuon.Text.Trim();
                string maDG = cboMaDG.Text.Trim();
                string maSach = cboMaSach.Text.Trim();
                DateTime ngayMuon = Convert.ToDateTime(dtpNgayMuon.Value);
                DateTime ngayTra = dtpNgayTra.Value;
                //Tạo DTO
                DTO_MuonSach muonsach = new DTO_MuonSach(maPhieuMuon, maDG, maSach, ngayMuon, ngayTra);
                if (busMuonSach.checkMuonSach(maPhieuMuon) == 0)
                {
                    if (ngayTra > ngayMuon)
                    {
                        if(busMuonSach.checkMaDocGia(maDG) != -1)
                        {
                            if (busMuonSach.themMuonSach(muonsach))
                            {
                                MessageBox.Show("Thêm thành công");
                                dgvMuonSach.DataSource = busMuonSach.loadDataMuonSach();
                            }
                            else
                            {
                                MessageBox.Show("Thêm không thành công");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Độc giả đã mượn 3 cuốn sách, không thể mượn thêm");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ngày trả phải lớn hơn ngày mượn");
                    }
                }
                else
                {
                    MessageBox.Show("Mã phiếu mượn bị trùng");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
        //Reset dữ liệu trên control
        public void lamMoi()
        {
            txtMaPhieuMuon.Clear();
            cboMaDG.SelectedIndex = 0;
            cboMaSach.SelectedIndex = 0;
            dtpNgayMuon.Value = DateTime.Now;
            dtpNgayTra.Value = DateTime.Now;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            lamMoi();
            dgvMuonSach.DataSource = busMuonSach.loadDataMuonSach();
        }
    }
}
