using System.Collections.Generic;
using System.Data.SqlClient;
using MyApp.DTO;

namespace MyApp.DAL
{
    public class NhanvienDuanDal
    {
        //  Thêm 
        public void Insert(NhanvienDuanDto dto)
        {
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "INSERT INTO NhanvienDuan(Manv, Mada, Sogiocong) VALUES(@manv, @mada, @gio)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv", dto.Manv);
                cmd.Parameters.AddWithValue("@mada", dto.Mada);
                cmd.Parameters.AddWithValue("@gio", dto.Sogiocong);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //  Sửa 
        public void Update(NhanvienDuanDto dto)
        {
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "UPDATE NhanvienDuan SET Sogiocong=@gio WHERE Manv=@manv AND Mada=@mada";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv", dto.Manv);
                cmd.Parameters.AddWithValue("@mada", dto.Mada);
                cmd.Parameters.AddWithValue("@gio", dto.Sogiocong);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 3. Xóa 
        public void Delete(string manv, string mada)
        {
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "DELETE FROM NhanvienDuan WHERE Manv=@manv AND Mada=@mada";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.Parameters.AddWithValue("@mada", mada);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Truy vấn Report: Hà Nội và Giờ công > 10 
        public List<NhanvienDuanDto> GetReportData()
        {
            List<NhanvienDuanDto> list = new List<NhanvienDuanDto>();
            using (SqlConnection conn = Db.CreateConn())
            {
                //  JOIN bảng Duan
                string sql = @"SELECT nv.Hoten, da.Tenda, da.Diadiem, nvd.Sogiocong, nvd.Manv, nvd.Mada 
                       FROM NhanvienDuan nvd
                       INNER JOIN Nhanvien nv ON nvd.Manv = nv.Manhanvien
                       INNER JOIN Duan da ON nvd.Mada = da.Mada
                       WHERE da.Diadiem LIKE N'%Hà Nội%' AND nvd.Sogiocong > 10";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new NhanvienDuanDto
                    {
                        Hoten = dr["Hoten"].ToString(),
                        Tenda = dr["Tenda"].ToString(), // 
                        Diadiem = dr["Diadiem"].ToString(),
                        Sogiocong = int.Parse(dr["Sogiocong"].ToString()),
                        Manv = dr["Manv"].ToString(),
                        Mada = dr["Mada"].ToString()
                    });
                }
            }
            return list;
        }
    }
}