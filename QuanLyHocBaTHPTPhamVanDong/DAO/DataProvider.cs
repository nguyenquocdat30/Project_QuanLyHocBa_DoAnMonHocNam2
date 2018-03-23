using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; // để làm singleton để tạo ra chỉ 1 thể hiện của một lớp . tận dụng biến static để làm điều này
        private string connectionSTR = @"Data Source=.\;Initial Catalog=QuanLyTHPT;Integrated Security=True";
        public static DataProvider Instance // Ctr + R + E
        {
            get
            {
                if(instance == null)
                {
                    instance = new DataProvider();
                }
                return DataProvider.instance;
            }

            private set
            {
                DataProvider.instance = value;
            }
        } 
        private DataProvider(){ }
        
        public DataTable ExecuteQuery(string query,object [] parameter = null) //hàm thực hiện truy vấn 
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if(parameter != null)
                {
                    string[] listPara = query.Split(' '); // cắt chuỗi query ra để tìm parameter
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@')) // kiểm tra chuỗi nào có kí tự @
                        {
                            command.Parameters.AddWithValue(item, parameter[i]); // lấy giá trị từ mảng parameter đưa vào item
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null) //hàm thực hiện truy vấn trả về số dòng thành công ( dùng cho thêm , sửa , xóa
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null) //hàm thực hiện đếm số lượng
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
