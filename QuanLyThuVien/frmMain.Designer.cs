
namespace QuanLyThuVien
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDoiMK = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSach = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDocGia = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMuonSach = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiKhoảnToolStripMenuItem,
            this.quảnLýThôngTinToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1103, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDoiMK,
            this.tsDangXuat});
            this.tàiKhoảnToolStripMenuItem.Image = global::QuanLyThuVien.Properties.Resources.Fatcow_Farm_Fresh_Account_menu_32;
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(127, 29);
            this.tàiKhoảnToolStripMenuItem.Text = "Hệ thống";
            // 
            // tsDoiMK
            // 
            this.tsDoiMK.Image = global::QuanLyThuVien.Properties.Resources.Fatcow_Farm_Fresh_Key_32;
            this.tsDoiMK.Name = "tsDoiMK";
            this.tsDoiMK.Size = new System.Drawing.Size(221, 34);
            this.tsDoiMK.Text = "Đổi mật khẩu";
            this.tsDoiMK.Click += new System.EventHandler(this.tsDoiMK_Click);
            // 
            // tsDangXuat
            // 
            this.tsDangXuat.Image = global::QuanLyThuVien.Properties.Resources.Pictogrammers_Material_Account_arrow_left_512;
            this.tsDangXuat.Name = "tsDangXuat";
            this.tsDangXuat.Size = new System.Drawing.Size(221, 34);
            this.tsDangXuat.Text = "Đăng xuất";
            this.tsDangXuat.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // quảnLýThôngTinToolStripMenuItem
            // 
            this.quảnLýThôngTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSach,
            this.tsDocGia,
            this.tsMuonSach});
            this.quảnLýThôngTinToolStripMenuItem.Image = global::QuanLyThuVien.Properties.Resources.Fatcow_Farm_Fresh_Ssl_tls_manager_32;
            this.quảnLýThôngTinToolStripMenuItem.Name = "quảnLýThôngTinToolStripMenuItem";
            this.quảnLýThôngTinToolStripMenuItem.Size = new System.Drawing.Size(191, 29);
            this.quảnLýThôngTinToolStripMenuItem.Text = "Quản lý thông tin";
            // 
            // tsSach
            // 
            this.tsSach.Image = global::QuanLyThuVien.Properties.Resources.Iron_Devil_Ids_3d_Icons_40_Books_32;
            this.tsSach.Name = "tsSach";
            this.tsSach.Size = new System.Drawing.Size(270, 34);
            this.tsSach.Text = "Sách";
            this.tsSach.Click += new System.EventHandler(this.tsSach_Click);
            // 
            // tsDocGia
            // 
            this.tsDocGia.Image = global::QuanLyThuVien.Properties.Resources.Custom_Icon_Design_Mini_3_Student_id_48;
            this.tsDocGia.Name = "tsDocGia";
            this.tsDocGia.Size = new System.Drawing.Size(270, 34);
            this.tsDocGia.Text = "Độc giả";
            this.tsDocGia.Click += new System.EventHandler(this.tsDocGia_Click);
            // 
            // tsMuonSach
            // 
            this.tsMuonSach.Image = global::QuanLyThuVien.Properties.Resources.Graphicrating_Koloria_File_Table_32;
            this.tsMuonSach.Name = "tsMuonSach";
            this.tsMuonSach.Size = new System.Drawing.Size(270, 34);
            this.tsMuonSach.Text = "Mượn trả sách";
            this.tsMuonSach.Click += new System.EventHandler(this.tsMuonSach_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(858, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyThuVien.Properties.Resources.background_book_trong_anh_nang_800x500;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1103, 578);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thư viện";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsDoiMK;
        private System.Windows.Forms.ToolStripMenuItem quảnLýThôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsSach;
        private System.Windows.Forms.ToolStripMenuItem tsDocGia;
        private System.Windows.Forms.ToolStripMenuItem tsMuonSach;
        private System.Windows.Forms.ToolStripMenuItem tsDangXuat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

