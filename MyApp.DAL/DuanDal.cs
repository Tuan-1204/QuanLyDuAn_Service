using System.Collections.Generic;
using System.Data.SqlClient;
using MyApp.DTO;

namespace MyApp.DAL
{
    public class DuanDal
    {
        public List<DuanDto> GetAll()
        {
            List<DuanDto> list = new List<DuanDto>();
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "SELECT * FROM Duan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new DuanDto
                    {
                        Mada = dr["Mada"].ToString(),
                        Tenda = dr["Tenda"].ToString(),
                        Diadiem = dr["Diadiem"].ToString()
                    });
                }
            }
            return list;
        }
        //thêm
        public void Insert(DuanDto dto)
        {
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "INSERT INTO Duan VALUES(@ma, @ten, @dd)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", dto.Mada);
                cmd.Parameters.AddWithValue("@ten", dto.Tenda);
                cmd.Parameters.AddWithValue("@dd", dto.Diadiem);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //sửa
        public void Update(DuanDto dto)
        {
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "UPDATE Duan SET Tenda=@ten, Diadiem=@dd WHERE Mada=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", dto.Mada);
                cmd.Parameters.AddWithValue("@ten", dto.Tenda);
                cmd.Parameters.AddWithValue("@dd", dto.Diadiem);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //xóa
        public void Delete(string ma)
        {
            using (SqlConnection conn = Db.CreateConn())
            {
                string sql = "DELETE FROM Duan WHERE Mada=@ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}