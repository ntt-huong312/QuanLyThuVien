using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DTO_QuanLyTV;

namespace DAL_QuanLyTV
{
   static public class DataProvider
    {
        public static SqlConnection cnn;
        public static SqlDataAdapter da;
        public static SqlCommand cmd;


        /// <summary>
        /// Phương thức mở kết nối nếu có lỗi xảy ra thì nó sẽ ném lỗi và trả về cho tầng Bussiness(BUS)
        /// </summary>
        public static void moKetNoi()
        {
            cnn = new SqlConnection();
            //Liên kết đến đường dẫn trong file App.Config
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString.ToString();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Phương thức đóng kết nối
        /// </summary>
        public static void dongKetNoi()
        {
            try
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            cnn.Dispose(); //Giải phóng bộ nhớ
        }

        /// <summary>
        /// Phương thức thực hiện câu lệnh strSQL truy vấn dữ liệu và kết quả trả về là một DataTable
        /// Dùng cho các câu lệnh SELECT
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable getTable(string sql)
        {
            moKetNoi();
            da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dongKetNoi();
            return dt;
        }

        /// <summary>
        /// Phương thức cập nhật dữ liệu, thực hiện các câu lệnh Thêm, Xóa, Sửa
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static bool updateData(string sql, string[] name = null, object[] value = null)
        {
                moKetNoi();
                cmd = new SqlCommand(sql, cnn);
                //Xóa parameters của các dữ liệu trước và sau khi thực hiện vòng for
                cmd.Parameters.Clear();
                if (value != null)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(name[i], value[i]);
                    }
                }
                if(cmd.ExecuteNonQuery() > 0)
                {
                    cmd.Dispose();
                    dongKetNoi();
                    return true;
                }
                    dongKetNoi();          
                return false;
        }
        /// <summary>
        /// Kiểm tra dữ liệu dùng count(*)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int executeScalar(string sql)
        {
            moKetNoi();
            int i = 0;
            cmd = new SqlCommand(sql, cnn);
            i = (int)cmd.ExecuteScalar();
            dongKetNoi();
            return i;
        }

        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="name"></param>
        /// <param name="var"></param>
        /// <returns></returns>
        public static bool checkLogin(string sql, string name, string var)
        {
            string user = null;
            moKetNoi();
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue(name, var);
            user = (string)cmd.ExecuteScalar();
            dongKetNoi();
            return user != null;
        }
    }
}
