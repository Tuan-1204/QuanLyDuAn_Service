using MyApp.DAL;
using MyApp.DTO;
using System;
using System.Collections.Generic;

namespace MyApp.BUS
{
    public class NhanvienDuanBus
    {
        private readonly NhanvienDuanDal nvduan = new NhanvienDuanDal();

        // Thêm kèm Bắt lỗi 
        public string Insert(NhanvienDuanDto dto)
        {
            // Bắt lỗi trường Manv
            if (string.IsNullOrWhiteSpace(dto.Manv))
            {
                return "Mã nhân viên không được để trống!";
            }

            // Bắt lỗi trường Sogiocong
            if (dto.Sogiocong <= 0)
            {
               return "Số giờ công phải lớn hơn 0!";
            }

            nvduan.Insert(dto);
             
            return ""; // Trả về chuỗi rỗng nếu không có lỗi
        }

        // Sửa kèm Bắt lỗi
        public string Update(NhanvienDuanDto dto)
        {
            if (dto.Sogiocong <= 0)
            {
            return "Số giờ công phải lớn hơn 0!";
            }
            nvduan.Update(dto);
            return "";
        }

        //  Xóa
        public string Delete(string manv, string mada)
        {
            if (string.IsNullOrEmpty(manv) || string.IsNullOrEmpty(mada))
            {
                return "Phải chọn bản ghi để xóa !";
            }
            nvduan.Delete(manv, mada);
            return "";
        }

        //  Lấy dữ liệu Report 
        public List<NhanvienDuanDto> GetReportData()
        {
           
            return nvduan.GetReportData();
        }
    }
}