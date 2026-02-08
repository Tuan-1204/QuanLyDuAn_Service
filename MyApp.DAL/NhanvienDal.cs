using MyApp.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyApp.DAL
{
    public class NhanvienDal
    {
        public List<NhanvienDto> GetAll()
        {
            List<NhanvienDto> list = new List<NhanvienDto>();
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "SELECT * FROM Nhanvien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new NhanvienDto
                    {
                        Manhanvien = dr["Manhanvien"].ToString(),
                        Hoten = dr["Hoten"].ToString(),
                        Gioitinh = dr["Gioitinh"].ToString(),
                        Ngaysinh = dr["Ngaysinh"] == DBNull.Value ? null : (DateTime?)dr["Ngaysinh"]
                    });
                }
            }
            return list;
        }

        //thêm
        public void Insert(NhanvienDto dto)
        {
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "INSERT INTO Nhanvien VALUES(@ma, @ten, @gt, @ns)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", dto.Manhanvien);
                cmd.Parameters.AddWithValue("@ten", dto.Hoten);
                cmd.Parameters.AddWithValue("@gt", dto.Gioitinh);
                cmd.Parameters.AddWithValue("@ns", (object)dto.Ngaysinh ?? DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //sửa
        public void Update(NhanvienDto dto)
        {
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "UPDATE Nhanvien SET Hoten=@ten, Gioitinh=@gt, Ngaysinh=@ns WHERE Manhanvien=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", dto.Manhanvien);
                cmd.Parameters.AddWithValue("@ten", dto.Hoten);
                cmd.Parameters.AddWithValue("@gt", dto.Gioitinh);
                cmd.Parameters.AddWithValue("@ns", (object)dto.Ngaysinh ?? DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //xóa
        public void Delete(string ma)
        {
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "DELETE FROM Nhanvien WHERE Manhanvien=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}