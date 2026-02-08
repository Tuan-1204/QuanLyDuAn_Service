using System.Collections.Generic;
using MyApp.BUS;
using MyApp.DTO;

namespace MyApp.WcfService
{
    public class Service1 : IService1
    {
        // Khởi tạo các đối tượng BUS (BLL)
        private readonly NhanvienDuanBus nvdaBus = new NhanvienDuanBus();
        private readonly NhanvienBus nvBus = new NhanvienBus();
        private readonly DuanBus daBus = new DuanBus();

        //  CÁC THAO TÁC CHO BẢNG NHÂN VIÊN 
        public List<NhanvienDto> Nhanvien_GetAll() => nvBus.GetAll();

        public void Nhanvien_Insert(NhanvienDto dto) => nvBus.Insert(dto);

        public void Nhanvien_Update(NhanvienDto dto) => nvBus.Update(dto);

        public void Nhanvien_Delete(string id) => nvBus.Delete(id);


        // CÁC THAO TÁC CHO BẢNG DỰ ÁN 
        public List<DuanDto> Duan_GetAll() => daBus.GetAll();

        public void Duan_Insert(DuanDto dto) => daBus.Insert(dto);

        public void Duan_Update(DuanDto dto) => daBus.Update(dto);

        public void Duan_Delete(string id) => daBus.Delete(id);


        // CÁC THAO TÁC CHO  NHÂN VIÊN DỰ ÁN 
        public void Nvd_Insert(NhanvienDuanDto dto) => nvdaBus.Insert(dto);

        public void Nvd_Update(NhanvienDuanDto dto) => nvdaBus.Update(dto);

        public void Nvd_Delete(string manv, string mada) => nvdaBus.Delete(manv, mada);


        //  TRUY VẤN BÁO CÁO 
        public List<NhanvienDuanDto> Nvd_GetReport() => nvdaBus.GetReportData();
    }
}