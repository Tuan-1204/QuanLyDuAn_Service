using MyApp.DAL;
using MyApp.DTO;
using System;
using System.Collections.Generic;

namespace MyApp.BUS
{
    public class NhanvienBus
    {
        private readonly NhanvienDal nhanvien = new NhanvienDal();
        // Lấy tất cả dữ liệu nhân viên
        public List<NhanvienDto> GetAll() => nhanvien.GetAll();
        //thêm
        public void Insert(NhanvienDto dto) 
        {
            if (string.IsNullOrWhiteSpace(dto.Manhanvien)) throw new Exception("Mã NV trống!");
            nhanvien.Insert(dto);
        }
        //sửa
        public void Update(NhanvienDto dto)
        {
            nhanvien.Update(dto);
        }
        //xóa
        public void Delete(string id)
        {
            nhanvien.Delete(id);
        }
    } 
}