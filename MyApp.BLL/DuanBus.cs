using MyApp.DAL;
using MyApp.DTO;
using System;
using System.Collections.Generic;

namespace MyApp.BUS
{
    public class DuanBus
    {
        private readonly DuanDal duan = new DuanDal();
        //lấy tất cả dữ liệu dự án
        public List<DuanDto> GetAll() => duan.GetAll();
        //thêm mới dự án
        public void Insert(DuanDto dto) 
        {
            if (string.IsNullOrWhiteSpace(dto.Mada)) throw new Exception("Mã Dự án  trống!");
            duan.Insert(dto);
        }
        //cập nhật dự án
        public void Update(DuanDto dto)
        {
           duan.Update(dto);
        }
        //xóa dự án
        public void Delete(string id)
        {
            duan.Delete(id);
        }
    }
}