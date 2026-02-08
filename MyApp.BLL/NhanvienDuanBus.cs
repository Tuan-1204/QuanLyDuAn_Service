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
        public void Insert(NhanvienDuanDto dto)
        {
            // Bắt lỗi trường Manv
            if (string.IsNullOrWhiteSpace(dto.Manv))
            {
                throw new Exception("Mã nhân viên không được để trống!");
            }

            // Bắt lỗi trường Sogiocong
            if (dto.Sogiocong <= 0)
            {
                throw new Exception("Số giờ công phải là số nguyên dương lớn hơn 0!");
            }

            nvduan.Insert(dto);
        }

        // Sửa kèm Bắt lỗi
        public void Update(NhanvienDuanDto dto)
        {
            if (dto.Sogiocong <= 0)
            {
                throw new Exception("Số giờ công cập nhật phải lớn hơn 0!");
            }
            nvduan.Update(dto);
        }

        //  Xóa
        public void Delete(string manv, string mada)
        {
            if (string.IsNullOrEmpty(manv) || string.IsNullOrEmpty(mada))
            {
                throw new Exception("Phải chọn bản ghi cần xóa!");
            }
            nvduan.Delete(manv, mada);
        }

        //  Lấy dữ liệu Report 
        public List<NhanvienDuanDto> GetReportData()
        {
           
            return nvduan.GetReportData();
        }
    }
}